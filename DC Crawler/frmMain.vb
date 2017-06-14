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

    Public Const DCRecommand As String = "&exception_mode=recommend"

    Private Sub numStartPage_ValueChanged(sender As Object, e As EventArgs) Handles numStartPage.ValueChanged
        numLastPage.Minimum = numStartPage.Value
    End Sub

#Region "ListView Column Sorting"

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
                    Try
                        Return IIf(Convert.ToInt32(xText) >= Convert.ToInt32(yText), 1, -1) * IIf(Me.ascending, 1, -1)
                    Catch ex As Exception
                    End Try
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

        Dim columnsTrans As New List(Of ColHeader)
        For Each column As ColumnHeader In lvDC.Columns
            columnsTrans.Add(New ColHeader(column.Text, column.Width, column.TextAlign, True))
        Next
        lvDC.Columns.Clear()
        lvDC.Columns.AddRange(columnsTrans.ToArray)

        ListingGallery()

        bLoad.PerformClick()

    End Sub

#End Region

#Region "Get Gallery List"

    Public Const DCGallList As String = "onmouseover=""gallery_view\('(\w+)'\);""\>[\s\S]*?\<.*?\>(\w+)\<"
    Public Const DCGallListOther As String = "onmouseover\=""gallery_view\('(\w+)'\);""\>\s*(\w+)\<"

    Public Structure DCGallery
        Dim identification As String
        Dim name As String
    End Structure

    Public GallList As New SortedDictionary(Of String, DCGallery)

    Public Function DownloadURL(ByVal address_of_url As String) As String
        Dim wclient As New Net.WebClient()
        wclient.Encoding = System.Text.Encoding.UTF8
        Return wclient.DownloadString(address_of_url)
    End Function

    Private Sub ListingGallery()
        Dim html As String = DownloadURL("http://wstatic.dcinside.com/gallery/gallindex_iframe_new_gallery.html")

        Dim Matches As MatchCollection = Regex.Matches(html, DCGallList)
        For Each Match As Match In Matches
            Dim galls As DCGallery

            galls.identification = Match.Groups(1).Value
            galls.name = Match.Groups(2).Value.Trim

            If galls.name.Length <> 0 Then
                If galls.name(0) = "-"c Then
                    galls.name = galls.name.Remove(0, 1).Trim
                End If
                If galls.name <> "" AndAlso Not GallList.ContainsKey(galls.name) Then
                    GallList.Add(galls.name, galls)
                End If
            End If
        Next

        Dim Matches2 As MatchCollection = Regex.Matches(html, DCGallListOther)
        For Each Match As Match In Matches2
            Dim galls As DCGallery

            galls.identification = Match.Groups(1).Value
            galls.name = Match.Groups(2).Value.Trim

            If galls.name.Length <> 0 AndAlso galls.name <> "" AndAlso Not GallList.ContainsKey(galls.name) Then
                GallList.Add(galls.name, galls)
            End If
        Next

        For Each gall As KeyValuePair(Of String, DCGallery) In GallList
            cbId.AutoCompleteCustomSource.Add(gall.Value.name)
            cbId.Items.Add(gall.Value.name)
        Next
    End Sub

    Private Sub cbId_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbId.SelectedIndexChanged
        bLoad.PerformClick()
    End Sub

#End Region

#Region "Get Board"

    ' 1. Notice
    ' 2. Title [With Comments Count]
    ' 3. User Id
    ' 4. Author
    ' 5. Date
    ' 6. Clicks
    ' 7. Star
    Public Const DCMap As String = "notice"" >(\d+)<[\s\S]*?middle;"">(.*?)</a></td>[\s\S]*?user_id='(.*?)' user_name=""(.*?)""[\s\S]*?date"" title=""([\s\S]*?)"">.*?<[\s\S]*?hits"">(\d+)<[\s\S]*?hits"">(\d+)<"

    Public loadedId As String
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
        Dim userid As String
    End Structure

    Public Function GetLastPageFromId(id As String) As Integer
        Dim html As String = DownloadURL($"http://gall.dcinside.com/board/lists/?id={cbId.Text}&page=1")

        Dim Matches As MatchCollection = Regex.Matches(html, "&page=(\d+)"" class=""b_next""><span class=""arrow_2"">맨뒤")
        For Each Match As Match In Matches
            Return Match.Groups(1).Value
        Next
        Return 1
    End Function

    Private UserIdData As New Dictionary(Of Integer, String)

    Private Sub bLoad_Click(sender As Object, e As EventArgs) Handles bLoad.Click

        If pbStatus.Maximum = pbStatus.Value Then

            If Not GallList.ContainsKey(cbId.Text) Then
                MsgBox("존재하지 않는 갤러리입니다.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            UserIdData.Clear()
            loadedId = GallList(cbId.Text).identification
            author = tbAuthor.Text
            lvDC.Items.Clear()

            pbStatus.Maximum = numLastPage.Value - numStartPage.Value + 1
            pbStatus.Value = 0

            For i As Integer = numStartPage.Value To numLastPage.Value
                GetDCMapFromUrlAnsyc($"http://gall.dcinside.com/board/lists/?id={loadedId}&page={i}")
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
            Dim map As New DCMapStructure

            If author <> "" Then
                If Not Match.Groups(3).Value.ToUpper.Contains(author.ToUpper) Then
                    Continue For
                End If
            End If

            With Match
                map.notice = .Groups(1).Value
                map.title = .Groups(2).Value
                map.userid = .Groups(3).Value
                map.author = .Groups(4).Value
                map.dates = .Groups(5).Value.Substring(0, "0000.00.00 00:00".Length)
                map.clicks = .Groups(6).Value
                map.star = .Groups(7).Value
            End With

            If Match.Groups(0).Value.Contains("<img src='http://wstatic.dcinside.com/gallery/skin/gallog/g_default.gif") Then
                map.level = 1
                UserIdData.Add(map.notice, map.userid)
            ElseIf Match.Groups(0).Value.Contains("<img src='http://wstatic.dcinside.com/gallery/skin/gallog/g_fix.gif") Then
                map.level = 2
                UserIdData.Add(map.notice, map.userid)
            Else
                map.level = 0
            End If

            If map.title.Contains("</a>") Then
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

    Public Structure DCCommentStructure
        Dim author As String
        Dim comments As String
        Dim dates As String
        Dim level As Integer
        Dim userid As String
    End Structure

    Public Shared Function GetCommentsHtml(id As String, notice As String, page As String) As List(Of DCCommentStructure)
        Dim Result As New List(Of DCCommentStructure)
        Try
            Dim Data As String = Nothing
            Data += "id=" + id + "&no=" + notice + "&com_page=" + page + "&write=write"

            Dim Bytes As Byte() = Encoding.UTF8.GetBytes(Data)

            Dim Request As WebRequest

            Request = WebRequest.Create("http://m.dcinside.com/comment_more.php")
            Request.Method = "POST"
            Request.ContentType = "application/x-www-form-urlencoded"
            Request.ContentLength = Bytes.Length

            Dim Stream As Stream = Request.GetRequestStream()
            Stream.Write(Bytes, 0, Bytes.Length)
            Stream.Close()
            Stream.Dispose()

            Dim Response As WebResponse = Request.GetResponse
            Dim Reader As New StreamReader(Response.GetResponseStream())

            Dim HtmlPartial As String = Reader.ReadToEnd

            Dim Matches As MatchCollection = Regex.Matches(HtmlPartial, DCComment)
            For Each Match As Match In Matches
                Dim com As New DCCommentStructure
                With Match
                    com.author = .Groups(1).Value
                    com.comments = .Groups(2).Value
                    com.dates = .Groups(3).Value
                End With

                If com.author.Contains("<span class=""") Then
                    com.author = com.author.Substring(1)
                    com.author = com.author.Remove(com.author.IndexOf("]<span class=""")).Trim
                Else
                    com.author = com.author.Substring(com.author.IndexOf(""">[") + 3)
                    com.author = com.author.Remove(com.author.IndexOf("<img src="""))
                End If

                Dim tok = Function(ByVal x As String) As String
                              Dim pos As Integer = x.IndexOf("g_id=") + 5
                              Return x.Substring(pos, x.IndexOf(">[") - pos - 1)
                          End Function

                If Match.Groups(0).Value.Contains("/gallercon1.gif") Then
                    com.level = 1
                    com.userid = tok(Match.Groups(0).Value)
                ElseIf Match.Groups(0).Value.Contains("/gallercon.gif") Then
                    com.level = 2
                    com.userid = tok(Match.Groups(0).Value)
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
        Dim title As String = lvDC.SelectedItems(0).SubItems(1).Text
        Dim author As String = lvDC.SelectedItems(0).SubItems(2).Text
        Dim counts As Integer = Convert.ToInt32(lvDC.SelectedItems(0).SubItems(4).Text)
        Dim Result As New List(Of DCCommentStructure)

        If counts > 0 Then

            Dim page As String = 1

            Do
                Result.AddRange(GetCommentsHtml(loadedId, notice, page))
                counts -= replypage_max
                page += 1
            Loop While counts > 0

        End If

        Dim newfrm As New frmViewer($"http://gall.dcinside.com/board/view/?id={loadedId}&no={lvDC.SelectedItems(0).SubItems(0).Text}", title, author, Result)
        newfrm.Show()
        Exit Sub
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
        If e.KeyCode = Keys.F6 Then frmRankTotal.Show()
        If e.KeyCode = Keys.F7 Then frmData.Show()
        If e.KeyCode = Keys.Escape Then End
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        For Each i As ListViewItem In lvDC.SelectedItems
            Process.Start($"http://gall.dcinside.com/board/view/?id={loadedId}&no={lvDC.SelectedItems(0).SubItems(0).Text}")
            Exit Sub
        Next
    End Sub

    Private Sub ViewContentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewContentsToolStripMenuItem.Click
        For Each i As ListViewItem In lvDC.SelectedItems

            Dim notice As String = lvDC.SelectedItems(0).SubItems(0).Text
            Dim counts As Integer = Convert.ToInt32(lvDC.SelectedItems(0).SubItems(4).Text)
            Dim page As String = 1

            If counts > 0 Then
                Dim Result As New List(Of DCCommentStructure)

                Do
                    Result.AddRange(GetCommentsHtml(loadedId, notice, page))
                    counts -= replypage_max
                    page += 1
                Loop While counts > 0

                Dim newfrm As New frmComment(Result)
                newfrm.Show()
            End If

        Next
    End Sub

    Private Sub ViewUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewUserToolStripMenuItem.Click
        For Each i As ListViewItem In lvDC.SelectedItems

            Dim notice As String = lvDC.SelectedItems(0).SubItems(0).Text
            Dim author As String = lvDC.SelectedItems(0).SubItems(2).Text

            If UserIdData.ContainsKey(notice) Then
                Dim newfrm As New frmUser(UserIdData(notice), author)
                newfrm.Show()
            End If

        Next
    End Sub

End Class
