using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.Properties
{
    public class DBConn
    {

        private static SqlConnection dbConn;

        // 생성자
        public DBConn()
        {
        }

        // getConnection()
        public static SqlConnection GetConnection()
        {

            if(dbConn == null)
            { 
                try
                {
                    // 커넥션 스트링 입력
                    string connectionString = "Data Source=localhost;" + "Initial Catalog=TEST_KSK;" + "User Id=mosti_ksk;" + "Password=mosti006$;" + "Integrated Security=True;";

                    // 커넥션 객체 생성
                    dbConn = new SqlConnection(connectionString);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    
                }
            }

            return dbConn;
            
        }

        // void close()
        public static void Close()
        { 
            if(dbConn !=null)
            {
                try
                {
                    if (dbConn.State.Equals("Open"))
                    {
                        dbConn.Close();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

                dbConn = null;
            }
            

        }
    }
}