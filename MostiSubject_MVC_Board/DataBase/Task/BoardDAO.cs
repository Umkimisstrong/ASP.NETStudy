using MostiSubject_MVC_Board.DataBase.Util;
using MostiSubject_MVC_Board.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


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
        protected static SqlConnection conn;

        /// <summary>
        /// List<Board> ReadBoard(BoardRequest request)
        /// 게시물 리스트를 조회하는 메소드
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        #region ReadBoard(BoardRequest request)
        public List<Board> ReadBoard(BoardRequest request)
        {
            List<Board> boardList = new List<Board>();

            // 검색조건과 검색어가 없다면 기본값 부여
            if (string.IsNullOrEmpty(request.search_type))
                request.search_type = "BOARD_TITLE";

            if (string.IsNullOrEmpty(request.search_word))
                request.search_word = "%%";
            else
                request.search_word = "%" + request.search_word + "%";
            
            conn = DBConnection.GetConnection();


            DataSet ds = new DataSet();

            // SqlCommand 작업객체 생성
            SqlCommand cmd = new SqlCommand();

            // SqlCommand 속성 정의
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "BOARD_R";

            // 파라미터 설정
            cmd.Parameters.AddWithValue("@SEARCH_TYPE", request.search_type);
            cmd.Parameters.AddWithValue("@SEARCH_WORD", request.search_word);


            try
            {
                conn.Open();

                SqlDataAdapter sda = new SqlDataAdapter()
                {
                    SelectCommand = cmd
                };

                sda.Fill(ds, "BOARD_VIEW");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            // 받아온 데이터가 존재한다면
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Board board = new Board();

                    // 객체들에 담기
                    board.rownum        = int.Parse(row["ROWNUM"].ToString());
                    board.board_id      = int.Parse(row["BOARD_ID"].ToString());
                    board.title         = row["BOARD_TITlE"].ToString();
                    board.u_id          = row["U_ID"].ToString();
                    board.board_date    = (DateTime)row["BOARD_DATE"];
                    board.fileName      = row["FILES"].ToString();


                    boardList.Add(board);

                }
            }
            
            return boardList;

        }
        #endregion



        /// <summary>
        /// Board ReadBoard(int board_id)
        /// 단일 게시물을 조회하는 메소드
        /// </summary>
        /// <param name="board_id"></param>
        /// <returns></returns>
        #region ReadBoard(int board_id)
        public Board ReadBoard(int board_id)
        {
            Board board = new Board();

            // SqlConnection 객체 생성
            conn = DBConnection.GetConnection();

            // SqlCommand 작업객체 생성
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = string.Format("SELECT" +
                                                    " BOARD_ID" +
                                                    ", BOARD_TITLE" +
                                                    ", BOARD_CONTENT" +
                                                    ", BOARD_HITCOUNT" +
                                                    ", BOARD_DATE" +
                                                    ", U_ID" +
                                                    ", DEL_CHECK" +
                                                    ", FILES" +
                                             " FROM TB_BOARD" +
                                             " WHERE BOARD_ID = {0}"        // board_id 입력
                                            , board_id.ToString());

            try
            {
                conn.Open();

                // SqlDataAdapter 객체 생성
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "TB_BOARD");

                if (ds.Tables.Count > 0 && ds != null)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {

                        board.board_id = (int)row["BOARD_ID"];
                        board.title = row["BOARD_TITLE"].ToString();
                        board.content = row["BOARD_CONTENT"].ToString();
                        board.hitCount = (int)row["BOARD_HITCOUNT"];
                        board.board_date = (DateTime)row["BOARD_DATE"];
                        board.u_id = row["U_ID"].ToString();
                        board.del_check = (int)row["DEL_CHECK"];
                        board.fileName = row["FILES"].ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();   
            }


            return board;
        }
        #endregion


        /// <summary>
        /// int CreateBoard(Board board)
        /// 게시물을 입력하는 메소드
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        #region CreateBoard(Board board)
        public int CreateBoard(Board board)
        {
            int result = 0;
            
            // File 업로드 준비

            FileSystem fs = new FileSystem();
            FileStatus fst = fs.File_Upload(board.files);

            // FileStatus 가 true 라면 db에 업로드
            // FileStatus 는
            //              ▶ 업로드된 파일이 없거나
            //              ▶ 업로드가 정상적으로 된 경우만 true 
            if (fst.check)
            {
                // SqlConnection 객체 생성
                conn = DBConnection.GetConnection();

                // SqlCommand 객체 생성
                SqlCommand cmd = new SqlCommand();

                // Command 속성 정의
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "BOARD_C";

                // 파라미터 설정
                cmd.Parameters.AddWithValue("@BOARD_TITLE", board.title);
                cmd.Parameters.AddWithValue("@BOARD_CONTENT", board.content);
                cmd.Parameters.AddWithValue("@U_ID", board.u_id);
                cmd.Parameters.AddWithValue("@FILES", fst.fileName);

                try
                {
                    conn.Open();
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    conn.Close();
                }

            }
            // 파일이 정상적으로 업로드 되지 않았다면 DB에 데이터 입력을 실행하지 않는다.
            else
            {
                return -1;
            }
            

            if (result > 0)
                return result;
            else
                return -1;
        }
        #endregion

        
        /// <summary>
        /// int DeleteBoard(int board_id)
        /// 게시물을 삭제하는 메소드
        /// </summary>
        /// <param name="board_id"></param>
        /// <returns></returns>
        public int DeleteBoard(int board_id) 
        {
            int result = 0;

            conn = DBConnection.GetConnection();

            SqlCommand cmd = new SqlCommand();

            
            try
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "BOARD_D";
                cmd.Parameters.AddWithValue("@BOARD_ID", board_id);
                conn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            

            if(result > 0)
                return result;

            return -1;

        }


        /// <summary>
        /// int UpdateBoard(Board board)
        /// 게시물을 수정하는 메소드
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public int UpdateBoard(Board board)
        {
            int result = 0;

            conn = DBConnection.GetConnection();

            SqlCommand cmd = new SqlCommand();
            try
            {

                // File 업로드 준비

                FileSystem fs = new FileSystem();
                FileStatus fst = fs.File_Upload(board.files);

                // FileStatus 가 true 라면 db에 업로드
                // FileStatus 는
                //              ▶ 업로드된 파일이 없거나
                //              ▶ 업로드가 정상적으로 된 경우만 true 
                if (fst.check)
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "BOARD_U";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BOARD_ID", board.board_id);
                    cmd.Parameters.AddWithValue("@BOARD_TITLE", board.title);
                    cmd.Parameters.AddWithValue("@BOARD_CONTENT", board.content);
                    cmd.Parameters.AddWithValue("@FILES", fst.fileName);
                    conn.Open();
                    result = cmd.ExecuteNonQuery();
                }
                else
                {
                    return -1;
                }


                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            if (result > 0)
                return result;


            return -1;
        }
    }
}