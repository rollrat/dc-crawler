'/*************************************************************************
'
'   Copyright (C) 2016. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Imports System.Net
Imports System.Text.RegularExpressions
Imports DC_Crawler.frmMain

Public Class frmRank

    Private lists0 As New Dictionary(Of String, Integer)
    Private lists1 As New Dictionary(Of String, Integer)
    Private lists2 As New Dictionary(Of String, Integer)

    Dim loadedId As String

    Private Sub bLoad_Click(sender As Object, e As EventArgs) Handles bLoad.Click
        If pbStatus.Maximum = pbStatus.Value Then
            loadedId = tbId.Text
            lvDC.Items.Clear()

            pbStatus.Maximum = numLastPage.Value - numStartPage.Value + 1
            pbStatus.Value = 0

            For i As Integer = numStartPage.Value To numLastPage.Value
                GetDCMapFromUrlAnsyc($"http://gall.dcinside.com/board/lists/?id={tbId.Text}&page={i}")
            Next
        End If
    End Sub

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

    Private Sub GetDCMapFromUrlAnsyc(ByVal addr As String)
        Dim wclient As New Net.WebClient()
        wclient.Encoding = System.Text.Encoding.UTF8
        AddHandler wclient.DownloadStringCompleted, AddressOf webClient_DownloadStringCompleted
        wclient.DownloadStringAsync(New Uri(addr))
    End Sub

    Private Sub webClient_DownloadStringCompleted(ByVal sender As Object, ByVal e As DownloadStringCompletedEventArgs)
        Dim Matches As MatchCollection = Regex.Matches(e.Result, DCMap)
        For Each Match As Match In Matches
            Dim map As DCMapStructure

            With Match
                map.notice = .Groups(1).Value
                map.title = .Groups(2).Value
                map.author = .Groups(3).Value
                map.dates = .Groups(4).Value
                map.clicks = .Groups(5).Value
                map.star = .Groups(6).Value
            End With

            If Match.Groups(0).Value.Contains("<img src='http://wstatic.dcinside.com/gallery/skin/gallog/g_default.gif") Then
                map.level = 1
                If Not lists1.ContainsKey(map.author) Then
                    lists1.Add(map.author, 0)
                End If
                lists1(map.author) += 1
            ElseIf Match.Groups(0).Value.Contains("<img src='http://wstatic.dcinside.com/gallery/skin/gallog/g_fix.gif") Then
                map.level = 2
                If Not lists2.ContainsKey(map.author) Then
                    lists2.Add(map.author, 0)
                End If
                lists2(map.author) += 1
            Else
                map.level = 0
                If Not lists0.ContainsKey(map.author) Then
                    lists0.Add(map.author, 0)
                End If
                lists0(map.author) += 1
            End If

        Next
        pbStatus.Value += 1
        update_lv()
    End Sub

    Public Structure DCRank
        Dim name As String
        Dim level As Integer
        Dim count As Integer
        Dim index As Integer
    End Structure

    Private Sub update_lv()
        If pbStatus.Maximum = pbStatus.Value Then
            Dim list As New List(Of DCRank)
            Dim count As New List(Of Integer)
            Dim index As Integer = 1
            Dim pair As KeyValuePair(Of String, Integer)
            lvDC.Items.Clear()
            For Each pair In lists0
                Dim tmp As DCRank
                tmp.name = pair.Key
                tmp.level = 0
                tmp.count = pair.Value
                tmp.index = index
                List.Add(tmp)
                count.Add(tmp.count)
                index += 1
            Next
            For Each pair In lists1
                Dim tmp As DCRank
                tmp.name = pair.Key
                tmp.level = 1
                tmp.count = pair.Value
                tmp.index = index
                List.Add(tmp)
                count.Add(tmp.count)
                index += 1
            Next
            For Each pair In lists2
                Dim tmp As DCRank
                tmp.name = pair.Key
                tmp.level = 2
                tmp.count = pair.Value
                tmp.index = index
                List.Add(tmp)
                count.Add(tmp.count)
                index += 1
            Next
            Dim listarray = List.ToArray
            Dim rank As Integer = 1
            Array.Sort(count.ToArray, listarray)
            Array.Reverse(listarray)
            ' step -1도 되지만 귀찮다
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

    Private Sub frmRank_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim columnsTrans As New List(Of ColHeader)
        For Each column As ColumnHeader In lvDC.Columns
            columnsTrans.Add(New ColHeader(column.Text, column.Width, column.TextAlign, True))
        Next
        lvDC.Columns.Clear()
        lvDC.Columns.AddRange(columnsTrans.ToArray)

    End Sub

End Class