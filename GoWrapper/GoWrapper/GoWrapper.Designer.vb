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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GoWrapper))
        Me.outbox = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.工具ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_NormalCloseClearPAC = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_NormalCloseRestorePAC = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ForceClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.關於ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Link_iFanQiang = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_About = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'outbox
        '
        Me.outbox.Location = New System.Drawing.Point(12, 52)
        Me.outbox.Multiline = True
        Me.outbox.Name = "outbox"
        Me.outbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.outbox.Size = New System.Drawing.Size(600, 378)
        Me.outbox.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.工具ToolStripMenuItem, Me.關於ToolStripMenuItem, Me.Menu_About})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(624, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '工具ToolStripMenuItem
        '
        Me.工具ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_NormalCloseClearPAC, Me.Menu_NormalCloseRestorePAC, Me.ToolStripMenuItem2, Me.ForceClose})
        Me.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem"
        Me.工具ToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.工具ToolStripMenuItem.Text = "工具"
        '
        'Menu_NormalCloseClearPAC
        '
        Me.Menu_NormalCloseClearPAC.Name = "Menu_NormalCloseClearPAC"
        Me.Menu_NormalCloseClearPAC.Size = New System.Drawing.Size(215, 22)
        Me.Menu_NormalCloseClearPAC.Text = "正常退出並清除PAC"
        '
        'Menu_NormalCloseRestorePAC
        '
        Me.Menu_NormalCloseRestorePAC.Name = "Menu_NormalCloseRestorePAC"
        Me.Menu_NormalCloseRestorePAC.Size = New System.Drawing.Size(215, 22)
        Me.Menu_NormalCloseRestorePAC.Text = "正常退出並還原PAC(建議)"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Enabled = False
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(215, 22)
        Me.ToolStripMenuItem2.Text = "---"
        Me.ToolStripMenuItem2.Visible = False
        '
        'ForceClose
        '
        Me.ForceClose.Enabled = False
        Me.ForceClose.Name = "ForceClose"
        Me.ForceClose.Size = New System.Drawing.Size(215, 22)
        Me.ForceClose.Text = "強行退出"
        Me.ForceClose.Visible = False
        '
        '關於ToolStripMenuItem
        '
        Me.關於ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_Link_iFanQiang})
        Me.關於ToolStripMenuItem.Name = "關於ToolStripMenuItem"
        Me.關於ToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.關於ToolStripMenuItem.Text = "連結"
        '
        'Menu_Link_iFanQiang
        '
        Me.Menu_Link_iFanQiang.Name = "Menu_Link_iFanQiang"
        Me.Menu_Link_iFanQiang.Size = New System.Drawing.Size(163, 22)
        Me.Menu_Link_iFanQiang.Text = "愛翻牆 翻牆導航"
        '
        'Menu_About
        '
        Me.Menu_About.Name = "Menu_About"
        Me.Menu_About.Size = New System.Drawing.Size(44, 20)
        Me.Menu_About.Text = "關於"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStrip})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 420)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(624, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripButton4})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(624, 25)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'ToolStrip
        '
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(31, 17)
        Me.ToolStrip.Text = "Test"
        '
        'GoWrapper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 442)
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
    Friend WithEvents 關於ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Link_iFanQiang As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_About As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStripStatusLabel

End Class
