using MyToDoList.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyToDoList
{
    public partial class ToDoList : System.Web.UI.Page
    {
        /// <summary>
        /// Page_Load
        /// 페이지 로드 시 기본적인 이벤트 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                newDataBind();
            }
        }



        
        /// <summary>
        /// newDataBind()
        /// 삭제 / 수정 후 새롭게 리스트를 출력하는 메소드
        /// </summary>
        protected void newDataBind()
        {
            ToDoDAO dao = new ToDoDAO();
            DataSet ds = dao.ReadToDo();
            List.DataSource = ds;
            List.DataMember = "TB_TODO";
            List.DataBind();
        }


       

        /// <summary>
        /// Create_Click 
        /// 추가 이벤트로 ToDo 추가
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Create_Click(object sender, EventArgs e)
        {
            // 새로고침이 아닐 시에만 실행한다.
            if (!IsRefresh)
            {
                string u_todo = "";

                // ToDoDAO 객체 생성
                ToDoDAO dao;


                // U_TODO 의 입력내용 이 있다면
                if (U_TODO.Text.Trim() != "")
                {
                    // u_todo 에 담기
                    u_todo = U_TODO.Text;
                }
                else
                {
                    string msg = alertMsg("내용을 입력해주세요");
                    Response.Write(msg);
                    return;
                }

                dao = new ToDoDAO();

                // ToDoDTO 객체 생성
                ToDoDTO dto = new ToDoDTO();

                dto.u_todo = u_todo;

                int result = 0;

                result = dao.CreateToDo(dto);

                if (result > 0)
                {
                    string msg = "<script type='text/javascript'> alert('추가 완료') </script>";
                    Response.Write(msg);
                    U_TODO.Text = "";
                    newDataBind();
                }
            }
            else // 새로고침인 경우 return
            {
                return;
            }


        }

        

        /// <summary>
        /// Update_CheckedChanged
        /// 체크되면 TODO_STATUS 를 Y로 수정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Update_CheckedChanged(object sender, EventArgs e)
        {
            if (!IsRefresh)
            {
                CheckBox checkBox = (CheckBox)sender;
                int todo_id = int.Parse(checkBox.Text);
                string todo_status = "";
                ToDoDAO dao = new ToDoDAO();

                ToDoDTO dto = new ToDoDTO();
                dto.todo_id = todo_id;

                int result = 0;
                // 체크되면 Y 로 status 를 Y 로 수정
                if (checkBox.Checked)
                {
                    todo_status = "Y";
                    dto.todo_status = todo_status;
                    result = dao.UpdateToDo(dto);
                    checkBox.Checked = true;
                }
                else
                {
                    todo_status = "N";
                    dto.todo_status = todo_status;
                    result = dao.UpdateToDo(dto);
                    checkBox.Checked = false;
                }

                if (result > 0)
                {
                    string msg = alertMsg("수정 완료");
                    Response.Write(msg);
                    newDataBind();
                    return;
                }

                return;
            }
            else
            {
                return;
            }

            
            

        }



        /// <summary>
        /// List_ItemDataBound
        /// (Repeater) 에 Data를 넣어주는 기능
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void List_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            // Literal 컨트롤의 속성이 될 변수
            string u_todo = DataBinder.Eval(e.Item.DataItem, "U_TODO").ToString();
            string todo_id = DataBinder.Eval(e.Item.DataItem, "TODO_ID").ToString();

            // CheckBox 컨트롤의 속성이 될 변수
            string todo_status = DataBinder.Eval(e.Item.DataItem, "TODO_STATUS").ToString();

            // --------------- TODO (Literal) 바인딩
            Literal ltr = e.Item.FindControl("ltrToDo") as Literal;

            // 30자가 넘어가면 ... 추가
            if (u_todo.Length > 30)
            {
                u_todo = u_todo.Substring(0, 30) + "...";
            }

            // status 가 완료(Y)이면 삭선 및 체크
            if (todo_status == "Y")
            {
                u_todo = "<span style='text-decoration:line-through'>" + u_todo + "</span>";
                CheckBox checkedBox = e.Item.FindControl("Update") as CheckBox;
                checkedBox.Checked = true;
            }

            ltr.Text = u_todo;



            // --------------- TODO-ID (Literal) 바인딩

            ltr = e.Item.FindControl("ltrToDo_ID") as Literal;
            ltr.Text = todo_id;



            // --------------- TODO_ID (CheckBox) 바인딩

            CheckBox checkBox = e.Item.FindControl("Update") as CheckBox;
            checkBox.Text = todo_id;

        }


        /// <summary>
        /// List_ItemCommand
        /// (Repeater) 에서 버튼클릭 동작 이벤트를 실행하는 기능
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void List_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (!IsRefresh)
            {
                if (e.CommandName.ToString() == "delete")
                {
                    int todo_id = 0;

                    Literal ltr = e.Item.FindControl("ltrToDo_ID") as Literal;
                    todo_id = int.Parse(ltr.Text);

                    ToDoDAO dao = new ToDoDAO();

                    int result = dao.DeleteToDO(todo_id);

                    if (result > 0)
                    {
                        string msg = alertMsg("삭제 완료");
                        Response.Write(msg);
                        newDataBind();
                    }
                }
            }
            else
                return;
        }


        /// <summary>
        /// alertMsg
        /// 사용자 알림 용 메소드
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected string alertMsg(string msg)
        {
            string result = "<script type='text/javascript'> alert('";
            if (msg.Trim() != "")
            {
                result += msg + "') </script>";
                return result;
            }
            return "";
        }



        /// <summary>
        /// 새로고침 확인을 위한 변수 및 메소드
        /// </summary>
        #region RefreshState check

        /// <summary>
        /// refresh 프로퍼티 선언
        /// </summary>
        private bool _refreshState;
        private bool _isRefresh;

        /// <summary>
        /// IsRefresh 프로퍼티
        /// bool 상태 값을 반환
        /// 새로고침 상태로 분기
        /// </summary>
        public bool IsRefresh
        {
            get { return _isRefresh; }
        }
        
        protected override void LoadViewState(object savedState)
        {
            object[] allStates = (object[])savedState;
            base.LoadViewState(allStates[0]);
            _refreshState = (bool)allStates[1];
            _isRefresh = _refreshState == (bool)Session["__ISREFRESH"];
        }

        /// <summary>
        /// ViesState 메소드
        /// ViewState 와 refreshState를 저장하여 반환
        /// </summary>
        /// <returns></returns>
        protected override object SaveViewState()
        {
            Session["__ISREFRESH"] = _refreshState;
            object[] allStates = new object[2];
            allStates[0] = base.SaveViewState();
            allStates[1] = !_refreshState;

            return allStates;
        }






        #endregion

        
    }
}