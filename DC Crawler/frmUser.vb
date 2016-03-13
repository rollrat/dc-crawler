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

Public Class frmUser

    Public Sub New(userid As String, username As String)

        ' 디자이너에서 이 호출이 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하세요.
        Me.Text += $"{username}({userid})"

        Dim Request As WebRequest

        Request = WebRequest.Create("http://m.dcinside.com/gallog/home.php?g_id=" & userid)
        Request.Method = "GET"

        Dim Response As WebResponse = Request.GetResponse
        Dim Reader As New StreamReader(Response.GetResponseStream())

        Dim UserCounting As String = Reader.ReadToEnd

        For Each Match As Match In Regex.Matches(UserCounting, "글 <span>(.*?)\<[\s\S]*?글 <span>(.*?)\<")
            lbBoard.Text = Match.Groups(1).Value
            lbComment.Text = Match.Groups(2).Value
        Next

    End Sub

End Class