using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckBoxList
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (ListItem item in CheckBoxList1.Items)
            {

                if (item.Text.Equals("Item 1"))

                    item.Attributes.Add("onclick", "alert('Mango')");

            }
        }


        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int lastSelectedIndex = 0;
            string lastSelectedValue = string.Empty;

            foreach (ListItem listitem in CheckBoxList1.Items)
            {
                if (listitem.Selected)
                {
                    int thisIndex = CheckBoxList1.Items.IndexOf(listitem);

                    if (lastSelectedIndex < thisIndex)
                    {
                        //Label lbl = new Label();
                        //lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('User Already Exists')</script>";
                        //Page.Controls.Add(lbl);

                 //       ClientScript.RegisterStartupScript(typeof(Page), "SymbolError", "<script type='text/javascript'>alert('Error............ !!!');</script>");

                        lastSelectedIndex = thisIndex;
                        lastSelectedValue = listitem.Value;
                    }
                }
            }
        }
    }
}