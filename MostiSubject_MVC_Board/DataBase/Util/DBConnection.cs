using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace MostiSubject_MVC_Board.DataBase.Util
{
    /// <summary>
    /// DataBase Connection 클래스
    /// SqlConnection 사용
    /// ConnectionString => MyToDoList > Web.config
    /// </summary>
    public class DBConnection
    {
        /// <summary>
        /// SqlConnection 객체 생성
        /// </summary>
        private static SqlConnection conn;

        /// <summary>
        /// DBConnection default 생성자
        /// </summary>
        public DBConnection()
        {

        }

        /// <summary>
        /// GetConnection()
        /// Local DataBase 의 Connection 을 얻어내는 기능 수행
        /// </summary>
        /// <returns>SqlConnection</returns>
        #region GetConnection()
        public static SqlConnection GetConnection()
        {
            if (conn == null)
            {
                try
                {
                    conn = new SqlConnection(ConfigurationManager.ConnectionStrings["testData"].ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    // web.config set
                }
            }

            return conn;
        }
        #endregion

        /// <summary>
        /// SqlConnection 을 close()
        /// </summary>
        #region Close()
        public static void Close()
        {
            if (conn != null)
            {
                try
                {
                    if (conn.State.Equals("Open"))
                    {
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                conn = null;
            }
        }
        #endregion

    }
}