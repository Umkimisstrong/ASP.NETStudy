using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace WebApp
{
    public partial class BoardUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Page.Session["userid"] == null)
                Response.Redirect("BoardLogin2.aspx");

            Session["userid"] = Page.Session["userid"].ToString();
            string board_id = Request.Form["board_id"].ToString();
            string board_title = Request.Form["board_title"].ToString();
            string board_content = Request.Form["board_content"].ToString();
            string pageNum = Request.Form["pageNum"].ToString();
            Board_Id.Text = board_id;
            Board_Title.Text = board_title;
            Board_Content.Text = board_content;
            PageNum.Text = pageNum;

            //Response.Write(Board_Id.Text);
            //string board_id = Request.Form["board_id"].ToString();
            //string board_title = Request.Form["board_title"].ToString();
            //string board_content = Request.Form["board_content"].ToString();
            /*
            Response.Write(board_id);
            Response.Write(board_title);
            Response.Write(board_content);
            */
            //Board_Id.Text = board_id;
            //Board_Title.Text = board_title;
            //Board_Content.Text = board_content;

        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            
        }
        protected string alertMsg()
        {
            string result = "";
            result += "<script language='javascript'>" +
                      "alert('내용을 입력하세요')" +
                      "</script>";

            return result;
        }

        protected string alertMsg(bool flag)
        {
            string result = "";
            if (flag)
            {
                result += "<script language='javascript'>" +
                      "alert('수정이 완료되었습니다.')" +
                      "</script>";
            }
            else
            {
                result += "<script language='javascript'>" +
                "alert('내용을 입력하세요')" +
                "</script>";
            }


            return result;
        }

        //protected void Back_Detail_Click(object sender, EventArgs e)
        //{
        //    string board_id = Board_Id.Text;
        //    string url = "BoardDetail.aspx?board_id=" + board_id;
        //    Response.Write(board_id);
        //    //Response.Redirect(url);
        //}
    }
}