Public Class NoOfPageVisit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Write("Prachiiiii")
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        If Request.ServerVariables("content_length") <> 0 Then
            Application.Lock()
            Application("c") = Application("c") + 1
            Label1.Text = Application("c")
            Application.UnLock()
        End If
        Response.Write("No. of times page visited")
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click

    End Sub
End Class