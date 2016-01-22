'/*************************************************************************
'
'   Copyright (C) 2015-2016. rollrat. All Rights Reserved.
'
'   Author: HyunJun Jeong
'
'***************************************************************************/

Imports System.Net

Public Class frmJujak

    Private Sub bProxy_Click(sender As Object, e As EventArgs) Handles bProxy.Click
        Dim proxis As New List(Of String)
        proxis.Add("http://gatherproxy.com/proxylist/port/8123")
        proxis.Add("http://gatherproxy.com/proxylist/port/8080")
        proxis.Add("http://gatherproxy.com/proxylist/port/9064")
        proxis.Add("http://gatherproxy.com/proxylist/port/80")
        proxis.Add("http://gatherproxy.com/proxylist/port/3128")
        proxis.Add("http://gatherproxy.com/proxylist/port/8118")
        proxis.Add("http://gatherproxy.com/proxylist/port/9999")
        proxis.Add("http://gatherproxy.com/proxylist/port/8585")
        proxis.Add("http://gatherproxy.com/proxylist/port/81")
        proxis.Add("http://gatherproxy.com/proxylist/port/8888")
        proxis.Add("http://gatherproxy.com/proxylist/port/82")
        proxis.Add("http://gatherproxy.com/proxylist/port/8081")
        proxis.Add("http://gatherproxy.com/proxylist/port/8088")
        proxis.Add("http://gatherproxy.com/proxylist/port/18186")
        proxis.Add("http://gatherproxy.com/proxylist/port/8000")
        proxis.Add("http://gatherproxy.com/proxylist/port/83")
        proxis.Add("http://gatherproxy.com/proxylist/port/8089")
        proxis.Add("http://gatherproxy.com/proxylist/port/9090")
        proxis.Add("http://gatherproxy.com/proxylist/port/3127")
        proxis.Add("http://gatherproxy.com/proxylist/port/85")
        proxis.Add("http://gatherproxy.com/proxylist/port/8090")

        Dim i As Integer = 1

        ' Target
        ' http://gatherproxy.com/proxylist/
        For Each address As String In proxis
            Try
                Dim html As String = (New WebClient).DownloadString(address)
                Dim port As Integer = Convert.ToInt16(address.Substring(address.LastIndexOf("/") + 1))
                Dim deli As String = """PROXY_IP"":"""
                While html.IndexOf(deli) > -1
                    html = html.Substring(html.IndexOf(deli) + deli.Length)
                    Dim ip As String = html.Substring(0, html.IndexOf(""""))
                    lvProxy.Items.Add(New ListViewItem(New String() {
                                            i,
                                            ip,
                                            port
                                            }))
                    i += 1
                    Application.DoEvents()
                End While
            Catch ex As Exception

            End Try
        Next

    End Sub


End Class