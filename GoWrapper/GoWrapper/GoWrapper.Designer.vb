<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GoWrapper
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GoWrapper))
        Me.outbox = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.工具ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_NormalCloseClearPAC = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_NormalCloseRestorePAC = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ForceClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_About = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.StatusVersion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.SayMovieToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ThisAVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.BookmarkTree = New System.Windows.Forms.TreeView()
        Me.BookmarkIcon = New System.Windows.Forms.ImageList(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'outbox
        '
        Me.outbox.Location = New System.Drawing.Point(12, 27)
        Me.outbox.MaxLength = 32768
        Me.outbox.Multiline = True
        Me.outbox.Name = "outbox"
        Me.outbox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.outbox.Size = New System.Drawing.Size(417, 378)
        Me.outbox.TabIndex = 0
        Me.outbox.WordWrap = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.工具ToolStripMenuItem, Me.Menu_About})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(704, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '工具ToolStripMenuItem
        '
        Me.工具ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_NormalCloseClearPAC, Me.Menu_NormalCloseRestorePAC, Me.ToolStripMenuItem2, Me.ForceClose})
        Me.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem"
        Me.工具ToolStripMenuItem.Size = New System.Drawing.Size(87, 20)
        Me.工具ToolStripMenuItem.Text = "GoWrapper"
        '
        'Menu_NormalCloseClearPAC
        '
        Me.Menu_NormalCloseClearPAC.Name = "Menu_NormalCloseClearPAC"
        Me.Menu_NormalCloseClearPAC.Size = New System.Drawing.Size(191, 22)
        Me.Menu_NormalCloseClearPAC.Text = "退出并清除PAC(修复)"
        '
        'Menu_NormalCloseRestorePAC
        '
        Me.Menu_NormalCloseRestorePAC.Name = "Menu_NormalCloseRestorePAC"
        Me.Menu_NormalCloseRestorePAC.Size = New System.Drawing.Size(191, 22)
        Me.Menu_NormalCloseRestorePAC.Text = "退出并还原PAC(建议)"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Enabled = False
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(191, 22)
        Me.ToolStripMenuItem2.Text = "---"
        Me.ToolStripMenuItem2.Visible = False
        '
        'ForceClose
        '
        Me.ForceClose.Enabled = False
        Me.ForceClose.Name = "ForceClose"
        Me.ForceClose.Size = New System.Drawing.Size(191, 22)
        Me.ForceClose.Text = "強行退出"
        Me.ForceClose.Visible = False
        '
        'Menu_About
        '
        Me.Menu_About.Name = "Menu_About"
        Me.Menu_About.Size = New System.Drawing.Size(44, 20)
        Me.Menu_About.Text = "关於"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusVersion})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 420)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(704, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusVersion
        '
        Me.StatusVersion.Name = "StatusVersion"
        Me.StatusVersion.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator1, Me.ToolStripDropDownButton1, Me.ToolStripLabel1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(704, 25)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        Me.ToolStrip1.Visible = False
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.GoWrapper.My.Resources.Resources.fb
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Facebook"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.GoWrapper.My.Resources.Resources.hkreporter
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "香港人网"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = Global.GoWrapper.My.Resources.Resources.ifq
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "爱翻墙"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = Global.GoWrapper.My.Resources.Resources.youtube
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "Youtube"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SayMovieToolStripMenuItem, Me.ThisAVToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = Global.GoWrapper.My.Resources.Resources.folder
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(29, 22)
        Me.ToolStripDropDownButton1.Text = "ToolStripDropDownButton1"
        '
        'SayMovieToolStripMenuItem
        '
        Me.SayMovieToolStripMenuItem.Name = "SayMovieToolStripMenuItem"
        Me.SayMovieToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.SayMovieToolStripMenuItem.Text = "SayMove"
        '
        'ThisAVToolStripMenuItem
        '
        Me.ThisAVToolStripMenuItem.Name = "ThisAVToolStripMenuItem"
        Me.ThisAVToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.ThisAVToolStripMenuItem.Text = "ThisAV"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(56, 22)
        Me.ToolStripLabel1.Text = "成人资源"
        '
        'BookmarkTree
        '
        Me.BookmarkTree.ImageIndex = 0
        Me.BookmarkTree.ImageList = Me.BookmarkIcon
        Me.BookmarkTree.Location = New System.Drawing.Point(435, 27)
        Me.BookmarkTree.Name = "BookmarkTree"
        Me.BookmarkTree.SelectedImageIndex = 0
        Me.BookmarkTree.Size = New System.Drawing.Size(190, 365)
        Me.BookmarkTree.TabIndex = 4
        '
        'BookmarkIcon
        '
        Me.BookmarkIcon.ImageStream = CType(resources.GetObject("BookmarkIcon.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.BookmarkIcon.TransparentColor = System.Drawing.Color.Transparent
        Me.BookmarkIcon.Images.SetKeyName(0, "folder.png")
        Me.BookmarkIcon.Images.SetKeyName(1, "ifq.png")
        Me.BookmarkIcon.Images.SetKeyName(2, "fb.png")
        Me.BookmarkIcon.Images.SetKeyName(3, "youtube.png")
        Me.BookmarkIcon.Images.SetKeyName(4, "hkreporter.png")
        Me.BookmarkIcon.Images.SetKeyName(5, "d100.ico")
        Me.BookmarkIcon.Images.SetKeyName(6, "twitter.png")
        Me.BookmarkIcon.Images.SetKeyName(7, "vjmedia.jpg")
        Me.BookmarkIcon.Images.SetKeyName(8, "favicon.png")
        Me.BookmarkIcon.Images.SetKeyName(9, "saymove.png")
        Me.BookmarkIcon.Images.SetKeyName(10, "thehousenews.jpg")
        Me.BookmarkIcon.Images.SetKeyName(11, "passiontimes.png")
        Me.BookmarkIcon.Images.SetKeyName(12, "inmediahk.gif")
        Me.BookmarkIcon.Images.SetKeyName(13, "weiquanwang.ico")
        Me.BookmarkIcon.Images.SetKeyName(14, "botanwang.png")
        Me.BookmarkIcon.Images.SetKeyName(15, "wikipedia.ico")
        Me.BookmarkIcon.Images.SetKeyName(16, "molihua.ico")
        '
        'GoWrapper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 442)
        Me.Controls.Add(Me.BookmarkTree)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.outbox)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "GoWrapper"
        Me.Text = "GoWrapper"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents outbox As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents 工具ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_NormalCloseClearPAC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_NormalCloseRestorePAC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ForceClose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_About As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusVersion As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents SayMovieToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ThisAVToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BookmarkTree As System.Windows.Forms.TreeView
    Friend WithEvents BookmarkIcon As System.Windows.Forms.ImageList

End Class
