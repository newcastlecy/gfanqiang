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
    Private GoWrapperMessage As String = "data\message.txt"
    Private GoWrapperLove As String = "data\love.txt"

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
            ElseIf CurrentArgument.StartsWith("--love") Then
                GoWrapperMessage = CurrentArgument.Replace("--love=", "")
                Logger("GoWrapper Love: " + GoWrapperLove)
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

        If GoWrapperLove IsNot Nothing Then
            If My.Computer.FileSystem.FileExists(GoWrapperLove) Then
                Dim love As String = My.Computer.FileSystem.ReadAllText(GoWrapperLove)
                Me.Text = Me.Text + " : " + love
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
        outbox.Height = Height - 90
        BookmarkTree.Left = Width - 220
        BookmarkTree.Height = Me.Height - 90
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
            'If GoWrapper.outbox.Lines.Length > 100 Then
            'GoWrapper.outbox.Text = String.Join(vbNewLine, Split(GoWrapper.outbox.Text, vbNewLine), 1, Split(GoWrapper.outbox.Text, vbNewLine).Length - 1)
            'End If
            GoWrapper.outbox.AppendText(outLine.Data + Environment.NewLine)
            GoWrapper.outbox.ScrollToCaret()
        End If
    End Sub

    Private Sub Logger(LogString As String)
        'If outbox.Lines.Length > 100 Then
        'outbox.Text = String.Join(vbNewLine, Split(outbox.Text, vbNewLine), 1, Split(outbox.Text, vbNewLine).Length - 1)
        'End If
        Me.outbox.AppendText("[GoWrapper] " + LogString + Environment.NewLine)
        Me.outbox.ScrollToCaret()

    End Sub

    Private Sub ShowAbout(sender As Object, e As EventArgs) Handles Menu_About.Click
        About.Show()
    End Sub

    Private Sub OpenURL(URL As String)
        System.Diagnostics.Process.Start("iexplore", URL)
    End Sub

    Private Sub InitBookmarkTree()

        Dim tNode As TreeNode
        tNode = BookmarkTree.Nodes.Add("推荐连接")

        Dim IFQ = BookmarkTree.Nodes(0).Nodes.Add("http://www.ifanqiang.com", "爱翻墙网址导航", 1, 1)
        Dim Vjmedia = BookmarkTree.Nodes(0).Nodes.Add("http://www.vjmedia.com.hk", "辅仁网", 7, 7)
        Dim TheHouseNews = BookmarkTree.Nodes(0).Nodes.Add("http://www.thehousenews.com", "主场新闻", 10, 10)
        Dim PassionTimes = BookmarkTree.Nodes(0).Nodes.Add("http://www.passiontimes.hk", "热血时报", 11, 11)
        Dim InMediaHK = BookmarkTree.Nodes(0).Nodes.Add("http://www.inmediahk.net", "独立媒体", 12, 12)
        Dim HKReporter = BookmarkTree.Nodes(0).Nodes.Add("http://www.hkreporter.com", "香港人网", 4, 4)
        Dim BotanWang = BookmarkTree.Nodes(0).Nodes.Add("http://botanwang.com", "博谈网", 14, 14)
        Dim ISun = BookmarkTree.Nodes(0).Nodes.Add("http://www.isunaffairs.com/", "阳光时务", 17, 17)

        Dim Youtube = BookmarkTree.Nodes(0).Nodes.Add("https://www.youtube.com", "Youtube", 3, 3)

        Dim Facebook = BookmarkTree.Nodes(0).Nodes.Add("https://www.facebook.com", "Facebook", 2, 2)
        Facebook.Nodes.Add("https://www.facebook.com/neverforget8964", "毋忘六四", 2, 2)
        Facebook.Nodes.Add("https://www.facebook.com/groups/fanqianglab/?fref=ts", "翻墙科技研究中心", 2, 2)

        Dim Wiki = BookmarkTree.Nodes(0).Nodes.Add("https://zh.wikipedia.org", "维基百科", 15, 15)
        Wiki.Nodes.Add("http://zh.wikipedia.org/wiki/%E5%85%AD%E5%9B%9B%E4%BA%8B%E4%BB%B6", "8964", 15, 15)

        Dim Twitter = BookmarkTree.Nodes(0).Nodes.Add("https://www.twitter.com", "推特", 6, 6)
        Twitter.Nodes.Add("https://twitter.com/aiww", "艾未未", 6, 6)

        Dim Dir_Weiquan = BookmarkTree.Nodes(0).Nodes.Add("Null", "维权", 0, 0)
        Dir_Weiquan.Nodes.Add("http://www.weiquanwang.org/", "维权网", 13, 13)
        Dir_Weiquan.Nodes.Add("http://www.64tianwang.com/", "六四天网", 0, 0)

        Dim Dir_JinWwen = BookmarkTree.Nodes(0).Nodes.Add("Null", "中国禁闻", 0, 0)
        Dir_JinWwen.Nodes.Add("http://www.molihua.org/", "中国茉莉花革命", 16, 16)

        Dim Adult = BookmarkTree.Nodes(0).Nodes.Add("Null", "成人资源", 0, 0)
        Adult.Nodes.Add("https://www.thisav.com", "ThisAV", 8, 8)
        Adult.Nodes.Add("https://say-move.org/a/tw/", "SayMove", 9, 9)

        Dim Author = BookmarkTree.Nodes(0).Nodes.Add("Null", "联系作者", 0, 0)
        Author.Nodes.Add("https://www.facebook.com/sora8964", "羊羊", 2, 2)
        Author.Nodes.Add("https://www.facebook.com/why.yang", "杨匡", 2, 2)
        Author.Nodes.Add("http://t.qq.com/sora8964", "羊羊", 0, 0)
        Author.Nodes.Add("http://t.qq.com/fish039104", "杨匡", 0, 0)

        tNode.Expand()
    End Sub

    Private Sub BookmarkTree_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles BookmarkTree.NodeMouseDoubleClick
        If e.Node.Name <> "Null" Then
            OpenURL(e.Node.Name)
        End If
    End Sub
End Class