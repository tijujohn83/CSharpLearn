using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPages
{
    public partial class Green : System.Web.UI.MasterPage
    {
        public string MasterPageVariable { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMasterLabel.Text = MasterPageVariable;
        }
    }
}