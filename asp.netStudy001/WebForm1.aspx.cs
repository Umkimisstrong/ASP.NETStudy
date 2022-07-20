using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace asp.netStudy001
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string msg = "";
        protected void Page_Init(object sender, EventArgs e)
        {
            msg = "<script type='text/javascript'>alert('WebFormInit')</script>";
            //Response.Write(msg);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            msg = "<script type='text/javascript'>alert('WebFormLoad')</script>";
            //Response.Write(msg);
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            msg = "<script type='text/javascript'>alert('WebFormPreRender')</script>";
            //Response.Write(msg);

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            msg = "<script type='text/javascript'>alert('어쩌고버튼')</script>";
            Response.Write(msg);
        }
    }
}