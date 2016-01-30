<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRankExport
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRankExport))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbElemBoard = New System.Windows.Forms.RadioButton()
        Me.rbElemComment = New System.Windows.Forms.RadioButton()
        Me.rbElemAll = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbUserFixed = New System.Windows.Forms.CheckBox()
        Me.cbUserHalfFixed = New System.Windows.Forms.CheckBox()
        Me.cbUserNonFixed = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbSortManual = New System.Windows.Forms.RadioButton()
        Me.rbSortAuto = New System.Windows.Forms.RadioButton()
        Me.gbFormat = New System.Windows.Forms.GroupBox()
        Me.cbbFormat = New System.Windows.Forms.ComboBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.cbCommonFormat = New System.Windows.Forms.CheckBox()
        Me.cbCommonScroe = New System.Windows.Forms.CheckBox()
        Me.bExport = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.tbPreview = New System.Windows.Forms.TextBox()
        Me.gbDetail = New System.Windows.Forms.GroupBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.rbSortName = New System.Windows.Forms.RadioButton()
        Me.rbSortBoard = New System.Windows.Forms.RadioButton()
        Me.rbSortComment = New System.Windows.Forms.RadioButton()
        Me.rbSortScore = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbFixed = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbHalfFixed = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbNonFixed = New System.Windows.Forms.TextBox()
        Me.bDetail = New System.Windows.Forms.Button()
        Me.saveFile = New System.Windows.Forms.SaveFileDialog()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.gbFormat.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.gbDetail.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbElemBoard)
        Me.GroupBox1.Controls.Add(Me.rbElemComment)
        Me.GroupBox1.Controls.Add(Me.rbElemAll)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(197, 49)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Apply Element"
        '
        'rbElemBoard
        '
        Me.rbElemBoard.AutoSize = True
        Me.rbElemBoard.Location = New System.Drawing.Point(136, 22)
        Me.rbElemBoard.Name = "rbElemBoard"
        Me.rbElemBoard.Size = New System.Drawing.Size(56, 19)
        Me.rbElemBoard.TabIndex = 2
        Me.rbElemBoard.Text = "Board"
        Me.rbElemBoard.UseVisualStyleBackColor = True
        '
        'rbElemComment
        '
        Me.rbElemComment.AutoSize = True
        Me.rbElemComment.Location = New System.Drawing.Point(51, 22)
        Me.rbElemComment.Name = "rbElemComment"
        Me.rbElemComment.Size = New System.Drawing.Size(79, 19)
        Me.rbElemComment.TabIndex = 1
        Me.rbElemComment.Text = "Comment"
        Me.rbElemComment.UseVisualStyleBackColor = True
        '
        'rbElemAll
        '
        Me.rbElemAll.AutoSize = True
        Me.rbElemAll.Checked = True
        Me.rbElemAll.Location = New System.Drawing.Point(6, 22)
        Me.rbElemAll.Name = "rbElemAll"
        Me.rbElemAll.Size = New System.Drawing.Size(39, 19)
        Me.rbElemAll.TabIndex = 0
        Me.rbElemAll.TabStop = True
        Me.rbElemAll.Text = "All"
        Me.rbElemAll.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbUserFixed)
        Me.GroupBox2.Controls.Add(Me.cbUserHalfFixed)
        Me.GroupBox2.Controls.Add(Me.cbUserNonFixed)
        Me.GroupBox2.Location = New System.Drawing.Point(215, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(243, 49)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Apply User"
        '
        'cbUserFixed
        '
        Me.cbUserFixed.AutoSize = True
        Me.cbUserFixed.Checked = True
        Me.cbUserFixed.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbUserFixed.Location = New System.Drawing.Point(177, 22)
        Me.cbUserFixed.Name = "cbUserFixed"
        Me.cbUserFixed.Size = New System.Drawing.Size(54, 19)
        Me.cbUserFixed.TabIndex = 2
        Me.cbUserFixed.Text = "Fixed"
        Me.cbUserFixed.UseVisualStyleBackColor = True
        '
        'cbUserHalfFixed
        '
        Me.cbUserHalfFixed.AutoSize = True
        Me.cbUserHalfFixed.Checked = True
        Me.cbUserHalfFixed.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbUserHalfFixed.Location = New System.Drawing.Point(92, 22)
        Me.cbUserHalfFixed.Name = "cbUserHalfFixed"
        Me.cbUserHalfFixed.Size = New System.Drawing.Size(79, 19)
        Me.cbUserHalfFixed.TabIndex = 1
        Me.cbUserHalfFixed.Text = "Half-fixed"
        Me.cbUserHalfFixed.UseVisualStyleBackColor = True
        '
        'cbUserNonFixed
        '
        Me.cbUserNonFixed.AutoSize = True
        Me.cbUserNonFixed.Checked = True
        Me.cbUserNonFixed.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbUserNonFixed.Location = New System.Drawing.Point(6, 22)
        Me.cbUserNonFixed.Name = "cbUserNonFixed"
        Me.cbUserNonFixed.Size = New System.Drawing.Size(80, 19)
        Me.cbUserNonFixed.TabIndex = 0
        Me.cbUserNonFixed.Text = "Non-fixed"
        Me.cbUserNonFixed.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbSortManual)
        Me.GroupBox3.Controls.Add(Me.rbSortAuto)
        Me.GroupBox3.Location = New System.Drawing.Point(661, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(136, 49)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Sort by"
        '
        'rbSortManual
        '
        Me.rbSortManual.AutoSize = True
        Me.rbSortManual.Location = New System.Drawing.Point(63, 21)
        Me.rbSortManual.Name = "rbSortManual"
        Me.rbSortManual.Size = New System.Drawing.Size(65, 19)
        Me.rbSortManual.TabIndex = 5
        Me.rbSortManual.Text = "Manual"
        Me.rbSortManual.UseVisualStyleBackColor = True
        '
        'rbSortAuto
        '
        Me.rbSortAuto.AutoSize = True
        Me.rbSortAuto.Checked = True
        Me.rbSortAuto.Location = New System.Drawing.Point(6, 21)
        Me.rbSortAuto.Name = "rbSortAuto"
        Me.rbSortAuto.Size = New System.Drawing.Size(51, 19)
        Me.rbSortAuto.TabIndex = 0
        Me.rbSortAuto.TabStop = True
        Me.rbSortAuto.Text = "Auto"
        Me.rbSortAuto.UseVisualStyleBackColor = True
        '
        'gbFormat
        '
        Me.gbFormat.Controls.Add(Me.cbbFormat)
        Me.gbFormat.Enabled = False
        Me.gbFormat.Location = New System.Drawing.Point(12, 67)
        Me.gbFormat.Name = "gbFormat"
        Me.gbFormat.Size = New System.Drawing.Size(785, 49)
        Me.gbFormat.TabIndex = 3
        Me.gbFormat.TabStop = False
        Me.gbFormat.Text = "Print Format"
        '
        'cbbFormat
        '
        Me.cbbFormat.FormattingEnabled = True
        Me.cbbFormat.Items.AddRange(New Object() {"#rank위 [#class] ""#username"" 쓴 글의 양 #board", "#rank위 [#class] ""#username"" 쓴 글의 양 #board 쓴 댓글의 양 #comment"})
        Me.cbbFormat.Location = New System.Drawing.Point(6, 20)
        Me.cbbFormat.Name = "cbbFormat"
        Me.cbbFormat.Size = New System.Drawing.Size(771, 23)
        Me.cbbFormat.TabIndex = 0
        Me.cbbFormat.Text = "#rank위 [#class] ""#username"" 쓴 글의 양 #board"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cbCommonFormat)
        Me.GroupBox5.Controls.Add(Me.cbCommonScroe)
        Me.GroupBox5.Location = New System.Drawing.Point(464, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(191, 49)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Common"
        '
        'cbCommonFormat
        '
        Me.cbCommonFormat.Checked = True
        Me.cbCommonFormat.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbCommonFormat.Location = New System.Drawing.Point(91, 22)
        Me.cbCommonFormat.Name = "cbCommonFormat"
        Me.cbCommonFormat.Size = New System.Drawing.Size(87, 19)
        Me.cbCommonFormat.TabIndex = 3
        Me.cbCommonFormat.Text = "Use Format"
        Me.cbCommonFormat.UseVisualStyleBackColor = True
        '
        'cbCommonScroe
        '
        Me.cbCommonScroe.AutoSize = True
        Me.cbCommonScroe.Checked = True
        Me.cbCommonScroe.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbCommonScroe.Location = New System.Drawing.Point(6, 22)
        Me.cbCommonScroe.Name = "cbCommonScroe"
        Me.cbCommonScroe.Size = New System.Drawing.Size(79, 19)
        Me.cbCommonScroe.TabIndex = 0
        Me.cbCommonScroe.Text = "Use Score"
        Me.cbCommonScroe.UseVisualStyleBackColor = True
        '
        'bExport
        '
        Me.bExport.Location = New System.Drawing.Point(667, 242)
        Me.bExport.Name = "bExport"
        Me.bExport.Size = New System.Drawing.Size(130, 25)
        Me.bExport.TabIndex = 6
        Me.bExport.Text = "Export"
        Me.bExport.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.tbPreview)
        Me.GroupBox6.Location = New System.Drawing.Point(12, 122)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(785, 114)
        Me.GroupBox6.TabIndex = 4
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Preview"
        '
        'tbPreview
        '
        Me.tbPreview.Font = New System.Drawing.Font("궁서", 11.0!)
        Me.tbPreview.Location = New System.Drawing.Point(6, 22)
        Me.tbPreview.Multiline = True
        Me.tbPreview.Name = "tbPreview"
        Me.tbPreview.ReadOnly = True
        Me.tbPreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbPreview.Size = New System.Drawing.Size(773, 86)
        Me.tbPreview.TabIndex = 0
        '
        'gbDetail
        '
        Me.gbDetail.Controls.Add(Me.GroupBox7)
        Me.gbDetail.Controls.Add(Me.GroupBox4)
        Me.gbDetail.Location = New System.Drawing.Point(12, 242)
        Me.gbDetail.Name = "gbDetail"
        Me.gbDetail.Size = New System.Drawing.Size(785, 177)
        Me.gbDetail.TabIndex = 7
        Me.gbDetail.TabStop = False
        Me.gbDetail.Text = "Detail"
        Me.gbDetail.Visible = False
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.rbSortName)
        Me.GroupBox7.Controls.Add(Me.rbSortBoard)
        Me.GroupBox7.Controls.Add(Me.rbSortComment)
        Me.GroupBox7.Controls.Add(Me.rbSortScore)
        Me.GroupBox7.Location = New System.Drawing.Point(198, 16)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(164, 155)
        Me.GroupBox7.TabIndex = 1
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Sort by"
        '
        'rbSortName
        '
        Me.rbSortName.AutoSize = True
        Me.rbSortName.Location = New System.Drawing.Point(21, 116)
        Me.rbSortName.Name = "rbSortName"
        Me.rbSortName.Size = New System.Drawing.Size(100, 19)
        Me.rbSortName.TabIndex = 3
        Me.rbSortName.Text = "Sort by Name"
        Me.rbSortName.UseVisualStyleBackColor = True
        '
        'rbSortBoard
        '
        Me.rbSortBoard.AutoSize = True
        Me.rbSortBoard.Location = New System.Drawing.Point(21, 87)
        Me.rbSortBoard.Name = "rbSortBoard"
        Me.rbSortBoard.Size = New System.Drawing.Size(99, 19)
        Me.rbSortBoard.TabIndex = 2
        Me.rbSortBoard.Text = "Sort by Board"
        Me.rbSortBoard.UseVisualStyleBackColor = True
        '
        'rbSortComment
        '
        Me.rbSortComment.AutoSize = True
        Me.rbSortComment.Location = New System.Drawing.Point(21, 58)
        Me.rbSortComment.Name = "rbSortComment"
        Me.rbSortComment.Size = New System.Drawing.Size(122, 19)
        Me.rbSortComment.TabIndex = 1
        Me.rbSortComment.Text = "Sort by Comment"
        Me.rbSortComment.UseVisualStyleBackColor = True
        '
        'rbSortScore
        '
        Me.rbSortScore.AutoSize = True
        Me.rbSortScore.Checked = True
        Me.rbSortScore.Location = New System.Drawing.Point(21, 29)
        Me.rbSortScore.Name = "rbSortScore"
        Me.rbSortScore.Size = New System.Drawing.Size(98, 19)
        Me.rbSortScore.TabIndex = 0
        Me.rbSortScore.TabStop = True
        Me.rbSortScore.Text = "Sort by Score"
        Me.rbSortScore.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.tbFixed)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.tbHalfFixed)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.tbNonFixed)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 16)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 155)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "User Class Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Fixed:"
        '
        'tbFixed
        '
        Me.tbFixed.Location = New System.Drawing.Point(76, 102)
        Me.tbFixed.Name = "tbFixed"
        Me.tbFixed.Size = New System.Drawing.Size(104, 23)
        Me.tbFixed.TabIndex = 4
        Me.tbFixed.Text = "고정닉"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Half-fixed:"
        '
        'tbHalfFixed
        '
        Me.tbHalfFixed.Location = New System.Drawing.Point(76, 73)
        Me.tbHalfFixed.Name = "tbHalfFixed"
        Me.tbHalfFixed.Size = New System.Drawing.Size(104, 23)
        Me.tbHalfFixed.TabIndex = 2
        Me.tbHalfFixed.Text = "반고정닉"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Non-fixed:"
        '
        'tbNonFixed
        '
        Me.tbNonFixed.Location = New System.Drawing.Point(76, 44)
        Me.tbNonFixed.Name = "tbNonFixed"
        Me.tbNonFixed.Size = New System.Drawing.Size(104, 23)
        Me.tbNonFixed.TabIndex = 0
        Me.tbNonFixed.Text = "유동닉"
        '
        'bDetail
        '
        Me.bDetail.Location = New System.Drawing.Point(530, 242)
        Me.bDetail.Name = "bDetail"
        Me.bDetail.Size = New System.Drawing.Size(131, 24)
        Me.bDetail.TabIndex = 8
        Me.bDetail.Text = "Detail >>"
        Me.bDetail.UseVisualStyleBackColor = True
        '
        'saveFile
        '
        Me.saveFile.FileName = "result.txt"
        Me.saveFile.Filter = "*.txt|Text File"
        '
        'frmRankExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(812, 274)
        Me.Controls.Add(Me.bDetail)
        Me.Controls.Add(Me.bExport)
        Me.Controls.Add(Me.gbDetail)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.gbFormat)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRankExport"
        Me.Text = "Export Manager"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.gbFormat.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.gbDetail.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbElemBoard As RadioButton
    Friend WithEvents rbElemComment As RadioButton
    Friend WithEvents rbElemAll As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cbUserFixed As CheckBox
    Friend WithEvents cbUserHalfFixed As CheckBox
    Friend WithEvents cbUserNonFixed As CheckBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents gbFormat As GroupBox
    Friend WithEvents cbbFormat As ComboBox
    Friend WithEvents rbSortManual As RadioButton
    Friend WithEvents rbSortAuto As RadioButton
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents cbCommonFormat As CheckBox
    Friend WithEvents cbCommonScroe As CheckBox
    Friend WithEvents bExport As Button
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents tbPreview As TextBox
    Friend WithEvents gbDetail As GroupBox
    Friend WithEvents bDetail As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tbFixed As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tbHalfFixed As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tbNonFixed As TextBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents rbSortBoard As RadioButton
    Friend WithEvents rbSortComment As RadioButton
    Friend WithEvents rbSortScore As RadioButton
    Friend WithEvents rbSortName As RadioButton
    Friend WithEvents saveFile As SaveFileDialog
End Class
