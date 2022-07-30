using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Properties;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1
{
    public partial class DBConnTest001 : System.Web.UI.Page
    {
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            string sql = "SELECT U_NAME FROM TB_USER";
            SqlConnection conn =  DBConn.GetConnection();
            conn.Open();
            // 작업객체 생성
            SqlCommand sc = new SqlCommand();
            sc.Connection = conn;

            sc.CommandText = sql;

            sc.CommandType = CommandType.Text;

            // 결과집합 얻어오기 위한 Reader 선언
            SqlDataReader rd = sc.ExecuteReader();
            
            try
            {
                List<string> result = new List<string>();
                // 하나의 레코드를 읽음
                // java ResultSet 의 rs.next()
                while (rd.Read())
                {
                    string name = rd["U_NAME"].ToString();
                    result.Add(name);
                }

                foreach (string name in result)
                {
                    TableRow tr;
                    TableCell td;

                    tr = new TableRow();
                    td = new TableCell();
                    td.Text = "이름 : " + name;
                    tr.Cells.Add(td);
                    nameTable.Rows.Add(tr);

                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally 
            {
                rd.Close();
                DBConn.Close();
            }

        }
    }
}