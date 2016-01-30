'/*************************************************************************
'
'   Copyright (C) 2016. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Imports DC_Crawler.frmMain
Imports DC_Crawler.frmRank
Imports System.Text.RegularExpressions
Imports System.Net
Imports System.Text
Imports System.IO

Public Class frmRankTotal

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

    Private Sub frmRankCom_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim columnsTrans As New List(Of ColHeader)
        For Each column As ColumnHeader In lvDC.Columns
            columnsTrans.Add(New ColHeader(column.Text, column.Width, column.TextAlign, True))
        Next
        lvDC.Columns.Clear()
        lvDC.Columns.AddRange(columnsTrans.ToArray)

    End Sub

    Dim loadedIp As String
    Dim loadedId As String
    Dim startpage As Integer
    Dim lastpage As Integer
    Dim currentpage As Integer
    Dim commentcount As Integer
    Dim remainpage As Integer
    Dim i As Integer
    Dim lastwaiting As Boolean

    Public Structure DCTotlaRanking
        Dim board As Integer
        Dim comment As Integer
        Dim name As String
    End Structure

    Private lists0 As New Dictionary(Of String, DCTotlaRanking)
    Private lists1 As New Dictionary(Of String, DCTotlaRanking)
    Private lists2 As New Dictionary(Of String, DCTotlaRanking)

    Public listarray As DCRank()

    Private Const max_partition As Integer = 2

    Private Sub bLoad_Click(sender As Object, e As EventArgs) Handles bLoad.Click
        If pbStatus.Maximum = pbStatus.Value Then
            loadedId = tbId.Text

            pbStatus.Maximum = numLastPage.Value - numStartPage.Value + 1
            pbStatus.Value = 0
            i = 1

            startpage = numStartPage.Value
            currentpage = startpage
            lastpage = numLastPage.Value
            commentcount = 0
            remainpage = max_partition
            lastwaiting = False

            tChkFinish.Start()
        End If
    End Sub

    Private Sub tChkFinish_Tick(sender As Object, e As EventArgs) Handles tChkFinish.Tick
        If lastwaiting AndAlso commentcount <= 0 Then
            tChkFinish.Stop()
        End If
        If remainpage >= max_partition AndAlso commentcount <= 0 Then
            If currentpage + max_partition <= lastpage Then
                For i As Integer = currentpage To currentpage + max_partition - 1
                    GetDCMapFromUrlAnsyc($"http://gall.dcinside.com/board/lists/?id={tbId.Text}&page={i}")
                Next
                currentpage += max_partition
                remainpage = 0
            ElseIf lastwaiting = False Then
                For i As Integer = currentpage To lastpage
                    GetDCMapFromUrlAnsyc($"http://gall.dcinside.com/board/lists/?id={tbId.Text}&page={i}")
                Next
                lastwaiting = True
            End If
        End If
    End Sub

    Private Sub GetDCMapFromUrlAnsyc(ByVal addr As String)
        Dim wclient As New Net.WebClient()
        wclient.Encoding = System.Text.Encoding.UTF8
        AddHandler wclient.DownloadStringCompleted, AddressOf webClient_DownloadStringCompleted
        wclient.DownloadStringAsync(New Uri(addr))
    End Sub

    Private Function CutAuthor(ByVal author As String)
        If author.Length > 6 Then
            Return author.Substring(0, 6)
        Else
            Return author
        End If
    End Function

    Private Sub webClient_DownloadStringCompleted(ByVal sender As Object, ByVal e As DownloadStringCompletedEventArgs)
        Dim Result As New List(Of DCMapStructure)
        Dim Matches As MatchCollection = Regex.Matches(e.Result, DCMap)
        For Each Match As Match In Matches
            Dim map As DCMapStructure
            With Match
                map.notice = .Groups(1).Value
                map.title = .Groups(2).Value
                map.author = .Groups(3).Value
                map.dates = .Groups(4).Value.Substring(0, "0000.00.00 00:00".Length)
                map.clicks = .Groups(5).Value
                map.star = .Groups(6).Value
            End With
            If map.title.Contains("</a>") Then
                map.comments = map.title.Split(New String() {"<em>["}, StringSplitOptions.None)(1).Split("]"c)(0).Split("/"c)(0)
                map.title = map.title.Split("</a>")(0)
            Else
                map.comments = 0
            End If

            Dim tmp As DCTotlaRanking
            tmp.board = 0
            tmp.comment = 0
            tmp.name = map.author
            If Match.Groups(0).Value.Contains("<img src='http://wstatic.dcinside.com/gallery/skin/gallog/g_default.gif") Then
                map.level = 1
                If Not lists1.ContainsKey(CutAuthor(map.author)) Then
                    lists1.Add(CutAuthor(map.author), tmp)
                End If
                tmp = lists1(CutAuthor(map.author))
                If tmp.name <> map.author Then tmp.name = map.author
                tmp.board += 1
                lists1(CutAuthor(map.author)) = tmp
            ElseIf Match.Groups(0).Value.Contains("<img src='http://wstatic.dcinside.com/gallery/skin/gallog/g_fix.gif") Then
                map.level = 2
                If Not lists2.ContainsKey(CutAuthor(map.author)) Then
                    lists2.Add(CutAuthor(map.author), tmp)
                End If
                tmp = lists2(CutAuthor(map.author))
                If tmp.name <> map.author Then tmp.name = map.author
                tmp.board += 1
                lists2(CutAuthor(map.author)) = tmp
            Else
                map.level = 0
                If Not lists0.ContainsKey(CutAuthor(map.author)) Then
                    lists0.Add(CutAuthor(map.author), tmp)
                End If
                tmp = lists0(CutAuthor(map.author))
                If tmp.name <> map.author Then tmp.name = map.author
                tmp.board += 1
                lists0(CutAuthor(map.author)) = tmp
            End If

            Dim notice As String = map.notice
            Dim counts As Integer = map.comments
            Dim page As String = 1
            If counts > 0 Then
                commentcount += 1
                Do
                    pbComment.Maximum += 1
                    GetCommentsHtml(loadedId, notice, page)
                    counts -= replypage_max
                    page += 1
                Loop While counts > 0
            End If
        Next
        remainpage += 1
        pbStatus.Value += 1
        lPageRemain.Text = $"{pbStatus.Value}/{pbStatus.Maximum}"
        update_lv()
    End Sub

    Private Async Sub GetCommentsHtml(id As String, notice As String, page As String)
        Try
            Dim Result As New List(Of DCMapStructure)
            Dim Data As String = Nothing
            Data += "id=" + id + "&no=" + notice + "&com_page=" + page + "&write=write"

            Dim Bytes As Byte() = Encoding.UTF8.GetBytes(Data)

            Dim Request As WebRequest
            Request = WebRequest.Create("http://m.dcinside.com/comment_more.php")
            Request.Method = "POST"
            Request.ContentType = "application/x-www-form-urlencoded"
            Request.ContentLength = Bytes.Length

            Using Stream As Stream = Await Request.GetRequestStreamAsync()
                Stream.Write(Bytes, 0, Bytes.Length)
                Stream.Close()
            End Using

            Dim HtmlPartial As String = Nothing
            Dim Response As WebResponse = Await Request.GetResponseAsync
            Using Reader As New StreamReader(Response.GetResponseStream)
                HtmlPartial = Reader.ReadToEnd
            End Using

            Dim Matches As MatchCollection = Regex.Matches(HtmlPartial, DCComment)
            For Each Match As Match In Matches
                Dim com As DCMapStructure
                With Match
                    com.author = .Groups(1).Value
                    com.title = .Groups(2).Value
                    com.dates = .Groups(3).Value
                End With

                If com.author.Contains("<span class=""") Then
                    com.author = com.author.Substring(1)
                    com.author = com.author.Remove(com.author.IndexOf("]<span class=""")).Trim
                Else
                    com.author = com.author.Substring(com.author.IndexOf(""">[") + 3)
                    com.author = com.author.Remove(com.author.IndexOf("<img src="""))
                End If

                Dim tmp As DCTotlaRanking
                tmp.board = 0
                tmp.comment = 0
                tmp.name = com.author
                If Match.Groups(0).Value.Contains("/gallercon1.gif") Then
                    com.level = 1
                    If Not lists1.ContainsKey(CutAuthor(com.author)) Then
                        lists1.Add(CutAuthor(com.author), tmp)
                    End If
                    tmp = lists1(CutAuthor(com.author))
                    tmp.comment += 1
                    lists1(CutAuthor(com.author)) = tmp
                ElseIf Match.Groups(0).Value.Contains("/gallercon.gif") Then
                    com.level = 2
                    If Not lists2.ContainsKey(CutAuthor(com.author)) Then
                        lists2.Add(CutAuthor(com.author), tmp)
                    End If
                    tmp = lists2(CutAuthor(com.author))
                    tmp.comment += 1
                    lists2(CutAuthor(com.author)) = tmp
                Else
                    com.level = 0
                    If Not lists0.ContainsKey(CutAuthor(com.author)) Then
                        lists0.Add(CutAuthor(com.author), tmp)
                    End If
                    tmp = lists0(CutAuthor(com.author))
                    tmp.comment += 1
                    lists0(CutAuthor(com.author)) = tmp
                End If
            Next

        Catch ex As Exception
        End Try

        pbComment.Value += 1
        lCommentRemain.Text = $"{pbComment.Value}/{pbComment.Maximum}"
        commentcount -= 1
        update_lv()
    End Sub

    Private Sub update_lv()
        If pbStatus.Maximum = pbStatus.Value AndAlso pbComment.Maximum = pbComment.Value Then
            Dim list As New List(Of DCRank)
            Dim count As New List(Of Integer)
            Dim index As Integer = 1
            Dim pair As KeyValuePair(Of String, DCTotlaRanking)
            lvDC.Items.Clear()
            For Each pair In lists0
                Dim tmp As DCRank
                With tmp
                    .name = pair.Value.name
                    .level = 0
                    .count = pair.Value.board
                    .ccount = pair.Value.comment
                    .score = .count * 2.5 + .ccount * 1.5
                    .index = index
                End With
                list.Add(tmp)
                count.Add(tmp.score)
                index += 1
            Next
            For Each pair In lists1
                Dim tmp As DCRank
                With tmp
                    .name = pair.Value.name
                    .level = 1
                    .count = pair.Value.board
                    .ccount = pair.Value.comment
                    .score = .count * 2.5 + .ccount * 1.5
                    .index = index
                End With
                list.Add(tmp)
                count.Add(tmp.score)
                index += 1
            Next
            For Each pair In lists2
                Dim tmp As DCRank
                With tmp
                    .name = pair.Value.name
                    .level = 2
                    .count = pair.Value.board
                    .ccount = pair.Value.comment
                    .score = .count * 2.5 + .ccount * 1.5
                    .index = index
                End With
                list.Add(tmp)
                count.Add(tmp.score)
                index += 1
            Next
            listarray = list.ToArray
            Dim rank As Integer = 1
            Array.Sort(count.ToArray, listarray)
            Array.Reverse(listarray)
            Dim _0 As Integer = 1
            Dim _1 As Integer = 1
            Dim _2 As Integer = 1
            For Each i As DCRank In listarray
                Dim _a As String = ""
                Dim _b As String = ""
                Dim _c As String = ""
                If i.level = 1 Then : _b &= _1
                ElseIf i.level = 2 Then : _c &= _2
                Else : _a &= _0
                End If
                Dim lvi As ListViewItem = lvDC.Items.Add(New ListViewItem(New String() {
                                                i.index,
                                                rank,
                                                i.name,
                                                i.score,
                                                i.ccount,
                                                i.count,
                                                _a,
                                                _b,
                                                _c}))
                If i.level = 1 Then
                    lvi.BackColor = Color.LightGray
                    _1 += 1
                ElseIf i.level = 2 Then
                    lvi.BackColor = Color.LightGoldenrodYellow
                    _2 += 1
                Else
                    _0 += 1
                End If
                rank += 1
            Next
        End If
    End Sub

    Private Sub bExport_Click(sender As Object, e As EventArgs) Handles bExport.Click
        Dim newfrm As New frmRankExport(lists0, lists1, lists2)
        newfrm.Show()
    End Sub

End Class