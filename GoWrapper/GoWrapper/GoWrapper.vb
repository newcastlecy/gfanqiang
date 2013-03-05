Imports System
Imports System.IO
Imports System.Diagnostics
Imports System.Text
Imports System.Threading
Imports System.ComponentModel
Imports Microsoft.Win32
Imports Microsoft.VisualBasic
Imports System.Runtime.InteropServices

Public Class GoWrapper
    Private GoAgent As Process = New Process()
    Private originalPAC As String
    Private GoPAC As String = "http://127.0.0.1:8965/proxy.pac"
    Private GoWrapperTitle As String = "G翻牆懶人一键翻墙器"

    Private NoIE As Boolean = False
    Private NoPAC As Boolean = False
    Private GoAgentFileName As String = "python27.exe" '"D:\FreeGoAgent Archive\Gfanqiang\goagent-local\python27.exe"
    Private GoAgentArguments As String = "proxy.py" '"""D:\FreeGoAgent Archive\Gfanqiang\goagent-local\proxy.py"""
    Private GoWrapperHomePage As String = "https://gfangqiang.googlecode.com/svn/home.html"
    Private GoWrapperMessage As String = "message.txt"

    <DllImport("WININET.DLL")> Private Shared Function InternetSetOption(ByVal hInternet As IntPtr, ByVal dwOption As Integer, ByVal lpBuffer As IntPtr, ByVal lpdwBufferLength As Integer) As Boolean
    End Function

    Private Sub SetPAC(newPAC As String)
        Logger("Set PAC to """ + newPAC + """")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings", "AutoConfigURL", newPAC)
        InternetSetOption(0, 39, vbNull, vbNull)
    End Sub

    Private Sub HandleGoWrapperClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Logger("Program is closing...")
        Try
            If Not GoAgent.HasExited Then
                GoAgent.Kill()
            End If
        Catch ex As InvalidOperationException
        End Try
        If NoPAC = False Then
            SetPAC(originalPAC)
        End If
        Process.GetCurrentProcess.Kill()
    End Sub

    Private Sub HandleGoWrapperLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        Logger("GoWrapper Initializing...")
        InitBookmarkTree()
        Dim Arguments() As String, ArgumentsCount As Integer, CurrentArgument As String
        Arguments = System.Environment.GetCommandLineArgs
        For ArgumentsCount = 0 To UBound(Arguments)
            CurrentArgument = Arguments(ArgumentsCount).ToLower
            If CurrentArgument = "--noie" Then
                NoIE = True
                Logger("Mode: NoIE")
            ElseIf CurrentArgument = "--nopac" Then
                NoPAC = True
                Logger("Mode: NoPAC")
            ElseIf CurrentArgument.StartsWith("--filename=") Then
                GoAgentFileName = CurrentArgument.Replace("--filename=", "")
                Logger("GoAgent Filename:" + GoAgentFileName)
            ElseIf CurrentArgument.StartsWith("--arguments=") Then
                GoAgentArguments = CurrentArgument.Replace("--arguments=", "")
                Logger("GoAgent Arguments:" + GoAgentArguments)
            ElseIf CurrentArgument.StartsWith("--homepage=") Then
                GoWrapperHomePage = CurrentArgument.Replace("--homepage=", "")
                Logger("GoWrapper HomePage:" + GoWrapperHomePage)
            ElseIf CurrentArgument.StartsWith("--message=") Then
                GoWrapperMessage = CurrentArgument.Replace("--message=", "")
                Logger("GoWrapper Message: " + GoWrapperMessage)
            ElseIf CurrentArgument.StartsWith("--title=") Then
                GoWrapperTitle = CurrentArgument.Replace("--title=", "")
                Logger("GoWrapper Title: " + GoWrapperTitle)
            End If
        Next ArgumentsCount

        Me.Text += " - " + GoWrapperTitle
        StatusVersion.Text = "GoWrapper " + My.Application.Info.Version.ToString()

        If GoWrapperMessage IsNot Nothing Then
            If My.Computer.FileSystem.FileExists(GoWrapperMessage) Then
                Dim message() As String = My.Computer.FileSystem.ReadAllText(GoWrapperMessage).Split(Environment.NewLine)
                For Each line As String In message
                    Logger(line)
                Next
            End If
        End If

        If NoPAC = False Then
            originalPAC = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings", "AutoConfigURL", Nothing)
            If originalPAC Is Nothing Then
                originalPAC = ""
            End If

            Logger("Original PAC is """ + originalPAC + """")
            SetPAC(GoPAC)
        End If

        Try
            GoAgent.StartInfo.FileName = GoAgentFileName
            GoAgent.StartInfo.Arguments = GoAgentArguments
            GoAgent.StartInfo.UseShellExecute = False
            GoAgent.StartInfo.CreateNoWindow = True
            GoAgent.StartInfo.RedirectStandardOutput = True
            GoAgent.StartInfo.RedirectStandardError = True
            GoAgent.SynchronizingObject = outbox

            AddHandler GoAgent.OutputDataReceived, AddressOf OutputHandler
            AddHandler GoAgent.ErrorDataReceived, AddressOf OutputHandler

            GoAgent.Start()
            GoAgent.BeginOutputReadLine()
            GoAgent.BeginErrorReadLine()
        Catch ex As InvalidOperationException
            Logger("Exception:")
            Logger(ex.ToString())
        End Try

        If NoIE = False Then
            OpenURL(GoWrapperHomePage)
        End If

    End Sub

    Private Sub HandleGoWrapperResize(sender As Object, e As EventArgs) Handles Me.Resize
        outbox.Width = Width - 240
        outbox.Height = Height - 120
        BookmarkTree.Left = Width - 220
        BookmarkTree.Height = Height - 120
    End Sub

    Private Sub HandleNormalCloseRestorePAC(sender As Object, e As EventArgs) Handles Menu_NormalCloseRestorePAC.Click
        Close()
    End Sub

    Private Sub HandleNormalCloseClearPAC(sender As Object, e As EventArgs) Handles Menu_NormalCloseClearPAC.Click
        If NoPAC = False Then
            Logger("Setting originalPAC to Null String")
            originalPAC = ""
        End If
        Close()
    End Sub

    Private Shared Sub OutputHandler(sendingProcess As Object, outLine As DataReceivedEventArgs)
        If Not String.IsNullOrEmpty(outLine.Data) Then
            Console.WriteLine(outLine.Data + Environment.NewLine)
            GoWrapper.outbox.AppendText(outLine.Data + Environment.NewLine)
            GoWrapper.outbox.ScrollToCaret()

        End If
    End Sub

    Private Sub Logger(LogString As String)
        Me.outbox.AppendText("[GoWrapper] " + LogString + Environment.NewLine)
        Me.outbox.ScrollToCaret()
        Console.WriteLine(LogString)
    End Sub

    'Private Sub HandleForceClose(sender As Object, e As EventArgs) Handles ForceClose.Click
    '    Logger("Exit:" + vbTab + vbTab + "Force Exit!")
    '    Process.GetCurrentProcess.Kill()
    'End Sub

    Private Sub ShowAbout(sender As Object, e As EventArgs) Handles Menu_About.Click
        About.Show()
    End Sub

    Private Sub OpenURL(URL As String)
        System.Diagnostics.Process.Start("iexplore", URL)
    End Sub

    Private Sub Menu_Link_iFanQiang_Click(sender As Object, e As EventArgs)
        OpenURL("http://www.ifanqiang.com/")
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        OpenURL("http://www.facebook.com")
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        OpenURL("http://www.hkreporter.com")
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        OpenURL("http://www.ifanqiang.com")
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        OpenURL("http://www.youtube.com")
    End Sub

    Private Sub SayMovieToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SayMovieToolStripMenuItem.Click
        OpenURL("http://say-move.org/a/tw/")
    End Sub

    Private Sub ThisAVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThisAVToolStripMenuItem.Click
        OpenURL("http://thisav.com/")
    End Sub

    Private Sub InitBookmarkTree()

        Dim tNode As TreeNode
        tNode = BookmarkTree.Nodes.Add("推荐连接")

        Dim Vjmedia = BookmarkTree.Nodes(0).Nodes.Add("http://www.vjmedia.com.hk", "辅仁网", 7, 7)

        Dim IFQ = BookmarkTree.Nodes(0).Nodes.Add("http://www.ifanqiang.com", "爱翻墙网址导航", 1, 1)
        Dim Youtube = BookmarkTree.Nodes(0).Nodes.Add("https://www.youtube.com", "Youtube", 3, 3)

        Dim Facebook = BookmarkTree.Nodes(0).Nodes.Add("https://www.facebook.com", "Facebook", 2, 2)
        Facebook.Nodes.Add("https://www.facebook.com/neverforget8964", "毋忘六四", 2, 2)
        Facebook.Nodes.Add("https://www.facebook.com/groups/fanqianglab/?fref=ts", "翻墙科技研究中心", 2, 2)

        Dim Twitter = BookmarkTree.Nodes(0).Nodes.Add("https://www.twitter.com", "推特", 6, 6)
        Twitter.Nodes.Add("https://twitter.com/aiww", "艾未未", 6, 6)

        tNode.Expand()
    End Sub

    Private Sub BookmarkTree_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles BookmarkTree.NodeMouseDoubleClick
        OpenURL(e.Node.Name)
    End Sub
End Class