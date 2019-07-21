Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim a, b As Date
        Dim monthday, today As String

        a = Date.Today
        monthday = MonthName(Month(a))

        Response.Write("1. Serverside Date and Time: " & a & "<br>")
        Response.Write("2. Serverside Current Month: " & monthday & "<br>")

        today = WeekdayName(Weekday(a))

        Response.Write("3. Serverside day: " & today & "<br>")

        b = TimeOfDay()
        Response.Write("Time: " & b)

    End Sub

End Class