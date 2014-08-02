using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IndiaLance.UtilityDatabase
{
    public class DBUtility
    {
        public static SqlConnection getConnection()
        {
            SqlConnection objSqlconnection = null;
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["DataProvider"];

            if (settings != null)
            {
                objSqlconnection = new SqlConnection();
                objSqlconnection.ConnectionString = settings.ConnectionString;
            }
            return objSqlconnection;
        }
    }
}