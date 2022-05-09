using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace UserProfileApi.DAC
{
    public static class ConString
    {
        public static string StringVal()
        {
            return "server=" + ConfigurationManager.AppSettings["DBServer"] + ";uid=floraweb;pwd=platinumfloor967;database=SCBEFT";
        }
    }

    public class OAuthCheckerDb
    {
        public void CheckClientSecret(string clientId, string clientSecret, out string ErrMsg)
        {
            SqlConnection sqlConnection = new SqlConnection(ConString.StringVal());
            SqlCommand sqlCommand = new SqlCommand("UP_CheckClientSecret", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter sqlParameter = new SqlParameter("@ClientId", SqlDbType.VarChar, 50);
            sqlParameter.Value = clientId;
            sqlCommand.Parameters.Add(sqlParameter);

            SqlParameter sqlParameter2 = new SqlParameter("@ClientSecret", SqlDbType.VarChar, 255);
            sqlParameter2.Value = clientSecret;
            sqlCommand.Parameters.Add(sqlParameter2);

            SqlParameter sqlParameter3 = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 100);
            sqlParameter3.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(sqlParameter3);
            
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();

            ErrMsg = sqlParameter3.Value.ToString();

            sqlCommand.Dispose();
            sqlConnection.Close();
            sqlConnection.Dispose();
        }
    }
}