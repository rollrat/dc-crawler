'/*************************************************************************
'
'   Copyright (C) 2015-2016. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Public Class frmActiveTime

    Private Sub frmActiveTime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As Integer
        Dim totals(24) As Integer
        For i As Integer = 0 To 23
            Dim k As Integer = frmFind.activetime_board(i) + frmFind.activetime_comment(i)
            total += k
            totals(i) = k
        Next
        pbTotal1.Maximum = total
        pbTotal2.Maximum = total
        pbTotal3.Maximum = total
        pbTotal4.Maximum = total
        pbTotal5.Maximum = total
        pbTotal6.Maximum = total
        pbTotal7.Maximum = total
        pbTotal8.Maximum = total
        pbTotal9.Maximum = total
        pbTotal10.Maximum = total
        pbTotal11.Maximum = total
        pbTotal12.Maximum = total
        pbTotal13.Maximum = total
        pbTotal14.Maximum = total
        pbTotal15.Maximum = total
        pbTotal16.Maximum = total
        pbTotal17.Maximum = total
        pbTotal18.Maximum = total
        pbTotal19.Maximum = total
        pbTotal20.Maximum = total
        pbTotal21.Maximum = total
        pbTotal22.Maximum = total
        pbTotal23.Maximum = total
        pbTotal24.Maximum = total

        pbTotal1.Value = totals(0)
        pbTotal2.Value = totals(1)
        pbTotal3.Value = totals(2)
        pbTotal4.Value = totals(3)
        pbTotal5.Value = totals(4)
        pbTotal6.Value = totals(5)
        pbTotal7.Value = totals(6)
        pbTotal8.Value = totals(7)
        pbTotal9.Value = totals(8)
        pbTotal10.Value = totals(9)
        pbTotal11.Value = totals(10)
        pbTotal12.Value = totals(11)
        pbTotal13.Value = totals(12)
        pbTotal14.Value = totals(13)
        pbTotal15.Value = totals(14)
        pbTotal16.Value = totals(15)
        pbTotal17.Value = totals(16)
        pbTotal18.Value = totals(17)
        pbTotal19.Value = totals(18)
        pbTotal20.Value = totals(19)
        pbTotal21.Value = totals(20)
        pbTotal22.Value = totals(21)
        pbTotal23.Value = totals(22)
        pbTotal24.Value = totals(23)
    End Sub

End Class
