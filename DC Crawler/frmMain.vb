'/*************************************************************************
'
'   Copyright (C) 2015-2016. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions

Public Class frmMain

    ' Start 2015-12-31 17:45
    ' Last  2016-01-01 12:05

    Private Sub numStartPage_ValueChanged(sender As Object, e As EventArgs) Handles numStartPage.ValueChanged
        numLastPage.Minimum = numStartPage.Value
    End Sub

#Region "ListView Column Sorting"

    ' 이걸로 다 비교하면 쉽다.
    ' 날짜도 비교해주지 제목도 비교해주지 . 근데 "1 KB"이런건 못하니 예전엔 따로 만들어 줬지
    Declare Unicode Function StrCmpLogicalW Lib "shlwapi.dll" (ByVal s1 As String, ByVal s2 As String) As Integer

    Public Shared Function ComparePath(addr1 As String, addr2 As String) As Integer
        Return StrCmpLogicalW(addr1, addr2)
    End Function

    Public Class PathComparer
        Implements IComparer

        Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
            Return StrCmpLogicalW(x, y)
        End Function
    End Class
    Public Shared Function GetPathComparer() As IComparer
        Return CType(New PathComparer(), IComparer)
    End Function

    'https://msdn.microsoft.com/ko-kr/library/ms229643(v=vs.90).aspx
    Public Class SortWrapper
        Friend sortItem As ListViewItem
        Friend sortColumn As Integer

        Public Sub New(ByVal Item As ListViewItem, ByVal iColumn As Integer)
            sortItem = Item
            sortColumn = iColumn
        End Sub

        Public ReadOnly Property [Text]() As String
            Get
                Return sortItem.SubItems(sortColumn).Text
            End Get
        End Property

        Public Class SortComparer
            Implements IComparer
            Private ascending As Boolean

            Public Sub New(ByVal asc As Boolean)
                Me.ascending = asc
            End Sub

            Public Function [Compare](ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare

                If IsNothing(x) Or IsNothing(y) Then Return 0

                Dim xItem As SortWrapper = CType(x, SortWrapper)
                Dim yItem As SortWrapper = CType(y, SortWrapper)

                Dim xText As String = xItem.sortItem.SubItems(xItem.sortColumn).Text
                Dim yText As String = yItem.sortItem.SubItems(yItem.sortColumn).Text

                If IsNumeric(xText) AndAlso IsNumeric(yText) Then
                    Return IIf(Convert.ToInt32(xText) >= Convert.ToInt32(yText), 1, -1) * IIf(Me.ascending, 1, -1)
                End If

                Return ComparePath(xText, yText) * IIf(Me.ascending, 1, -1)
            End Function
        End Class
    End Class

    Public Class ColHeader
        Inherits ColumnHeader
        Public ascending As Boolean

        Public Sub New(ByVal [text] As String, ByVal width As Integer, ByVal align As HorizontalAlignment, ByVal asc As Boolean)
            Me.Text = [text]
            Me.Width = width
            Me.TextAlign = align
            Me.ascending = asc
        End Sub
    End Class

    Private Sub lvDC_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvDC.ColumnClick

        On Error Resume Next

        Dim clickedCol As ColHeader = CType(Me.lvDC.Columns(e.Column), ColHeader)
        clickedCol.ascending = Not clickedCol.ascending
        Dim numItems As Integer = Me.lvDC.Items.Count
        Me.lvDC.BeginUpdate()

        Dim SortArray As New ArrayList
        Dim i As Integer
        For i = 0 To numItems - 1
            SortArray.Add(New SortWrapper(Me.lvDC.Items(i), e.Column))
        Next i

        SortArray.Sort(0, SortArray.Count, New SortWrapper.SortComparer(clickedCol.ascending))

        Me.lvDC.Items.Clear()
        Dim z As Integer
        For z = 0 To numItems - 1
            Me.lvDC.Items.Add(CType(SortArray(z), SortWrapper).sortItem)
        Next z

        Me.lvDC.EndUpdate()

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' 노가다하기 싫어서 만들었다... 는 거짓말이고..
        ' 물론 노가다를 경험하고나서야 생각이 나 만들었다
        Dim columnsTrans As New List(Of ColHeader)
        For Each column As ColumnHeader In lvDC.Columns
            columnsTrans.Add(New ColHeader(column.Text, column.Width, column.TextAlign, True))
        Next
        lvDC.Columns.Clear()
        lvDC.Columns.AddRange(columnsTrans.ToArray)

    End Sub

#End Region

#Region "Get Board"

    ' 1. Notice
    ' 2. Title [With Comments Count]
    ' 3. Author
    ' 4. Date
    ' 5. Clicks
    ' 6. Star
    Public Const DCMap As String = "notice"" >(\d+)<[\s\S]*?middle;"">(.*?)</a></td>[\s\S]*?<span title='(.*?)'[\s\S]*?date"" title=""([\s\S]*?)"">.*?<[\s\S]*?hits"">(\d+)<[\s\S]*?hits"">(\d+)<"

    Dim loadedId As String
    Dim author As String

    Public Structure DCMapStructure
        Dim notice As Integer
        Dim title As String
        Dim comments As Integer
        Dim author As String
        Dim dates As String
        Dim clicks As Integer
        Dim star As Integer
        Dim level As Integer
    End Structure

    Private Sub bLoad_Click(sender As Object, e As EventArgs) Handles bLoad.Click

        ' 비동기문을 쓰기 때문에 여러번 버튼을 누르면 안된다.
        ' 뭐 달리 아는 방법도 없어서 이 방법을 이용했다. 비동기가 끝나면 프로그래스바의 값이 최댓값과 같아질 거니깐
        If pbStatus.Maximum = pbStatus.Value Then
            loadedId = tbId.Text
            author = tbAuthor.Text
            lvDC.Items.Clear()

            pbStatus.Maximum = numLastPage.Value - numStartPage.Value + 1
            pbStatus.Value = 0

            For i As Integer = numStartPage.Value To numLastPage.Value
                'If cbGaeNeum.Checked Then
                '    GetDCMapFromUrlAnsyc($"http://gall.dcinside.com/board/lists/?id={tbId.Text}&page={i}&exception_mode=recommend")
                'Else
                ' 가독성은 별반 차이 없는 것 같습니다.
                GetDCMapFromUrlAnsyc($"http://gall.dcinside.com/board/lists/?id={tbId.Text}&page={i}")

                ' 타이머로 바꾼다.
                'Threading.Thread.Sleep(numDelay.Validate)

                'End If
            Next
        End If
    End Sub

    Private Sub GetDCMapFromUrlAnsyc(ByVal addr As String)
        Dim wclient As New Net.WebClient()
        wclient.Encoding = System.Text.Encoding.UTF8
        AddHandler wclient.DownloadStringCompleted, AddressOf webClient_DownloadStringCompleted
        wclient.DownloadStringAsync(New Uri(addr))
    End Sub

    Private Sub webClient_DownloadStringCompleted(ByVal sender As Object, ByVal e As DownloadStringCompletedEventArgs)
        Dim Result As New List(Of DCMapStructure)
        Dim Matches As MatchCollection = Regex.Matches(e.Result, DCMap)
        For Each Match As Match In Matches
            Dim map As DCMapStructure

            If author <> "" Then
                If Not Match.Groups(3).Value.ToUpper.Contains(author.ToUpper) Then
                    Continue For
                End If
            End If

            With Match
                map.notice = .Groups(1).Value
                map.title = .Groups(2).Value
                map.author = .Groups(3).Value
                map.dates = .Groups(4).Value
                map.clicks = .Groups(5).Value
                map.star = .Groups(6).Value
            End With

            '' 고정닉에 특별한 별을 달아주자
            If Match.Groups(0).Value.Contains("<img src='http://wstatic.dcinside.com/gallery/skin/gallog/g_default.gif") Then
                ' 반고정닉
                'map.author = "☆|" & map.author & "|☆"
                map.level = 1
            ElseIf Match.Groups(0).Value.Contains("<img src='http://wstatic.dcinside.com/gallery/skin/gallog/g_fix.gif") Then
                ' 고정닉
                'map.author = "★|" & map.author & "|★"
                map.level = 2
            Else
                ' 유동닉
                map.level = 0
            End If

            If map.title.Contains("</a>") Then
                ' 오늘 알게된 가장 충격적인 사실은 Split가 Char단위로 문장을 끊는 다는 것이였다.
                ' 여태까지 그것도 모르고 잘 사용했던 나날을 돌아보니 무척 신기했다.
                map.comments = map.title.Split(New String() {"<em>["}, StringSplitOptions.None)(1).Split("]"c)(0).Split("/"c)(0)
                map.title = map.title.Split("</a>")(0)
            Else
                map.comments = 0
            End If
            Result.Add(map)
        Next
        For Each map As DCMapStructure In Result
            Dim lvi As ListViewItem = lvDC.Items.Add(New ListViewItem(New String() {
                                            map.notice,
                                            replace(map.title),
                                            map.author,
                                            map.dates,
                                            map.comments,
                                            map.clicks,
                                            map.star}))
            If map.level = 1 Then
                lvi.BackColor = Color.LightGray
            ElseIf map.level = 2 Then
                lvi.BackColor = Color.LightGoldenrodYellow
            End If
        Next
        pbStatus.Value += 1
    End Sub

    ' HTML 독립체 호환용 문자열 대체
    Public Shared Function replace(ByVal str As String) As String
        Dim strs As String = str
        Dim oj() As String = {"&nbsp;", "&amp;", "&quot;", "&lt;",
           "&gt;", "&reg;", "&copy;", "&bull;", "&trade;", "&#39;"}
        Dim kj() As String = {" ", "&", """", "<", ">", "Â®", "Â©", "â€¢", "â„¢", "'"}
        For i As Integer = 0 To oj.Length - 1
            strs = strs.Replace(oj(i), kj(i))
        Next
        Return strs
    End Function

#End Region

#Region "Comments"

    ' 1. Author
    ' 2. Comment
    ' 3. Date
    Public Const DCComment As String = "<p>(.*?)</p>[\s\S]*?m_list_text"">(.*?)<[\s\S]*?date"">(.*?)<"

    Public Const replypage_max As Integer = 100

    Public Structure DCCommenttructure
        Dim author As String
        Dim comments As String
        Dim dates As String
        Dim level As Integer
    End Structure

    Public Shared Function GetCommentsHtml(id As String, notice As String, page As String) As List(Of DCCommenttructure)
        Dim Result As New List(Of DCCommenttructure)
        Try
            Dim Data As String = Nothing
            Data += "id=" + id + "&no=" + notice + "&com_page=" + page + "&write=write"

            Dim Bytes As Byte() = Encoding.UTF8.GetBytes(Data)

            Dim Request As WebRequest
            '파폭 네트워크 탭에서 헤더를 볼 수 있다.
            'get 방식
            'm.dcinside.com/comment_more_new.php?id=programming&no=  &com_page=  &write=write
            'post 방식
            Request = WebRequest.Create("http://m.dcinside.com/comment_more.php")
            Request.Method = "POST"
            Request.ContentType = "application/x-www-form-urlencoded"
            Request.ContentLength = Bytes.Length

            Dim Stream As Stream = Request.GetRequestStream()
            Stream.Write(Bytes, 0, Bytes.Length)
            Stream.Close()

            Dim Response As WebResponse = Request.GetResponse
            Dim Reader As New StreamReader(Response.GetResponseStream())

            Dim HtmlPartial As String = Reader.ReadToEnd

            ' Parse Comment
            Dim Matches As MatchCollection = Regex.Matches(HtmlPartial, DCComment)
            For Each Match As Match In Matches
                Dim com As DCCommenttructure
                With Match
                    com.author = .Groups(1).Value
                    com.comments = .Groups(2).Value
                    com.dates = .Groups(3).Value
                End With

                ' 첫 번째 분기는 유동닉을 검출하기 위한 것이다
                If com.author.Contains("<span class=""") Then
                    ' 유동닉은 아이피를 같이 출력하기 때문에 구조가 고정닉과 다르다.
                    ' 그리고 오른쪽 끝에 공백이 생기더라.
                    com.author = com.author.Substring(1)
                    com.author = com.author.Remove(com.author.IndexOf("]<span class=""")).Trim
                Else
                    ' Q.Split는 문장단위로 끊는 거 아니였나요?
                    ' 네 아닙니다.
                    com.author = com.author.Substring(com.author.IndexOf(""">[") + 3)
                    com.author = com.author.Remove(com.author.IndexOf("<img src="""))
                End If

                If Match.Groups(0).Value.Contains("/gallercon1.gif") Then
                    ' 반고정닉
                    com.level = 1
                ElseIf Match.Groups(0).Value.Contains("/gallercon.gif") Then
                    ' 고정닉
                    com.level = 2
                Else
                    com.level = 0
                End If

                com.comments = replace(com.comments)
                Result.Add(com)
            Next

        Catch ex As Exception
        End Try
        Return Result
    End Function

    Private Sub lvDC_DoubleClick(sender As Object, e As EventArgs) Handles lvDC.DoubleClick

        Dim notice As String = lvDC.SelectedItems(0).SubItems(0).Text
        Dim counts As Integer = Convert.ToInt32(lvDC.SelectedItems(0).SubItems(4).Text)
        Dim page As String = 1

        If counts > 0 Then
            Dim Result As New List(Of DCCommenttructure)

            Do
                Result.AddRange(GetCommentsHtml(loadedId, notice, page))
                counts -= replypage_max
                page += 1
            Loop While counts > 0

            Dim newfrm As New frmComment(Result)
            newfrm.Show()
        End If

    End Sub

#End Region

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub

    Private Sub frmMain_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F2 Then frmFind.Show()
        If e.KeyCode = Keys.F3 Then frmJujak.Show()
        If e.KeyCode = Keys.F4 Then frmRank.Show()
        If e.KeyCode = Keys.F5 Then frmRankCom.Show()
        If e.KeyCode = Keys.Escape Then End
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        For Each i As ListViewItem In lvDC.SelectedItems
            Process.Start($"http://gall.dcinside.com/board/view/?id={loadedId}&no={lvDC.SelectedItems(0).SubItems(0).Text}")
            Exit Sub
        Next
    End Sub

End Class
