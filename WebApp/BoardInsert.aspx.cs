using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class BoardInsert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = "";

            if (Page.Session["userId"] != null)
            {
                id = Page.Session["userId"].ToString();

            }
            else
            {
                Response.Redirect("BoardLogin2.aspx");
            }
            //Response.Write(id);


        }
    }
}