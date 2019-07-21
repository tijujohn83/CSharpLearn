Public Class RemoteAddress
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim a, b, c, d, f, g, h, z As String

        a = Request.ServerVariables("Remote_Addr")
        Response.Write("1. IP Address is= " & a & "<br>")

        b = Request.ServerVariables("Server_Port")
        Response.Write("2. Server Port is= " & b & "<br>")

        c = Request.ServerVariables("Path_info")
        Response.Write("3. Path info is= " & c & "<br>")

        d = Request.ServerVariables("Http_user_agent")
        Response.Write("4. Http user agent is= " & d & "<br>")

        f = Request.ServerVariables("Request_method")
        Response.Write("5. Request method is= " & f & "<br>")

        g = Request.ServerVariables("Server_protocol")
        Response.Write("6. Server protocol is= " & g & "<br>")

        h = Request.ServerVariables("Remote_user")
        Response.Write("7. Remote User is= " & h & "<br>")

        z = Request.ServerVariables("HTTP_Host")
        Response.Write("8. HTTP host is= " & z & "<br>")

    End Sub

End Class