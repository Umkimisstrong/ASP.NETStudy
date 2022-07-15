using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace WebApp
{

    public class BoardDetailDTO
    {
        // 게시물 id
        public int board_id { get; set; }
        // 게시물 제목
        public string board_title { get; set; }
        // 게시물 내용
        public string board_content { get; set; }
        // 게시물 조회수
        public int board_hitCount { get; set; }
        // 게시 날짜
        public string board_date { get; set; }
        // 작성자 id
        public string u_id { get; set; }
        // 작성자 명
        public string u_name { get; set; }
        // 댓글 id
        public int reply_id { get; set; }
        // 댓글 내용
        public string reply_content { get; set; }
        // 댓글 작성일
        public string reply_date { get; set; }
        public int reply_number { get; set; }
        public string reply_user { get; set; }

    }

    public partial class BoardDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = "";
            if (Page.Session["userid"] != null)
                id = Page.Session["userid"].ToString();
            else
                Response.Redirect("BoardLogin.aspx");
            //Response.Write(id);
            string board_id = Request.QueryString["board_id"].ToString();
            //Response.Write(board_id);
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["testData"].ToString());

                conn.Open();

                // SqlCommand 객체 생성
                SqlCommand sc = new SqlCommand();

                // SqlCommand 객체의 연결은 testData 의 Connection() 을 의미
                sc.Connection = conn;

                // 쿼리문 작성
                string sql = string.Format("SELECT ROWNUM, BOARD_ID, BOARD_TITLE, BOARD_HITCOUNT, CONVERT(VARCHAR(8), BOARD_DATE, 112) AS [BOARD_DATE], BOARD_CONTENT, U_ID, U_NAME FROM BOARD_DETAIL_VIEW2 WHERE BOARD_ID = {0}", board_id);

                // sql 실행
                sc.CommandText = sql;

                // commandtype 정의
                sc.CommandType = CommandType.Text;

                // sqlDataAdapter 선언
                SqlDataAdapter da = new SqlDataAdapter();

                // SqlDataAdapter 객체의 Command 정의
                da.SelectCommand = sc;

                // 결과 담기 ▼

                // DataSet 생성
                DataSet ds = new DataSet();

                // DataSet 에 테이블 담기
                da.Fill(ds, "[BOARD_DETAIL_VIEW2]");

                // DataTable로 가져오기
                //DataTable dt = new DataTable();

                // DataSet 에 담긴 table 을 dt에 set해줌 === 정의
                //dt.TableName = ds.DataSetName;

                // List 생성
                List<BoardDTO> boardList = new List<BoardDTO>();

                // ds 테이블에 담긴 행 추출
                // 조건문 : 값을 얻어 왔다면 -- DataSet 의 count 가 0보다 크다면
                if (ds.Tables.Count > 0)
                {
                    for (int j = 0; j < ds.Tables.Count; j++)
                    {
                        foreach (DataRow row in ds.Tables[j].Rows)
                        {
                            BoardDTO dto = new BoardDTO();


                            dto.rowNum = (int)row["ROWNUM"];

                            dto.u_id = (string)row["U_ID"];
                            dto.board_id = (int)row["BOARD_ID"];
                            dto.board_title = (string)row["BOARD_TITLE"];
                            dto.board_content = (string)row["BOARD_CONTENT"];
                            dto.board_hitCount = (int)row["BOARD_HITCOUNT"];
                            dto.board_date = (string)row["BOARD_DATE"];
                            dto.u_name = (string)row["U_NAME"];

                            boardList.Add(dto);
                            Board_Id.Text = dto.board_id.ToString();

                        }
                    }





                    // 테이블의 첫줄
                    // <%-- 번호 / 제목(댓글) / 작성자 / 작성일 / 조회수 --%>
                    TableRow tr;
                    TableCell td;

                    // 추출한 boardList 의 데이터 만큼 테이블의 개체로 담아주기
                    foreach (BoardDTO dto in boardList)
                    {
                        tr = new TableRow();

                        td = new TableCell();
                        td.Text = "[ " + dto.rowNum.ToString() + " ]";
                        tr.Cells.Add(td);

                        td = new TableCell();
                        td.ID = "Board_title";
                        td.Text = "[ " + dto.board_title + " ]";
                        tr.Cells.Add(td);

                        td = new TableCell();
                        td.ID = "u_name";
                        td.Text = "[ " + dto.u_name + " ]";
                        tr.Cells.Add(td);

                        td = new TableCell();
                        td.ID = "board_date";
                        td.Text = "[ " + dto.board_date + " ]";
                        tr.Cells.Add(td);

                        td = new TableCell();
                        td.Text = "[ " + dto.board_hitCount.ToString() + " ]";
                        tr.Cells.Add(td);

                        tr.BackColor = Color.FromName("#ccccff");

                        textarea.Text = dto.board_content;
                        
                        Board_Detail.Rows.Add(tr);

                        // session Id 와 게시물작성자 id 와 동일하다면 
                        // 삭제버튼과 수정버튼의 Visible 속성을 true 로 변경
                        if (id == dto.u_id)
                        {
                            Delete.Visible = true;
                            Update.Visible = true;
                        }

                    }



                }
                else
                {
                    // 값이 없다면 리턴..
                    conn.Close();
                }


                //Console.WriteLine(result);

                sc = new SqlCommand();
                sc.Connection = conn;
                string sql2 = string.Format("SELECT CONVERT(INT, ROW_NUMBER() OVER (ORDER BY REPLY_ID)) AS [ROWNUM]" +
                                   ", REPLY_ID, REPLY_CONTENT, CONVERT(VARCHAR(8), REPLY_DATE, 112) AS [REPLY_DATE]" +
                                   ", BOARD_ID, U_NAME" +
                                   " FROM REPLY_LIST_VIEW" +
                                   " WHERE BOARD_ID = {0}", board_id);

                sc.CommandText = sql2;

                // commandtype 정의
                sc.CommandType = CommandType.Text;

                // sqlDataAdapter 선언
                SqlDataAdapter da2 = new SqlDataAdapter();

                // SqlDataAdapter 객체의 Command 정의
                da2.SelectCommand = sc;

                // 결과 담기 ▼

                // DataSet 생성
                DataSet ds2 = new DataSet();

                // DataSet 에 테이블 담기
                da2.Fill(ds2, "[REPLY_LIST_VIEW]");

                // DataTable로 가져오기
                //DataTable dt = new DataTable();

                // DataSet 에 담긴 table 을 dt에 set해줌 === 정의
                //dt.TableName = ds.DataSetName;

                // List 생성
                List<BoardDetailDTO> replyList = new List<BoardDetailDTO>();

                // ds 테이블에 담긴 행 추출
                // 조건문 : 값을 얻어 왔다면 -- DataSet 의 count 가 0보다 크다면
                if (ds2.Tables.Count > 0)
                {
                    //Response.Write(ds2.Tables.Count);
                    for (int j = 0; j < ds2.Tables.Count; j++)
                    {
                        foreach (DataRow row in ds2.Tables[j].Rows)
                        {
                            BoardDetailDTO dto = new BoardDetailDTO();


                            dto.reply_number = (int)row["ROWNUM"];
                            dto.reply_id = (int)row["REPLY_ID"];
                            dto.reply_content = (string)row["REPLY_CONTENT"];
                            dto.reply_date = (string)row["REPLY_DATE"];
                            dto.reply_user = (string)row["U_NAME"];

                            replyList.Add(dto);

                            //Response.Write(dto.reply_content + "바보");
                            //Response.Write(replyList.Count());
                        }
                    }
                    // 값을 추출하자

                    // replyList(댓글리스트의 Count() 가 null 이 아니라면
                    TableRow tr;
                    TableCell td;
                    if (replyList.Count() > 0)
                    {
                        // 테이블의 첫줄
                        // <%-- 번호 / 제목(댓글) / 작성자 / 작성일 / 조회수 --%>


                        // 추출한 boardList 의 데이터 만큼 테이블의 개체로 담아주기
                        foreach (BoardDetailDTO dto in replyList)
                        {
                            tr = new TableRow();

                            td = new TableCell();
                            td.Text = dto.reply_number.ToString();
                            tr.Cells.Add(td);

                            td = new TableCell();
                            td.Text = dto.reply_content;
                            tr.Cells.Add(td);

                            td = new TableCell();
                            td.Text = dto.reply_user;
                            tr.Cells.Add(td);

                            td = new TableCell();
                            td.Text = dto.reply_date;
                            tr.Cells.Add(td);

                            tr.BackColor = Color.FromName("#a9f5f2s");

                            Board_Reply.Rows.Add(tr);

                        }
                    }
                    else
                    {
                        tr = new TableRow();
                        td = new TableCell();

                        td.Text = "작성된 댓글이 없습니다.";
                        tr.Cells.Add(td);
                        Board_Reply.Rows.Add(tr);
                    }

                }
                else
                {
                    // 테이블에 값이 없다면

                    conn.Close();
                }

                // db 클로즈
                conn.Close();


            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }



        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("BoardList.aspx");
        }

        protected void Reply_Click(object sender, EventArgs e)
        {
            // board_id 가져오기
            string board_id = Board_Id.Text;

            // board_id를 url 에 포함
            string url = "BoardReplyInsert.aspx?board_id=" + board_id;

            // 세션으로 user Id 설정해주기
            Session["userid"] = Page.Session["userid"].ToString();

            Response.Redirect(url);
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            Response.Write(confirmMsg());

            //Response.Write("바보");
        }

        protected string confirmMsg()
        {
            string result = "";
            string board_id = Board_Id.Text;
            result += "<script type='text/javascript'>" +
                      "var deleteFlag = confirm('해당 게시물을 정말 삭제하시겠습니까??');" +
                      "if(deleteFlag == true)" +
                      "{" +
                      "     alert('게시물이 정상적으로 삭제되었습니다.');" +
                      "     location.href='BoardDelete.aspx?board_id=" + board_id + "';" +
                      "}" +
                      "else" +
                      "{" +
                      "     alert('삭제를 취소하셨습니다.');" +
                      "}" +
                      "</script>";



            return result;
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            string url = "";
            // 수정을 하기 위한 데이터 : 게시물id, 게시물 제목, 게시물 내용
            string board_id = Board_Id.Text;

            // 세션 유지를 위한 데이터
            Session["userid"] = Page.Session["userid"].ToString();
            string board_content = textarea.Text;
            string board_title = Board_Detail.Rows[0].Cells[1].Text;
            board_title = board_title.Substring(2, board_title.Length - 4);


            //Response.Write(board_content);
            //Response.Write(board_title);
            //url = "BoardUpdate.aspx?board_id=" + board_id + "&board_title=" + board_title + "&board_content=" + board_content;
            submitForm("BoardUpdate.aspx", board_id, board_title, board_content);

        }



        private void submitForm(string url, string board_id, string board_title, string board_content)
        {
            // System.Web.HttpContext.Current.Response.Write -> 현재 페이지에 해당 내용을 HTML 로 적는다.
            System.Web.HttpContext.Current.Response.Write("<form name='newForm' method='post' action='" + url + "'>");

            System.Web.HttpContext.Current.Response.Write(string.Format("<input type = hidden name ='board_id' value='{0}'>", board_id));

            System.Web.HttpContext.Current.Response.Write(string.Format("<input type = hidden name ='board_title' value='{0}'>", board_title));

            System.Web.HttpContext.Current.Response.Write(string.Format("<input type = hidden name ='board_content' value='{0}'>", board_content));

            System.Web.HttpContext.Current.Response.Write("</form>");
            System.Web.HttpContext.Current.Response.Write("</body>");



            Response.Write("<SCRIPT LANGUAGE='JavaScript'>document.forms[0].submit();</SCRIPT>");
        }
    }
}