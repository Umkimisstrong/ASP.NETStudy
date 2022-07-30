using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace asp.netStudy001
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        string msg = "";
        protected void Page_Init(object sender, EventArgs e)
        {
            msg= "<script type='text/javascript'>alert('MasterInit')</script>";
            //Response.Write(msg);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            msg = "<script type='text/javascript'>alert('MasterLoad')</script>"; 
            //Response.Write(msg);
                
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            msg= "<script type='text/javascript'>alert('MasterPreRender')</script>";
            //Response.Write(msg);
        }
    }
}