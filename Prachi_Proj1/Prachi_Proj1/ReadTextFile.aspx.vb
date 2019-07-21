Imports System.IO
Imports System.Web.UI.WebControls


Public Class ReadTextFile
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim f, fs As Object

        Dim fname As String = FileUpload1.FileName
        Dim fpath = Server.MapPath("~/") + fname

        FileUpload1.PostedFile.SaveAs(fpath)

        fs = Server.CreateObject("Scripting.FileSystemObject")
        f = fs.OpenTextFile(fpath, 1)
        Response.Write("The contents of the file are: <br> " & f.ReadAll & "<br>")

        f.Close()
        f = Nothing
        fs = Nothing

        Dim cs As Object = Server.CreateObject("Scripting.FileSystemObject")
        Dim c As Object = cs.OpenTextFile(fpath, 1)
        Response.Write("<br> The first 4 characters of the file are: <br> " & c.read(4) & "<br><br>")

        c.Close()
        c = Nothing
        cs = Nothing

        Dim ms As Object = Server.CreateObject("Scripting.FileSystemObject")
        Dim m As Object = ms.OpenTextFile(fpath, 1)
        Response.Write("<br> The first line of the file is: <br> " & m.readline & "<br><br>")

        m.Close()
        m = Nothing
        ms = Nothing


    End Sub
End Class

