<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmData
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmData))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.numLastPage = New System.Windows.Forms.NumericUpDown()
        Me.numStartPage = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbId = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bStart = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbAddr = New System.Windows.Forms.TextBox()
        Me.bFolderSet = New System.Windows.Forms.Button()
        Me.fbdSetting = New System.Windows.Forms.FolderBrowserDialog()
        Me.tChkFinish = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lPageRemain = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pbStatus = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lCommentRemain = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pbComment = New System.Windows.Forms.ToolStripProgressBar()
        CType(Me.numLastPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numStartPage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(401, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(214, 15)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Copyright (c) rollrat. All right reserved."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(291, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(15, 15)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "~"
        '
        'numLastPage
        '
        Me.numLastPage.Location = New System.Drawing.Point(312, 6)
        Me.numLastPage.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numLastPage.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numLastPage.Name = "numLastPage"
        Me.numLastPage.Size = New System.Drawing.Size(83, 23)
        Me.numLastPage.TabIndex = 14
        Me.numLastPage.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'numStartPage
        '
        Me.numStartPage.Location = New System.Drawing.Point(202, 6)
        Me.numStartPage.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numStartPage.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numStartPage.Name = "numStartPage"
        Me.numStartPage.Size = New System.Drawing.Size(83, 23)
        Me.numStartPage.TabIndex = 13
        Me.numStartPage.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(155, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 15)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "page ="
        '
        'tbId
        '
        Me.tbId.Location = New System.Drawing.Point(40, 6)
        Me.tbId.Name = "tbId"
        Me.tbId.Size = New System.Drawing.Size(109, 23)
        Me.tbId.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 15)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "id ="
        '
        'bStart
        '
        Me.bStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bStart.Location = New System.Drawing.Point(619, 4)
        Me.bStart.Name = "bStart"
        Me.bStart.Size = New System.Drawing.Size(125, 23)
        Me.bStart.TabIndex = 18
        Me.bStart.Text = "Start"
        Me.bStart.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 15)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "storage = "
        '
        'tbAddr
        '
        Me.tbAddr.Location = New System.Drawing.Point(77, 33)
        Me.tbAddr.Name = "tbAddr"
        Me.tbAddr.ReadOnly = True
        Me.tbAddr.Size = New System.Drawing.Size(536, 23)
        Me.tbAddr.TabIndex = 20
        '
        'bFolderSet
        '
        Me.bFolderSet.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bFolderSet.Location = New System.Drawing.Point(619, 33)
        Me.bFolderSet.Name = "bFolderSet"
        Me.bFolderSet.Size = New System.Drawing.Size(125, 23)
        Me.bFolderSet.TabIndex = 21
        Me.bFolderSet.Text = "Setting Folder"
        Me.bFolderSet.UseVisualStyleBackColor = True
        '
        'tChkFinish
        '
        Me.tChkFinish.Interval = 1000
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lPageRemain, Me.pbStatus, Me.ToolStripStatusLabel2, Me.lCommentRemain, Me.pbComment})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 66)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(756, 22)
        Me.StatusStrip1.TabIndex = 52
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(80, 17)
        Me.ToolStripStatusLabel1.Text = "Page Remain:"
        '
        'lPageRemain
        '
        Me.lPageRemain.Name = "lPageRemain"
        Me.lPageRemain.Size = New System.Drawing.Size(26, 17)
        Me.lPageRemain.Text = "0/0"
        '
        'pbStatus
        '
        Me.pbStatus.Name = "pbStatus"
        Me.pbStatus.Size = New System.Drawing.Size(100, 16)
        Me.pbStatus.Value = 100
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(108, 17)
        Me.ToolStripStatusLabel2.Text = "Comment Remain:"
        '
        'lCommentRemain
        '
        Me.lCommentRemain.Name = "lCommentRemain"
        Me.lCommentRemain.Size = New System.Drawing.Size(26, 17)
        Me.lCommentRemain.Text = "0/0"
        '
        'pbComment
        '
        Me.pbComment.Maximum = 0
        Me.pbComment.Name = "pbComment"
        Me.pbComment.Size = New System.Drawing.Size(100, 16)
        '
        'frmData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(756, 88)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.bFolderSet)
        Me.Controls.Add(Me.tbAddr)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.bStart)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.numLastPage)
        Me.Controls.Add(Me.numStartPage)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbId)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximumSize = New System.Drawing.Size(772, 127)
        Me.MinimumSize = New System.Drawing.Size(772, 127)
        Me.Name = "frmData"
        Me.Text = "DC Data"
        CType(Me.numLastPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numStartPage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents numLastPage As NumericUpDown
    Friend WithEvents numStartPage As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents tbId As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents bStart As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents tbAddr As TextBox
    Friend WithEvents bFolderSet As Button
    Friend WithEvents fbdSetting As FolderBrowserDialog
    Friend WithEvents tChkFinish As Timer
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents lPageRemain As ToolStripStatusLabel
    Friend WithEvents pbStatus As ToolStripProgressBar
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents lCommentRemain As ToolStripStatusLabel
    Friend WithEvents pbComment As ToolStripProgressBar
End Class
