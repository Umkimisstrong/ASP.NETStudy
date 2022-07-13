using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class BoardLogin2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*// 이 페이지가 처음 호출된 것이라면
            if (!Page.IsPostBack)
            {
                Response.Write("처음호출");
            }
            else // 포스트백 되었다면
            {
                // 알람

                Response.Write("처음호출X");
            }*/
        }
        protected void LoginBtn_Click(object sender, EventArgs e)
        {

            // Java script에서 기본적인 조건을 확인 후 
            // asp 버튼을 요청함


            /*
            // 테스트
            String id = Id.Value;
            String pwd = Pwd.Value;
            */

            //String resultMsg = id + " 님의 비밀번호는 " + pwd + "입니다.";

            //Response.Write(resultMsg); -- 김상기 님의 비밀번호는 123 입니다.

            // 제대로 입력되지 않았다면 -- 자바스크립트에서 실행
            /*
            if (id.Equals("") || pwd.Equals("") || id==null || pwd ==null)
            {

                Response.Redirect("BoardLogin2.aspx");
                //CreateMessageAlert(msg);
            }
            */

            
            string id = Id.Value;
            string pwd = Pwd.Value;


            // 폼을 submit 하는 메소드
            submitForm("BoardLoginValidate.aspx", id, pwd);


            //Response.Redirect("BoardLoginValidate.aspx");


        }

        /*
        // 경고메세지를 위한 메소드    = 미사용
        public void CreateMessageAlert(string message)
        {
            // 스크립트 : alert("메세지")
            string script = "alert('" + message + "');";

            // guid
            Guid guidKey = Guid.NewGuid();

            // Page의 ClientScript 의 RegisterStrartupScript 함수
            Page.ClientScript.RegisterStartupScript(typeof(Page), guidKey.ToString(), script, true);
        }
        */


        // form 을 submit 하는 메소드
        private void submitForm(string url, string id, string pwd)
        {
            // System.Web.HttpContext.Current.Response.Write -> 현재 페이지에 해당 내용을 HTML 로 적는다.
            System.Web.HttpContext.Current.Response.Write("<form name='newForm' method=post action='" + url + "'>");

            System.Web.HttpContext.Current.Response.Write(string.Format("<input type = hidden name ='id' value='{0}'>", id));

            System.Web.HttpContext.Current.Response.Write(string.Format("<input type = hidden name ='pwd' value='{0}'>", pwd));

            System.Web.HttpContext.Current.Response.Write("</form>");
            System.Web.HttpContext.Current.Response.Write("</body>");



            Response.Write("<SCRIPT LANGUAGE='JavaScript'>document.forms[0].submit();</SCRIPT>");
        }
    }
}

