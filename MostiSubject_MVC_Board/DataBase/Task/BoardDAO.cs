using MostiSubject_MVC_Board.DataBase.Util;
using MostiSubject_MVC_Board.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MostiSubject_MVC_Board.DataBase.Task
{
    /// <summary>
    /// BoardDAO
    /// 게시판 CRUD 작업 기능 수행
    /// </summary>
    public class BoardDAO
    {
        /// <summary>
        /// SqlConnection
        /// DB 연결을 위한 객체
        /// </summary>
        private static SqlConnection conn;

        /// <summary>
        /// List<Board> ReadBoard(string search_type, string search_value)
        /// </summary>
        /// <param name="search_type"></param>
        /// <param name="search_value"></param>
        /// <returns></returns>
        public List<Board> ReadBoard(string search_type, string search_value)
        {
            List<Board> boardList = new List<Board>();

            // 검색조건과 검색어가 없다면 기본값 부여
            if (string.IsNullOrEmpty(search_type))
                search_type = "BAORD_TITLE";

            if (string.IsNullOrEmpty(search_value))
                search_value = "%%";

            conn = DBConnection.GetConnection();

            conn.Open();

            DataSet ds = new DataSet();

            try
            {
                
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "BOARD_R";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SEARCH_TYPE", search_type);
                cmd.Parameters.AddWithValue("@SEARCH_VALUE", search_value);

                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                sda.Fill(ds, "TB_BOARD");
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            if (ds.Tables.Count > 0 && ds != null)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Board board = new Board();

                    // 객체들에 담기
                    board.board_id = int.Parse(row["BOARD_ID"].ToString());
                    board.title = row["BOARD_TITle"].ToString();
                    board.u_id = row["U_ID"].ToString();

                }
            }
            


            return boardList;

        }



    }
}