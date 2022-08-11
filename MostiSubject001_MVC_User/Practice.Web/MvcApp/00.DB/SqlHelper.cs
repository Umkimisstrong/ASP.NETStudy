using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MvcApp.DB
{
    public class SqlHelper
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public SqlHelper()
        {

        }

        /// <summary>
        /// 쿼리문을 실행하고 DataSet을 반환
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="spName"></param>
        /// <param name="paramSource"></param>
        /// <returns></returns>
        public static DataSet ExecuteFillDataSet(string ConnnectionString, string spName, Dictionary<string, object> paramSource)
        {
            DataSet ds = new DataSet();

            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings[ConnnectionString]?.ConnectionString;
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(spName, sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandTimeout = 30;
                    sqlCommand.Parameters.AddRange(ToSqlParams(paramSource));

                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                    adapter.Fill(ds);
                }

                sqlConnection.Close();
            }

            return ds;
        }

        /// <summary>
        /// 쿼리문을 실행하고 영향받은 행 수를 반환 합니다.
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="spName"></param>
        /// <param name="paramSource"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string ConnnectionString, string spName, Dictionary<string, object> paramSource)
        {
            int iResult = -1;

            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings[ConnnectionString]?.ConnectionString;
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(spName, sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandTimeout = 30;

                    sqlCommand.Parameters.AddRange(ToSqlParams(paramSource));

                    iResult = sqlCommand.ExecuteNonQuery();
                }

                sqlConnection.Close();
            }

            return iResult;
        }

        /// <summary>
        /// Sql파라미터로 값으로 변경합니다.
        /// </summary>
        /// <param name="paramSource"></param>
        /// <returns></returns>
        public static SqlParameter[] ToSqlParams(Dictionary<string, object> paramSource)
        {
            SqlParameter[] sqlParams = new SqlParameter[paramSource.Count];
            int i = 0;
            foreach (KeyValuePair<string, object> item in paramSource)
            {
                sqlParams[i] = new SqlParameter();
                sqlParams[i].ParameterName = item.Key;
                sqlParams[i].Value = item.Value;

                i += 1;
            }

            return sqlParams;
        }
    }
}