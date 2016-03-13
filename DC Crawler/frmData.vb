'/*************************************************************************
'
'   Copyright (C) 2016. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions

Public Class frmData

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbAddr.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\DC-Data"
        numLastPage.Value = GetLastPageFromId(tbId.Text)
    End Sub

    Private Sub CreateFolderUnderExist(addr As String)
        Dim folderExists As Boolean
        folderExists = My.Computer.FileSystem.DirectoryExists(addr)
        If Not folderExists Then
            System.IO.Directory.CreateDirectory(addr)
        End If
    End Sub

    Private Sub CreateTextFile(addr As String, text As String)
        My.Computer.FileSystem.WriteAllText(addr, text, True)

    End Sub

    Private Sub bFolderSet_Click(sender As Object, e As EventArgs) Handles bFolderSet.Click
        If fbdSetting.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            tbAddr.Text = fbdSetting.SelectedPath & "DC-Data"
        End If
    End Sub

    Private Sub numStartPage_ValueChanged(sender As Object, e As EventArgs) Handles numStartPage.ValueChanged
        numLastPage.Minimum = numStartPage.Value
    End Sub

    Public Const DCMap As String = "notice"" >(\d+)<[\s\S]*?middle;"">(.*?)</a></td>[\s\S]*?<span title='(.*?)'[\s\S]*?date"" title=""([\s\S]*?)"">.*?<[\s\S]*?hits"">(\d+)<[\s\S]*?hits"">(\d+)<"
    Public Const DCComment As String = "<p>(.*?)</p>[\s\S]*?m_list_text"">(.*?)<[\s\S]*?date"">(.*?)<"

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

    Public board_data As New List(Of DCMapStructure)
    Public comment_data As New List(Of DCMapStructure)

    Dim loadedId As String
    Dim lastpage As Integer
    Dim currentpage As Integer
    Dim commentcount As Integer
    Dim remainpage As Integer
    Dim lastwaiting As Boolean

    Public Const replypage_max As Integer = 100
    Public Const max_partition As Integer = 50

    Private Sub bStart_Click(sender As Object, e As EventArgs) Handles bStart.Click
        CreateFolderUnderExist(tbAddr.Text)
        If pbStatus.Maximum = pbStatus.Value Then
            loadedId = tbId.Text

            pbStatus.Maximum = numLastPage.Value - numStartPage.Value + 1
            pbStatus.Value = 0

            currentpage = numStartPage.Value
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
                    GetDCMapFromUrlAnsyc(i)
                Next
                currentpage += max_partition
                remainpage = 0
            ElseIf lastwaiting = False Then
                For i As Integer = currentpage To lastpage
                    GetDCMapFromUrlAnsyc(i)
                Next
                lastwaiting = True
            End If
        End If
    End Sub

    Private Sub GetDCMapFromUrlAnsyc(i As Integer)
        Dim wclient As New Net.WebClient()
        wclient.Encoding = System.Text.Encoding.UTF8
        AddHandler wclient.DownloadStringCompleted, AddressOf webClient_DownloadStringCompleted
        wclient.DownloadStringAsync(New Uri($"http://gall.dcinside.com/board/lists/?id={tbId.Text}&page={i}"), i)
    End Sub

    Private Sub webClient_DownloadStringCompleted(ByVal sender As Object, ByVal e As DownloadStringCompletedEventArgs)
        Try
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

                If Match.Groups(0).Value.Contains("<img src='http://wstatic.dcinside.com/gallery/skin/gallog/g_default.gif") Then
                    map.level = 1
                ElseIf Match.Groups(0).Value.Contains("<img src='http://wstatic.dcinside.com/gallery/skin/gallog/g_fix.gif") Then
                    map.level = 2
                Else
                    map.level = 0
                End If

                If map.title.Contains("</a>") Then
                    map.comments = map.title.Split(New String() {"<em>["}, StringSplitOptions.None)(1).Split("]"c)(0).Split("/"c)(0)
                    map.title = map.title.Split("</a>")(0)
                Else
                    map.comments = 0
                End If
                map.title = replace(map.title)

                Dim foldername As String = tbAddr.Text & "\" & tbId.Text & "\" & map.dates.Substring(0, "0000.00.00".Length).Replace(".", "\") & "\" & map.notice
                CreateFolderUnderExist(foldername)

                CreateTextFile(foldername & "\notice", map.title & vbCrLf & map.author & vbCrLf & map.dates & vbCrLf & map.clicks & vbCrLf & map.star & vbCrLf & map.level)

                Dim notice As String = map.notice
                Dim counts As Integer = map.comments
                Dim page As String = 1
                If counts > 0 Then
                    commentcount += 1
                    Do
                        pbComment.Maximum += 1
                        GetCommentsHtml(foldername, loadedId, notice, page)
                        counts -= replypage_max
                        page += 1
                    Loop While counts > 0
                End If
            Next

        Catch ex As Exception
        End Try

        remainpage += 1
        pbStatus.Value += 1
        lPageRemain.Text = $"{pbStatus.Value}/{pbStatus.Maximum}"
    End Sub

    Private Async Sub GetCommentsHtml(addr As String, id As String, notice As String, page As String)
        Try
            Dim Result As New List(Of DCMapStructure)
            Dim Data As String = Nothing
            Data += $"id={id}&no={notice}&comment_page={page}"

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
            Dim CommentData As New StringBuilder
            For Each Match As Match In Matches
                Dim com As DCMapStructure
                com.notice = notice

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

                If Match.Groups(0).Value.Contains("/gallercon1.gif") Then
                    com.level = 1
                ElseIf Match.Groups(0).Value.Contains("/gallercon.gif") Then
                    com.level = 2
                Else
                    com.level = 0
                End If

                CommentData.Append(com.author & "|#|" & com.title & "|#|" & com.dates & "|#|" & com.level & vbCrLf)
            Next

            CreateTextFile(addr & "\comment", CommentData.ToString)

        Catch ex As Exception
        End Try

        pbComment.Value += 1
        lCommentRemain.Text = $"{pbComment.Value}/{pbComment.Maximum}"
        commentcount -= 1
    End Sub

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

    Public Function DownloadURL(ByVal address_of_url As String) As String
        Dim wclient As New Net.WebClient()
        wclient.Encoding = System.Text.Encoding.UTF8
        Return wclient.DownloadString(address_of_url)
    End Function

    Public Function GetLastPageFromId(id As String) As Integer
        Dim html As String = DownloadURL($"http://gall.dcinside.com/board/lists/?id={tbId.Text}&page=1")

        Dim Matches As MatchCollection = Regex.Matches(html, "&page=(\d+)"" class=""b_next""><span class=""arrow_2"">맨뒤")
        For Each Match As Match In Matches
            Return Match.Groups(1).Value
        Next
        Return 1
    End Function

    Private Sub tbId_TextChanged(sender As Object, e As EventArgs) Handles tbId.TextChanged
        numLastPage.Value = GetLastPageFromId(tbId.Text)
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub

End Class
