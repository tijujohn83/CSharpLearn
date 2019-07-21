Public Class BirthDate
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnOutput_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOutput.Click
        Dim x As String
        x = Convert.ToDateTime(txtBirthdate.Text.ToString())

        Response.Write("Today's Date is ")
        Response.Write(DateString())
        Response.Write("<br>")

        Response.Write("Birthdate is ")
        Response.Write(x)
        Response.Write("<br>")

        Response.Write("No of days you have lived is ")
        Response.Write(DateDiff("D", x, Date.Today))

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

    End Sub
End Class