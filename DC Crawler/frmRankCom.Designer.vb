<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRankCom
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRankCom))
        Me.lvDC = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.numDelay = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.numLastPage = New System.Windows.Forms.NumericUpDown()
        Me.bLoad = New System.Windows.Forms.Button()
        Me.numStartPage = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbId = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lPageRemain = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pbStatus = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lCommentRemain = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pbComment = New System.Windows.Forms.ToolStripProgressBar()
        Me.tChkFinish = New System.Windows.Forms.Timer(Me.components)
        CType(Me.numDelay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numLastPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numStartPage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvDC
        '
        Me.lvDC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvDC.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader8, Me.ColumnHeader1, Me.ColumnHeader9, Me.ColumnHeader2, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.lvDC.FullRowSelect = True
        Me.lvDC.GridLines = True
        Me.lvDC.Location = New System.Drawing.Point(12, 38)
        Me.lvDC.Name = "lvDC"
        Me.lvDC.Size = New System.Drawing.Size(623, 262)
        Me.lvDC.TabIndex = 39
        Me.lvDC.UseCompatibleStateImageBehavior = False
        Me.lvDC.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Index"
        Me.ColumnHeader3.Width = 51
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Rank"
        Me.ColumnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader8.Width = 65
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Name"
        Me.ColumnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader1.Width = 238
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Count"
        Me.ColumnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader9.Width = 58
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "udong"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "halffix"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "fixed"
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'numDelay
        '
        Me.numDelay.Location = New System.Drawing.Point(457, 8)
        Me.numDelay.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.numDelay.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numDelay.Minimum = New Decimal(New Integer() {1500, 0, 0, 0})
        Me.numDelay.Name = "numDelay"
        Me.numDelay.Size = New System.Drawing.Size(64, 23)
        Me.numDelay.TabIndex = 37
        Me.numDelay.Value = New Decimal(New Integer() {1500, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(404, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 15)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "delay ="
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(294, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(15, 15)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "~"
        '
        'numLastPage
        '
        Me.numLastPage.Location = New System.Drawing.Point(315, 8)
        Me.numLastPage.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.numLastPage.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numLastPage.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numLastPage.Name = "numLastPage"
        Me.numLastPage.Size = New System.Drawing.Size(83, 23)
        Me.numLastPage.TabIndex = 34
        Me.numLastPage.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'bLoad
        '
        Me.bLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bLoad.Location = New System.Drawing.Point(527, 7)
        Me.bLoad.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bLoad.Name = "bLoad"
        Me.bLoad.Size = New System.Drawing.Size(108, 23)
        Me.bLoad.TabIndex = 33
        Me.bLoad.Text = "Start"
        Me.bLoad.UseVisualStyleBackColor = True
        '
        'numStartPage
        '
        Me.numStartPage.Location = New System.Drawing.Point(205, 8)
        Me.numStartPage.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.numStartPage.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numStartPage.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numStartPage.Name = "numStartPage"
        Me.numStartPage.Size = New System.Drawing.Size(83, 23)
        Me.numStartPage.TabIndex = 32
        Me.numStartPage.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(158, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 15)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "page ="
        '
        'tbId
        '
        Me.tbId.Location = New System.Drawing.Point(43, 8)
        Me.tbId.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbId.Name = "tbId"
        Me.tbId.Size = New System.Drawing.Size(109, 23)
        Me.tbId.TabIndex = 30
        Me.tbId.Text = "programming"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 15)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "id ="
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lPageRemain, Me.pbStatus, Me.ToolStripStatusLabel2, Me.lCommentRemain, Me.pbComment})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 311)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(647, 22)
        Me.StatusStrip1.TabIndex = 40
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
        'tChkFinish
        '
        Me.tChkFinish.Interval = 500
        '
        'frmRankCom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(647, 333)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.lvDC)
        Me.Controls.Add(Me.numDelay)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.numLastPage)
        Me.Controls.Add(Me.bLoad)
        Me.Controls.Add(Me.numStartPage)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbId)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MinimumSize = New System.Drawing.Size(663, 372)
        Me.Name = "frmRankCom"
        Me.Text = "Comment Ranking"
        CType(Me.numDelay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLastPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numStartPage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lvDC As ListView
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents numDelay As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents numLastPage As NumericUpDown
    Friend WithEvents bLoad As Button
    Friend WithEvents numStartPage As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents tbId As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents lPageRemain As ToolStripStatusLabel
    Friend WithEvents pbStatus As ToolStripProgressBar
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents lCommentRemain As ToolStripStatusLabel
    Friend WithEvents pbComment As ToolStripProgressBar
    Friend WithEvents tChkFinish As Timer
End Class
