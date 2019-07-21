using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_PreInit(Object sender, EventArgs e)
        {
            this.MasterPageFile = "Green.Master";

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.MasterPageFile = "Red.Master"; // cannot be accessed
            //The 'MasterPageFile' property can only be set in or before the 'Page_PreInit' event.

            Master.MasterPageVariable = "From content page"; // can only be accessed if we set MasterType in aspx file.(<%@ MasterType VirtualPath="~/Green.Master" %>)

            Master.FindControl("Label1").Visible = true;


        }

        private void Page_Error(object sender, EventArgs e)
        {
            // Get last error from the server
            Exception exc = Server.GetLastError();

        }

        protected override void OnError(EventArgs e)
        {
            base.OnError(e);
            Exception ex = Server.GetLastError();


        }


    }
}