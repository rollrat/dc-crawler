<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFind
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFind))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbAuthor = New System.Windows.Forms.TextBox()
        Me.cbComment = New System.Windows.Forms.CheckBox()
        Me.cbBoard = New System.Windows.Forms.CheckBox()
        Me.lvResult = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.bStart = New System.Windows.Forms.Button()
        Me.bSave = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.numLastPage = New System.Windows.Forms.NumericUpDown()
        Me.numStartPage = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lPageRemain = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pbStatus = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lCommentRemain = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pbComment = New System.Windows.Forms.ToolStripProgressBar()
        Me.tbId = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tChkFinish = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.numIpFirst = New System.Windows.Forms.NumericUpDown()
        Me.numIpSecond = New System.Windows.Forms.NumericUpDown()
        Me.pAuthor = New System.Windows.Forms.RadioButton()
        Me.pIp = New System.Windows.Forms.RadioButton()
        CType(Me.numLastPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numStartPage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.numIpFirst, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numIpSecond, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(158, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Author :"
        '
        'tbAuthor
        '
        Me.tbAuthor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbAuthor.Location = New System.Drawing.Point(215, 6)
        Me.tbAuthor.Name = "tbAuthor"
        Me.tbAuthor.Size = New System.Drawing.Size(116, 23)
        Me.tbAuthor.TabIndex = 1
        Me.tbAuthor.Text = "yomiko"
        '
        'cbComment
        '
        Me.cbComment.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbComment.AutoSize = True
        Me.cbComment.Checked = True
        Me.cbComment.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbComment.Location = New System.Drawing.Point(805, 6)
        Me.cbComment.Name = "cbComment"
        Me.cbComment.Size = New System.Drawing.Size(80, 19)
        Me.cbComment.TabIndex = 6
        Me.cbComment.Text = "Comment"
        Me.cbComment.UseVisualStyleBackColor = True
        '
        'cbBoard
        '
        Me.cbBoard.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbBoard.AutoSize = True
        Me.cbBoard.Checked = True
        Me.cbBoard.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbBoard.Location = New System.Drawing.Point(891, 6)
        Me.cbBoard.Name = "cbBoard"
        Me.cbBoard.Size = New System.Drawing.Size(57, 19)
        Me.cbBoard.TabIndex = 7
        Me.cbBoard.Text = "Board"
        Me.cbBoard.UseVisualStyleBackColor = True
        '
        'lvResult
        '
        Me.lvResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvResult.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader5, Me.ColumnHeader4})
        Me.lvResult.FullRowSelect = True
        Me.lvResult.GridLines = True
        Me.lvResult.Location = New System.Drawing.Point(12, 35)
        Me.lvResult.MultiSelect = False
        Me.lvResult.Name = "lvResult"
        Me.lvResult.Size = New System.Drawing.Size(931, 332)
        Me.lvResult.TabIndex = 8
        Me.lvResult.UseCompatibleStateImageBehavior = False
        Me.lvResult.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Index"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Notice"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Title or Comment"
        Me.ColumnHeader3.Width = 495
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Author"
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader5.Width = 120
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Date"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader4.Width = 154
        '
        'bStart
        '
        Me.bStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bStart.Location = New System.Drawing.Point(815, 373)
        Me.bStart.Name = "bStart"
        Me.bStart.Size = New System.Drawing.Size(128, 30)
        Me.bStart.TabIndex = 9
        Me.bStart.Text = "Start"
        Me.bStart.UseVisualStyleBackColor = True
        '
        'bSave
        '
        Me.bSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bSave.Location = New System.Drawing.Point(12, 373)
        Me.bSave.Name = "bSave"
        Me.bSave.Size = New System.Drawing.Size(128, 30)
        Me.bSave.TabIndex = 10
        Me.bSave.Text = "Save"
        Me.bSave.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(657, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(15, 15)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "~"
        '
        'numLastPage
        '
        Me.numLastPage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numLastPage.Location = New System.Drawing.Point(678, 5)
        Me.numLastPage.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numLastPage.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numLastPage.Name = "numLastPage"
        Me.numLastPage.Size = New System.Drawing.Size(121, 23)
        Me.numLastPage.TabIndex = 13
        Me.numLastPage.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'numStartPage
        '
        Me.numStartPage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numStartPage.Location = New System.Drawing.Point(530, 5)
        Me.numStartPage.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numStartPage.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numStartPage.Name = "numStartPage"
        Me.numStartPage.Size = New System.Drawing.Size(121, 23)
        Me.numStartPage.TabIndex = 12
        Me.numStartPage.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(483, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 15)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Page : "
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lPageRemain, Me.pbStatus, Me.ToolStripStatusLabel2, Me.lCommentRemain, Me.pbComment})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 413)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(953, 22)
        Me.StatusStrip1.TabIndex = 15
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
        'tbId
        '
        Me.tbId.Location = New System.Drawing.Point(43, 6)
        Me.tbId.Name = "tbId"
        Me.tbId.Size = New System.Drawing.Size(109, 23)
        Me.tbId.TabIndex = 17
        Me.tbId.Text = "programming"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 15)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "id ="
        '
        'tChkFinish
        '
        Me.tChkFinish.Interval = 500
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(337, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 15)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "IP(2) :"
        '
        'numIpFirst
        '
        Me.numIpFirst.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numIpFirst.Location = New System.Drawing.Point(382, 6)
        Me.numIpFirst.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.numIpFirst.Name = "numIpFirst"
        Me.numIpFirst.Size = New System.Drawing.Size(46, 23)
        Me.numIpFirst.TabIndex = 19
        '
        'numIpSecond
        '
        Me.numIpSecond.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numIpSecond.Location = New System.Drawing.Point(434, 6)
        Me.numIpSecond.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.numIpSecond.Name = "numIpSecond"
        Me.numIpSecond.Size = New System.Drawing.Size(46, 23)
        Me.numIpSecond.TabIndex = 20
        '
        'pAuthor
        '
        Me.pAuthor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pAuthor.AutoSize = True
        Me.pAuthor.Checked = True
        Me.pAuthor.Location = New System.Drawing.Point(706, 379)
        Me.pAuthor.Name = "pAuthor"
        Me.pAuthor.Size = New System.Drawing.Size(62, 19)
        Me.pAuthor.TabIndex = 21
        Me.pAuthor.TabStop = True
        Me.pAuthor.Text = "Author"
        Me.pAuthor.UseVisualStyleBackColor = True
        '
        'pIp
        '
        Me.pIp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pIp.AutoSize = True
        Me.pIp.Location = New System.Drawing.Point(774, 379)
        Me.pIp.Name = "pIp"
        Me.pIp.Size = New System.Drawing.Size(35, 19)
        Me.pIp.TabIndex = 22
        Me.pIp.Text = "IP"
        Me.pIp.UseVisualStyleBackColor = True
        '
        'frmFind
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(953, 435)
        Me.Controls.Add(Me.pIp)
        Me.Controls.Add(Me.pAuthor)
        Me.Controls.Add(Me.numIpSecond)
        Me.Controls.Add(Me.numIpFirst)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbId)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.numLastPage)
        Me.Controls.Add(Me.numStartPage)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.bSave)
        Me.Controls.Add(Me.bStart)
        Me.Controls.Add(Me.lvResult)
        Me.Controls.Add(Me.cbBoard)
        Me.Controls.Add(Me.cbComment)
        Me.Controls.Add(Me.tbAuthor)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(969, 474)
        Me.Name = "frmFind"
        Me.Text = "DCC Author Finder"
        CType(Me.numLastPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numStartPage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.numIpFirst, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numIpSecond, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents tbAuthor As TextBox
    Friend WithEvents cbComment As CheckBox
    Friend WithEvents cbBoard As CheckBox
    Friend WithEvents lvResult As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents bStart As Button
    Friend WithEvents bSave As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents numLastPage As NumericUpDown
    Friend WithEvents numStartPage As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents pbStatus As ToolStripProgressBar
    Friend WithEvents tbId As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tChkFinish As Timer
    Friend WithEvents Label3 As Label
    Friend WithEvents numIpFirst As NumericUpDown
    Friend WithEvents numIpSecond As NumericUpDown
    Friend WithEvents pAuthor As RadioButton
    Friend WithEvents pIp As RadioButton
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents pbComment As ToolStripProgressBar
    Friend WithEvents lPageRemain As ToolStripStatusLabel
    Friend WithEvents lCommentRemain As ToolStripStatusLabel
End Class
