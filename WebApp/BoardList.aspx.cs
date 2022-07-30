using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace WebApp
{
    // 페이징 처리를 위한 클래스 각종메소드
    public class MyUtil
    {
        // 로그인 시 사용자 이름을 반환하는 메소드
        public string getUserName(string u_id)
        {
            string result = "";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["testData"].ToString());
            conn.Open();
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            string sql = string.Format("SELECT U_NAME FROM TB_USER WHERE U_ID = '{0}'", u_id);
            sc.CommandText = sql;
            sc.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sc;

            DataSet ds = new DataSet();
            da.Fill(ds, "[TB_USER]");

            List<string> userName = new List<string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                result = (string)row["U_NAME"];
            }

            conn.Close();
            return result;
        
        }


        // 전체 데이터 갯수를 반환하는 메소드
        public int getDataCount()
        {
            int result = 0;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["testData"].ToString());
            conn.Open();
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            string sql = "SELECT COUNT(*) AS [DATACOUNT] FROM BOARD_LIST_VIEW2";
            sc.CommandText = sql;
            sc.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sc;
            DataSet ds = new DataSet();
            da.Fill(ds, "[BOARD_LIST_VIEW2]");
            List<int> count = new List<int>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                result = (int)row["DATACOUNT"];
            }

            conn.Close();
            return result;
        }

        // 전체 데이터 갯수를(검색값에따라) 반환하는 메소드
        public int getDataCount(string searchKey, string searchValue)
        {

            searchValue = "%" + searchValue + "%";
            int result = 0;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["testData"].ToString());
            conn.Open();
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;
            string sql = string.Format("SELECT COUNT(*) AS [DATACOUNT] FROM BOARD_LIST_VIEW2 WHERE {0} LIKE '{1}'", searchKey, searchValue);
                          
            sc.CommandText = sql;
            sc.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sc;
            DataSet ds = new DataSet();
            da.Fill(ds, "[BOARD_LIST_VIEW2]");
            List<int> count = new List<int>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                result = (int)row["DATACOUNT"];
            }

            conn.Close();
            return result;
        }



        // 전체페이지 수를 구하는 메소드
        // numPerPage = 한 페이지에 표시할 데이터(게시물)의 수
        // dataCount : 전체 데이터(게시물) 수
        public int getPageCount(int numPerPage, int dataCount)
        {
            int pageCount = 0;

            pageCount = dataCount / numPerPage;

            // 나누어 떨어지지 않는 경우..
            if (dataCount % numPerPage != 0)
                pageCount++;

            return pageCount;
        }

        // 페이징처리기능의 메소드
        // currentPage : 현재 표시할 페이지
        // totalPage : 전체 페이지 수
        // listUrl : 링크를 설정할 url
        public string pageIndexList(int currentPage, int totalPage, string listUrl, string searchKey, string searchValue)
        {
            // 페이징 문자열을 저장할 변수
            string strList = "";

            // 페이징 시 게시물 리스트 하단의 숫자를 10개씩
            int numPerBlock = 10;

            // 현재 페이지(이 페이지를 기준으로 보여주는 숫자가 달라져야함)
            int currentPageSetup;

            // 이전 페이지 블럭과 같은 처리에서 이동하기 위한 변수
            // 얼마만큼 이동해야하는지
            int page;
            int n;

            // 페이징 처리가 별도로 필요하지 않은 경우
            // 데이터X 데이터의 수가 1페이지도 못채우는 경우는 할 필요 없음
            if (currentPage == 0)
            {
                return "";
            }


            // 검색값이 있는 경우 &로 값전달할예정
            if (listUrl.IndexOf("?") != -1)
            {
                listUrl = listUrl + "&";
            }
            else
            {
                // 검색값이 없다면 ?로 값전달
                listUrl = listUrl + "?";
            }


            
            currentPageSetup = (currentPage / numPerBlock) * numPerBlock;

            if (currentPage % numPerBlock == 0)
            {
                currentPageSetup = currentPageSetup - numPerBlock;
            }


            // 1. 페이지(처음으로)
            if ((totalPage > numPerBlock) && (currentPage > 0))
            {
                strList += string.Format("<a href='{0}pageNum=1&searchKey={1}&searchValue={2}' style='font-weight:bold; text-decoration: none;'>[GO FIRST]</a> ", listUrl, searchKey, searchValue); 

            }

            // 2 Prev(이전)
            n = currentPage - numPerBlock;

            if ((totalPage > numPerBlock) && (currentPageSetup > 0))
            {

                strList += string.Format("<a href='{0}pageNum={1}&searchKey={2}&searchValue={3}' style='font-weight:bold; text-decoration: none;'>◀</a>   ", listUrl, n, searchKey, searchValue);

            }


            // 3. 각 페이지 바로가기
            page = currentPageSetup + 1;

            while (  (page<=totalPage) && (page<=currentPageSetup+numPerBlock)   )
            {
                if (page == currentPage) // 현재페이지
                {
                    strList += string.Format("<span style='color:orange; font-weight:bold; text-decoration: none;'>{0}</span>  ", page);
                }
                else
                {
                    strList += string.Format("<a href='{0}pageNum={1}&searchKey={2}&searchValue={3}' style='font-weight:bold; text-decoration: none;'>{1}</a>  ", listUrl, page, searchKey, searchValue);
                }

                page++;
            }

            // 4. Next(다음)
            n = currentPage + numPerBlock;
            // 현재페이지가 9이면
            // n 은 19가됨
            // 따라서 next는 19가 되어서
            // 이상해짐
            // 


            if ((totalPage - currentPageSetup) > numPerBlock)
            {
                strList += string.Format("   <a href='{0}pageNum={1}&searchKey={2}&searchValue={3}' style='font-weight:bold; text-decoration: none;'>▶</a>", listUrl, n, searchKey, searchValue );
            }

            // 5. 마지막페이지
            if ((totalPage > numPerBlock) && (currentPageSetup + numPerBlock) < totalPage)
            {
                strList += string.Format("      <a href='{0}pageNum={1}&searchKey={2}&searchValue={3}' style='font-weight:bold; text-decoration: none;'>[GO LAST]</a>", listUrl, totalPage, searchKey, searchValue);
            }

            return strList;
        }
        
    }


    public class BoardDTO
    {
        public int rowNum { get ; set ; }
        public int board_id { get; set; }
        public string board_title { get; set; }
        public string board_content { get; set; }
        public int board_hitCount { get; set; }
        public string board_date { get; set; }
        public string u_name { get; set; }
        public string u_id { get; set; }

    }

    public partial class BoardList : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            
            string id = (string)Page.Session["userid"];
            if (id == null)
                Response.Redirect("BoardLogin2.aspx");
            else
                id = Page.Session["userid"].ToString();


            // 게시물 번호 수신
            string strNum = Request.QueryString["num"];
            int num = 0;
            if (strNum != null)
                num = int.Parse(strNum);

            // 페이지 번호 수신
            string pageNum = Request.QueryString["pageNum"];
            int currentPage = 1;
            if (pageNum != null)
                currentPage = int.Parse(pageNum);

            // 검색 키
            string searchKey = Request.QueryString["searchKey"];
            string searchObjKey = "BOARD_TITLE";
            if (searchKey != null)
                searchObjKey = searchKey;

            // 검색 값
            string searchValue = Request.QueryString["searchValue"];
            string searchObjValue = "";
            if (searchValue != null)
                searchObjValue = searchValue;


            MyUtil mu = new MyUtil();

            // 로그인 유저 이름 구하기
            string u_name = mu.getUserName(id);

            // 전체 데이터 갯수 구하기
            int dataCount = mu.getDataCount(searchObjKey, searchObjValue);

            
            // 전체 페이지를 기준으로 총 페이지 수 계산
            int numPerPage = 10;
            int totalPage = mu.getPageCount(numPerPage, dataCount);

            // 전체 페이지 수 보다 표시할 페이지 가 큰 경우
            // 표시할 페이지를 전체 페이지로 처리
            if (currentPage > totalPage)
                currentPage = totalPage;

            // 시작과 끝 위치
            int start = (currentPage - 1) * numPerPage + 1;
            int end = currentPage * numPerPage;


            string listUrl = "BoardList.aspx";
            string pageIndexList = mu.pageIndexList(currentPage, totalPage, listUrl, searchObjKey, searchObjValue);

            //string articleUrl = "BoardDetail.aspx";

            if (dataCount == 0)
            {
                pageIndexList = "등록된 게시물이 존재하지 않습니다.";
            }

            PageIndex.Text = pageIndexList;
            // ----------------------------------------------------------------------------------------------------------


            

            // db연결

            // 연결 객체 생성
            SqlConnection conn = null;
            searchObjValue = "%" + searchValue + "%";
            try
            {

                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["testData"].ToString());
                // db 오픈
                conn.Open();
                SqlCommand sc = new SqlCommand();
                sc.Connection = conn;
                string sql = string.Format(" SELECT BOARD.ROWNUM, BOARD.BOARD_ID, BOARD.BOARD_TITLE, BOARD.BOARD_HITCOUNT, BOARD.BOARD_DATE, BOARD.U_NAME" +
                                           " FROM" +
                                           "(" +
                                           "    SELECT CONVERT(INT, ROW_NUMBER() OVER(ORDER BY BOARD_ID DESC)) AS[ROWNUM], BOARD_ID, BOARD_TITLE, BOARD_HITCOUNT, BOARD_DATE, U_NAME" +
                                           "    FROM BOARD_LIST_VIEW2" +
                                           " WHERE {0} LIKE '{1}'" +
                                           ") [BOARD]" +
                                           "  WHERE BOARD.ROWNUM >= {2} AND BOARD.ROWNUM <= {3}"                                            
                                            , searchObjKey, searchObjValue, start, end);
                sc.CommandText = sql;
                sc.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sc;
                DataSet ds = new DataSet();
                da.Fill(ds, "[BOARD]");

                List<BoardDTO> boardList = new List<BoardDTO>();

                if (ds.Tables.Count > 0)
                {
                    for (int j = 0; j< ds.Tables.Count; j++)
                    {
                        foreach (DataRow row in ds.Tables[j].Rows)
                        {
                            BoardDTO dto = new BoardDTO();


                            dto.rowNum = (int)row["ROWNUM"];

                            dto.board_id = (int)row["BOARD_ID"];
                            dto.board_title = (string)row["BOARD_TITLE"];
                            dto.board_hitCount = (int)row["BOARD_HITCOUNT"];
                            dto.board_date = (string)row["BOARD_DATE"];
                            dto.u_name = (string)row["U_NAME"];

                            boardList.Add(dto);


                        }
                    }
                    // 값을 추출하자

                    TableRow tr;
                    TableCell td;

                    // 로그인 한 유저 테이블에 명시
                    tr = new TableRow();
                    td = new TableCell();
                    td.Text = "♥환영합니다 " +  u_name + " 님의 게시판입니다♥";
                    tr.Cells.Add(td);
                    tr.BackColor = Color.AntiqueWhite;
                    SubTitle.Rows.Add(tr);


                    // 테이블의 첫줄
                    // <%-- 번호 / 제목(댓글) / 작성자 / 작성일 / 조회수 --%>
                    tr = new TableRow();
                    string [] title  = { "번호", "제목", "작성자", "작성일", "조회수"};
                    
                    for (int i = 0; i < 5; i++)
                    {
                        td = new TableCell();
                        td.Text = title[i];
                        tr.Cells.Add(td);
                    }

                    // 테이블 첫줄의 색깔 지정
                    tr.BackColor = Color.AntiqueWhite;

                    // asp 컨트롤 Board_List 의 행에 만든 tr 을 추가한다.
                    Board_List.Rows.Add(tr);


                    // 추출한 boardList 의 데이터 만큼 테이블의 개체로 담아주기
                    foreach (BoardDTO dto in boardList)
                    {
                        tr = new TableRow();

                        td = new TableCell();
                        td.Text = dto.rowNum.ToString();
                        tr.Cells.Add(td);

                        td = new TableCell();
                        td.Text = "<a href='BoardDetail.aspx?board_id=" +dto.board_id.ToString()+ "&pageNum=" +currentPage+"' style='text-decoration: none;'>" + dto.board_title +"</a> ";
                        tr.Cells.Add(td);

                        td = new TableCell();
                        td.Text = dto.u_name;
                        tr.Cells.Add(td);

                        td = new TableCell();
                        td.Text = dto.board_date;
                        tr.Cells.Add(td);

                        td = new TableCell();
                        td.Text = dto.board_hitCount.ToString();
                        tr.Cells.Add(td);

                        Board_List.Rows.Add(tr);
                    }
                }
                else
                {
                    // 값이 없다면 리턴..
                    conn.Close();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            string id = Page.Session["userid"].ToString();

            Session["userId"] = id;
            Response.Redirect("BoardInsert.aspx");
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("BoardLogin2.aspx");
        }
    }
}