﻿'/*************************************************************************
'
'   Copyright (C) 2015-2016. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Public Class frmComment

    Public Sub New(sender As List(Of frmMain.DCCommentStructure))

        ' 디자이너에서 이 호출이 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하세요.
        For Each com As frmMain.DCCommentStructure In sender
            Dim lvi As ListViewItem = lvCon.Items.Add(New ListViewItem(New String() {
                                            com.author,
                                            com.comments,
                                            com.dates}))
            If com.level = 1 Then
                lvi.BackColor = Color.LightGray
            ElseIf com.level = 2 Then
                lvi.BackColor = Color.LightGoldenrodYellow
            End If
        Next

    End Sub

    Private Sub _KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Close()
    End Sub

End Class