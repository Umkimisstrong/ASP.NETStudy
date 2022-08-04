using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace MyToDoList.DataBase
{





    /// <summary>
    /// DataBase Access 클래스
    /// ToDo 입력 / 조회 / 수정 / 삭제 기능 수행
    /// </summary>
    public class ToDoDAO
    {
        /// <summary>
        /// ToDo 입력 기능 수행
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public int CreateToDo(ToDoDTO dto)
        {
            int result = 0;

            // SqlConnection 객체 생성 
            SqlConnection conn = DBConnection.GetConnection();

            // open
            conn.Open();

            // 작업 객체 생성
            SqlCommand cmd = new SqlCommand();

            // Connection 정의 = conn
            cmd.Connection = conn;

            // CommandType 정의 = StoredProcedure
            cmd.CommandType = CommandType.StoredProcedure;

            // CommandText = "프로시저명"
            cmd.CommandText = "TODO_C";

            // 파라미터 전달
            cmd.Parameters.AddWithValue("@U_TODO", dto.u_todo);

            // 작업 실행
            result = (int)cmd.ExecuteNonQuery();

            // close
            conn.Close();

            // 입력 성공 시 1반환(단일 데이터입력)
            if (result > 0)
                return result;

            return -1;

        }

        /// <summary>
        /// ToDo 조회 기능 수행
        /// </summary>
        /// <returns></returns>
        public DataSet ReadToDo()
        {
            // List<ToDoDTO> 생성
            //List<ToDoDTO> result = new List<ToDoDTO>();

            // 결과를 담을 DataSet 생성
            DataSet result = new DataSet();

            // SqlConnection 생성
            SqlConnection conn = DBConnection.GetConnection();

            // open
            conn.Open();

            // 작업객체 생성
            SqlCommand cmd = new SqlCommand();

            // Connection 정의
            cmd.Connection = conn;

            // CommandType 정의
            cmd.CommandType = CommandType.StoredProcedure;

            // CommandText 정의
            cmd.CommandText = "TODO_R";

            // SqlDataAdapter 생성 및 SelectCommand 정의
            SqlDataAdapter da = new SqlDataAdapter()
            {
                SelectCommand = cmd
            };

            // ds 에 table 담기
            da.Fill(result, "TB_TODO");

            // close
            conn.Close();

            //// 받아온 데이터가 있다면
            //if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //{
            //    // 반복문을 통해 Liste 에 담기
            //    foreach (DataRow row in ds.Tables[0].Rows)
            //    {
            //        ToDoDTO dto = new ToDoDTO();

            //        dto.todo_id = (int)row["TODO_ID"];
            //        dto.u_todo =  row["U_TODO"].ToString();
            //        dto.todo_status = row["TODO_STATUS"].ToString();

            //        result.Add(dto);
            //    }
            //}

            return result;
        }


        /// <summary>
        /// ToDo 수정 기능 수행
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public int UpdateToDo(ToDoDTO dto)
        {
            int result = 0;

            // SqlConnection 객체 생성 
            SqlConnection conn = DBConnection.GetConnection();

            // open
            conn.Open();

            // 작업 객체 생성
            SqlCommand cmd = new SqlCommand();

            // Connection 정의 = conn
            cmd.Connection = conn;

            // CommandType 정의 = StoredProcedure
            cmd.CommandType = CommandType.StoredProcedure;

            // CommandText = "프로시저명"
            cmd.CommandText = "TODO_U";

            // 파라미터 전달
            cmd.Parameters.AddWithValue("@TODO_ID", dto.todo_id);
            cmd.Parameters.AddWithValue("@TODO_STATUS", dto.todo_status);

            // 작업 실행
            result = (int)cmd.ExecuteNonQuery();

            // close
            conn.Close();

            // 입력 성공 시 1반환(단일 데이터수정)
            if (result > 0)
                return result;


            return -1;
        }

        /// <summary>
        /// ToDo 삭제 기능 수행
        /// </summary>
        /// <param name="todo_id"></param>
        /// <returns></returns>
        public int DeleteToDO(int todo_id)
        {
            int result = 0;

            // SqlConnection 객체 생성 
            SqlConnection conn = DBConnection.GetConnection();

            // open
            conn.Open();

            // 작업 객체 생성
            SqlCommand cmd = new SqlCommand();

            // Connection 정의 = conn
            cmd.Connection = conn;

            // CommandType 정의 = StoredProcedure
            cmd.CommandType = CommandType.StoredProcedure;

            // CommandText = "프로시저명"
            cmd.CommandText = "TODO_D";

            // 파라미터 전달
            cmd.Parameters.AddWithValue("@TODO_ID", todo_id);
            
            // 작업 실행
            result = (int)cmd.ExecuteNonQuery();

            // close
            conn.Close();

            // 입력 성공 시 1반환(단일 데이터수정)
            if (result > 0)
                return result;

            return result;
        }
    }
}