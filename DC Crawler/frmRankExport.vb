'/*************************************************************************
'
'   Copyright (C) 2015-2016. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Imports System.Text
Imports DC_Crawler.frmRank
Imports DC_Crawler.frmRankTotal

Public Class frmRankExport

    Private bexport_close As New Size(667, 242)
    Private bdetail_close As New Size(530, 242)
    Private bexport_open As New Size(667, 425)
    Private bdetail_open As New Size(530, 425)
    Private frm_expand As New Size(828, 496)
    Private frm_reduction As New Size(828, 313)

    Private Const basic_format As String = "#rank위 [#class] #username 쓴 글의 양 #board"

    Dim list_non_fixed As Dictionary(Of String, DCTotlaRanking)
    Dim list_half_fixed As Dictionary(Of String, DCTotlaRanking)
    Dim list_fixed As Dictionary(Of String, DCTotlaRanking)
    Public Sub New(list_non_fixed As Dictionary(Of String, DCTotlaRanking), list_half_fixed As Dictionary(Of String, DCTotlaRanking), list_fixed As Dictionary(Of String, DCTotlaRanking))

        ' 디자이너에서 이 호출이 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하세요.
        Me.list_non_fixed = list_non_fixed
        Me.list_half_fixed = list_half_fixed
        Me.list_fixed = list_fixed

    End Sub

    Dim detail_enable As Boolean = False
    Private Sub bDetail_Click(sender As Object, e As EventArgs) Handles bDetail.Click
        detail_enable = Not detail_enable
        If detail_enable Then
            bDetail.Location = bdetail_open
            bExport.Location = bexport_open
            rbSortManual.Enabled = True
            Me.Size = frm_expand
            bDetail.Text = "Detail <<"
        Else
            bDetail.Location = bdetail_close
            bExport.Location = bexport_close
            Me.Size = frm_reduction
            bDetail.Text = "Detail >>"
        End If
        gbDetail.Visible = detail_enable
    End Sub

    Private Sub rbSortManual_CheckedChanged(sender As Object, e As EventArgs) Handles rbSortManual.CheckedChanged
        If rbSortManual.Checked AndAlso Not detail_enable Then
            bDetail.PerformClick()
            bDetail.Enabled = False
        Else
            bDetail.Enabled = True
        End If
    End Sub
    Private Sub cbCommonFormat_CheckedChanged(sender As Object, e As EventArgs) Handles cbCommonFormat.CheckedChanged
        gbFormat.Enabled = cbCommonFormat.Checked
    End Sub
    Private Sub cbCommonScroe_CheckedChanged(sender As Object, e As EventArgs) Handles cbCommonScroe.CheckedChanged
        If Not cbCommonScroe.Checked AndAlso rbSortScore.Checked Then rbSortName.Checked = True
        rbSortScore.Enabled = cbCommonScroe.Checked
    End Sub
    Private Sub rbElem(sender As Object, e As EventArgs) Handles rbElemAll.CheckedChanged, rbElemComment.CheckedChanged, rbElemBoard.CheckedChanged
        rbSortBoard.Checked = rbElemBoard.Checked
        rbSortComment.Checked = rbElemComment.Checked
        rbSortScore.Checked = rbElemAll.Checked
    End Sub
    Private Sub cbUser(sender As Object, e As EventArgs) Handles cbUserFixed.CheckedChanged, cbUserHalfFixed.CheckedChanged, cbUserNonFixed.CheckedChanged
        tbFixed.Enabled = cbUserFixed.Checked
        tbHalfFixed.Enabled = cbUserHalfFixed.Checked
        tbNonFixed.Enabled = cbUserNonFixed.Checked
    End Sub

    Private Sub tbPreview_Click(sender As Object, e As EventArgs) Handles tbPreview.Click
        listarray = Nothing

        process_sort()
        process_namer()
        process_format()

        tbPreview.Clear()
        Dim strb As New StringBuilder
        For i As Integer = 0 To listarray.Length - 1
            strb.Append(printf(listarray(i), format, i + 1) & vbCrLf)
        Next
        tbPreview.Text = strb.ToString
        If tbPreview.Text = "" Then
            tbPreview.Text = "Error! Check print options."
        End If
    End Sub

    Private Function make_dcrank(name, level, count, ccount, score, index)
        Dim tmp As DCRank
        With tmp
            .name = name
            .level = level
            .count = count
            .ccount = ccount
            .score = score
            .index = index
        End With
        Return tmp
    End Function

    Private Function sorter_collector(temp As DCRank)
        If rbSortName.Checked Then
            Return temp.name
        ElseIf rbSortScore.Checked Then
            Return temp.score
        ElseIf rbSortComment.Checked Then
            Return temp.ccount
        ElseIf rbSortBoard.Checked Then
            Return temp.count
        End If
    End Function

    Dim listarray As DCRank()
    Dim namer As String()
    Dim format As String
    Private Sub process_sort()
        Dim list As New List(Of DCRank)
        Dim count As New List(Of Object)
        Dim index As Integer = 1
        If cbUserNonFixed.Checked Then
            For Each pair As KeyValuePair(Of String, DCTotlaRanking) In list_non_fixed
                Dim tmp As DCRank = make_dcrank(pair.Value.name, 0, pair.Value.board, pair.Value.comment, pair.Value.board * 2.5 + pair.Value.comment * 1.5, index)
                list.Add(tmp)
                count.Add(sorter_collector(tmp))
                index += 1
            Next
        End If
        If cbUserHalfFixed.Checked Then
            For Each pair As KeyValuePair(Of String, DCTotlaRanking) In list_half_fixed
                Dim tmp As DCRank = make_dcrank(pair.Value.name, 1, pair.Value.board, pair.Value.comment, pair.Value.board * 2.5 + pair.Value.comment * 1.5, index)
                list.Add(tmp)
                count.Add(sorter_collector(tmp))
                index += 1
            Next
        End If
        If cbUserFixed.Checked Then
            For Each pair As KeyValuePair(Of String, DCTotlaRanking) In list_fixed
                Dim tmp As DCRank = make_dcrank(pair.Value.name, 2, pair.Value.board, pair.Value.comment, pair.Value.board * 2.5 + pair.Value.comment * 1.5, index)
                list.Add(tmp)
                count.Add(sorter_collector(tmp))
                index += 1
            Next
        End If
        listarray = list.ToArray
        Array.Sort(count.ToArray, listarray)
        If Not rbSortName.Checked Then Array.Reverse(listarray)
    End Sub

    Private Sub process_namer()
        namer = New String() {tbNonFixed.Text, tbHalfFixed.Text, tbFixed.Text}
    End Sub

    Private Sub process_format()
        If cbCommonFormat.Checked Then format = cbbFormat.Text Else format = basic_format
    End Sub

    Private Function printf(data As DCRank, fmt As String, rank As Integer)
        Dim replacer As New StringBuilder(fmt)
        replacer.Replace("#rank", rank)
        replacer.Replace("#username", data.name)
        replacer.Replace("#score", data.score)
        replacer.Replace("#board", data.count)
        replacer.Replace("#comment", data.ccount)
        replacer.Replace("#class", namer(data.level))
        replacer.Replace("#tab", vbTab)
        Return replacer.ToString
    End Function

    Private Sub bExport_Click(sender As Object, e As EventArgs) Handles bExport.Click
        listarray = Nothing

        process_sort()
        process_namer()
        process_format()

        If saveFile.ShowDialog = DialogResult.OK Then
            Dim strb As New StringBuilder
            For i As Integer = 0 To listarray.Length - 1
                strb.Append(printf(listarray(i), format, i + 1) & vbCrLf)
            Next
            My.Computer.FileSystem.WriteAllText(saveFile.FileName, strb.ToString, True)
            MsgBox("Save Complete!", MsgBoxStyle.Information)
        End If
    End Sub

End Class