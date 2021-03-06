﻿'/*************************************************************************
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
Imports DC_Crawler.frmMain

Public Class frmFind

    Private Sub lvResult_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvResult.ColumnClick

        On Error Resume Next

        Dim clickedCol As ColHeader = CType(Me.lvResult.Columns(e.Column), ColHeader)
        clickedCol.ascending = Not clickedCol.ascending
        Dim numItems As Integer = Me.lvResult.Items.Count
        Me.lvResult.BeginUpdate()

        Dim SortArray As New ArrayList
        Dim i As Integer
        For i = 0 To numItems - 1
            SortArray.Add(New SortWrapper(Me.lvResult.Items(i), e.Column))
        Next i

        SortArray.Sort(0, SortArray.Count, New SortWrapper.SortComparer(clickedCol.ascending))

        Me.lvResult.Items.Clear()
        Dim z As Integer
        For z = 0 To numItems - 1
            Me.lvResult.Items.Add(CType(SortArray(z), SortWrapper).sortItem)
        Next z

        Me.lvResult.EndUpdate()

    End Sub

    Private Sub numStartPage_ValueChanged(sender As Object, e As EventArgs) Handles numStartPage.ValueChanged
        numLastPage.Minimum = numStartPage.Value
    End Sub

    Private Sub frmFind_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim columnsTrans As New List(Of ColHeader)
        For Each column As ColumnHeader In lvResult.Columns
            columnsTrans.Add(New ColHeader(column.Text, column.Width, column.TextAlign, True))
        Next
        lvResult.Columns.Clear()
        lvResult.Columns.AddRange(columnsTrans.ToArray)

        tbId.Text = frmMain.loadedId
    End Sub

    Dim loadedIp As String
    Dim loadedId As String
    Dim startpage As Integer
    Dim lastpage As Integer
    Dim currentpage As Integer
    Dim commentcount As Integer
    Dim remainpage As Integer

    Public Const DCBoardIp As String = "<li class=""li_ip"">(\d+\.\d+)"
    Public Const DCCommentIp As String = "<span class=""m_list_text_bt2"">(\d+\.\d+)"

    Public activetime_board(24) As Integer
    Public activetime_comment(24) As Integer

    Private Const max_partition As Integer = 1

    Private Sub bStart_Click(sender As Object, e As EventArgs) Handles bStart.Click
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

            For i As Integer = 0 To 23
                activetime_board(i) = 0
                activetime_comment(i) = 0
            Next

            bTrace.Enabled = True

            If pAuthor.Checked Then
                pIp.Enabled = False
            Else
                loadedIp = numIpFirst.Value & "." & numIpSecond.Value
                pAuthor.Enabled = False
            End If
            tChkFinish.Start()
        End If
    End Sub

    Dim lastwaiting As Boolean

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

    Dim i As Integer

    Private Sub webClient_DownloadStringCompleted(ByVal sender As Object, ByVal e As DownloadStringCompletedEventArgs)
        Dim Result As New List(Of DCMapStructure)
        Dim Matches As MatchCollection = Regex.Matches(e.Result, DCMap)
        For Each Match As Match In Matches
            Dim map As DCMapStructure
            With Match
                map.notice = .Groups(1).Value
                map.title = .Groups(2).Value
                map.userid = .Groups(3).Value
                map.author = .Groups(4).Value
                map.dates = .Groups(5).Value.Substring(0, "0000.00.00 00:00".Length)
                map.clicks = .Groups(6).Value
                map.star = .Groups(7).Value
            End With

            If map.title.Contains("</a>") Then
                map.comments = map.title.Split(New String() {"<em>["}, StringSplitOptions.None)(1).Split("]"c)(0).Split("/"c)(0)
                map.title = map.title.Split("</a>")(0)
            Else
                map.comments = 0
            End If
            If pAuthor.Checked Then
                If Match.Groups(3).Value.ToUpper.Contains(tbAuthor.Text.ToUpper) AndAlso cbBoard.Checked Then
                    Result.Add(map)
                End If
            Else
                If Not (Match.Groups(0).Value.Contains("<img src='http://wstatic.dcinside.com/gallery/skin/gallog/g_default.gif") Or
                    Match.Groups(0).Value.Contains("<img src='http://wstatic.dcinside.com/gallery/skin/gallog/g_fix.gif")) Then
                    pbStatus.Maximum += 1
                    GetDCBoardIpCheckeFromUrlAnsyc($"http://gall.dcinside.com/board/view/?id={tbId.Text}&no={map.notice}&page={i}", map)
                End If
            End If

            Dim notice As String = map.notice
            Dim counts As Integer = map.comments
            Dim page As String = 1
            If counts > 0 AndAlso cbComment.Checked Then
                commentcount += 1
                Do
                    pbComment.Maximum += 1
                    GetCommentsHtml(loadedId, notice, page)
                    counts -= replypage_max
                    page += 1
                Loop While counts > 0
            End If
        Next
        For Each map As DCMapStructure In Result
            Dim lvi As ListViewItem = lvResult.Items.Add(New ListViewItem(New String() {
                                                i,
                                                map.notice,
                                                replace(map.title),
                                                map.author,
                                                map.dates}))
            activetime_board(map.dates.Substring("0000.00.00 ".Length, 2)) += 1
            If map.clicks = -1 Then
                lvi.BackColor = Color.Beige
            End If
            i += 1
        Next
        remainpage += 1
        On Error Resume Next
        pbStatus.Value += 1
        lPageRemain.Text = $"{pbStatus.Value}/{pbStatus.Maximum}"
    End Sub

    Private Sub GetDCBoardIpCheckeFromUrlAnsyc(ByVal addr As String, ByVal map As DCMapStructure)
        Dim wclient As New Net.WebClient()
        wclient.Encoding = System.Text.Encoding.UTF8
        AddHandler wclient.DownloadStringCompleted, AddressOf webClient1_DownloadStringCompleted
        wclient.DownloadStringAsync(New Uri(addr), map)
    End Sub

    Private Sub webClient1_DownloadStringCompleted(ByVal sender As Object, ByVal e As DownloadStringCompletedEventArgs)
        Dim Matches As MatchCollection = Regex.Matches(e.Result, DCBoardIp)
        For Each Match As Match In Matches
            If Match.Groups(1).Value = loadedIp Then
                lvResult.Items.Add(New ListViewItem(New String() {
                                                i,
                                                CType(e.UserState, DCMapStructure).notice,
                                                replace(CType(e.UserState, DCMapStructure).title),
                                                CType(e.UserState, DCMapStructure).author,
                                                CType(e.UserState, DCMapStructure).dates}))
                i += 1
            End If
            pbStatus.Value += 1
            lPageRemain.Text = $"{pbStatus.Value}/{pbStatus.Maximum}"
            Exit Sub
        Next
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
                Dim com As New DCMapStructure

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

                If pAuthor.Checked Then
                    If com.author.ToUpper.Contains(tbAuthor.Text.ToUpper) Then
                        com.notice = notice
                        com.clicks = -1
                        Result.Add(com)
                    End If
                Else
                    Dim ipMatch As MatchCollection = Regex.Matches(Match.Groups(0).Value, DCCommentIp)
                    For Each ip As Match In ipMatch
                        If ip.Groups(1).Value = loadedIp Then
                            com.notice = notice
                            com.clicks = -1
                            Result.Add(com)
                        End If
                        Exit For
                    Next
                End If
            Next

            For Each map As DCMapStructure In Result
                Dim lvi As ListViewItem = lvResult.Items.Add(New ListViewItem(New String() {
                                                    i,
                                                    map.notice,
                                                    replace(map.title),
                                                    map.author,
                                                    map.dates}))
                activetime_board(map.dates.Substring("0000.00.00 ".Length, 2)) += 1
                lvi.BackColor = Color.Beige
                i += 1
            Next
        Catch ex As Exception
        End Try

        pbComment.Value += 1
        lCommentRemain.Text = $"{pbComment.Value}/{pbComment.Maximum}"
        commentcount -= 1
    End Sub

    Private Sub lvResult_DoubleClick(sender As Object, e As EventArgs) Handles lvResult.DoubleClick
        For Each i As ListViewItem In lvResult.SelectedItems
            Process.Start($"http://gall.dcinside.com/board/view/?id={loadedId}&no={lvResult.SelectedItems(0).SubItems(1).Text}")
            Exit Sub
        Next
    End Sub

    Private Sub bSave_Click(sender As Object, e As EventArgs) Handles bSave.Click
        Dim builder As New StringBuilder
        For Each item As ListViewItem In lvResult.Items
            builder.Append(vbTab & item.SubItems(2).Text & vbCrLf & vbCrLf)
            builder.Append("Author: " & item.SubItems(3).Text & vbCrLf & vbCrLf)
            builder.Append("Type: ")
            If item.BackColor = Color.Beige Then
                builder.Append("Comment")
            Else
                builder.Append("Board")
            End If
            builder.Append(vbCrLf & "Date:" & item.SubItems(4).Text & vbCrLf)
            builder.Append("Address: " & $"http://gall.dcinside.com/board/view/?id={loadedId}&no={item.SubItems(1).Text}" & vbCrLf & vbCrLf & vbCrLf)
        Next

        Dim fileExists As Boolean
        fileExists = My.Computer.FileSystem.FileExists(System.IO.Directory.GetCurrentDirectory & "\Result_" & tbAuthor.Text & ".txt")
        If fileExists = True Then
            If MsgBox("이미 파일이 있습니다. 덮어쓰시겠습니까?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                My.Computer.FileSystem.DeleteFile(System.IO.Directory.GetCurrentDirectory & "\Result_" & tbAuthor.Text & ".txt",
                                FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            End If
        End If
        File.WriteAllText(System.IO.Directory.GetCurrentDirectory & "\Result_" & tbAuthor.Text & ".txt", builder.ToString)
    End Sub

    Private Sub bTrace_Click(sender As Object, e As EventArgs) Handles bTrace.Click
        frmActiveTime.Show()
    End Sub

    Public Function DownloadURL(ByVal address_of_url As String) As String
        Dim wclient As New Net.WebClient()
        wclient.Encoding = System.Text.Encoding.UTF8
        Return wclient.DownloadString(address_of_url)
    End Function

End Class