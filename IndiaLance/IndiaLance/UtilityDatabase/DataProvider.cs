
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using IndiaLance.Models;
namespace IndiaLance.UtilityDatabase
{
    public class DataProvider
    {
        public static ProjectType getdatabyid(int id)
        {
            ProjectType projects = new ProjectType();
            string ITTech = null;
            string Designmedia = null; 
            string dataentry = null;
            string Engg = null;
            SqlConnection myConnection = DBUtility.getConnection();
            using (myConnection)
            {
                myConnection.Open();
                SqlCommand objCommand = new SqlCommand();
                objCommand.Connection = myConnection;
                objCommand.CommandType = CommandType.Text;
                objCommand.CommandText = "SELECT * FROM Projects1 where ID="+id;
                SqlDataReader reader = objCommand.ExecuteReader();
                while (reader.Read())
                {
                    ITTech = reader["ITTech"].ToString();
                    Designmedia = reader["DesignMedia"].ToString();
                    dataentry = reader["DataEntry"].ToString();
                    Engg = reader["Engg"].ToString();
                }
                projects.ITTech = ITTech;
                projects.Designmedia = Designmedia;
                projects.Dataentry = dataentry;
                projects.Engg = Engg;
                myConnection.Close();
                return projects;
            }
        }

        public static List<string> getAllITTech()
        {
            ProjectType projects = new ProjectType();
            List<string> ITTech = new List<string>();
           // string[] ITTech = new string[4];
            SqlConnection myConnection = DBUtility.getConnection();
            using (myConnection)
            {
                myConnection.Open();
                SqlCommand objCommand = new SqlCommand();
                objCommand.Connection = myConnection;
                objCommand.CommandType = CommandType.Text;
                objCommand.CommandText = "SELECT ITTech FROM Projects1";
                SqlDataReader reader = objCommand.ExecuteReader();
                for (int i = 0; reader.Read(); i++ )
                    {
                        ITTech.Add(reader["ITTech"].ToString());
                    }
                
                myConnection.Close();
                return ITTech;
            }
        }
        public static List<string> getAllDesignmedia()
        {
            ProjectType projects = new ProjectType();
            List<string> Designmedia = new List<string>();
            SqlConnection myConnection = DBUtility.getConnection();
            using (myConnection)
            {
                myConnection.Open();
                SqlCommand objCommand = new SqlCommand();
                objCommand.Connection = myConnection;
                objCommand.CommandType = CommandType.Text;
                objCommand.CommandText = "SELECT DesignMedia FROM Projects1";
                SqlDataReader reader = objCommand.ExecuteReader();
                for (int i = 0; reader.Read(); i++)
                {
                    Designmedia.Add(reader["DesignMedia"].ToString());
                }

                myConnection.Close();
                return Designmedia;
            }
        }
        public static List<string> getAllDataEntry()
        {
            ProjectType projects = new ProjectType();
            List<string> Dataentry = new List<string>();
            SqlConnection myConnection = DBUtility.getConnection();
            using (myConnection)
            {
                myConnection.Open();
                SqlCommand objCommand = new SqlCommand();
                objCommand.Connection = myConnection;
                objCommand.CommandType = CommandType.Text;
                objCommand.CommandText = "SELECT DataEntry FROM Projects1";
                SqlDataReader reader = objCommand.ExecuteReader();
                for (int i = 0; reader.Read(); i++)
                {
                    Dataentry.Add(reader["DataEntry"].ToString());
                }

                myConnection.Close();
                return Dataentry;
            }
        }
        public static List<string> getAllEngg()
        {
            ProjectType projects = new ProjectType();
            List<string> Engg = new List<string>();
            SqlConnection myConnection = DBUtility.getConnection();
            using (myConnection)
            {
                myConnection.Open();
                SqlCommand objCommand = new SqlCommand();
                objCommand.Connection = myConnection;
                objCommand.CommandType = CommandType.Text;
                objCommand.CommandText = "SELECT Engg FROM Projects1";
                SqlDataReader reader = objCommand.ExecuteReader();
                for (int i = 0; reader.Read(); i++)
                {
                    Engg.Add(reader["Engg"].ToString());
                }

                myConnection.Close();
                return Engg;
            }
        }

        public static ItTech itTech(int id)
        {
            ItTech itobj = new ItTech();
            SqlConnection myConnection = DBUtility.getConnection();
            using (myConnection)
            {
                myConnection.Open();
                SqlCommand objCommand = new SqlCommand();
                objCommand.Connection = myConnection;
                objCommand.CommandType = CommandType.Text;
                objCommand.CommandText = "SELECT * FROM ITTech where ID="+id;
                SqlDataReader reader = objCommand.ExecuteReader();
                for (int i = 0; reader.Read(); i++)
                {
                    itobj.Posts = (int)reader["Posts"];
                    itobj.Projects = reader["Projects"].ToString();
                }

                myConnection.Close();
                return itobj;
            }
        }

        public static ItTech dmedia(int id)
        {
            ItTech itobj = new ItTech();
            SqlConnection myConnection = DBUtility.getConnection();
            using (myConnection)
            {
                myConnection.Open();
                SqlCommand objCommand = new SqlCommand();
                objCommand.Connection = myConnection;
                objCommand.CommandType = CommandType.Text;
                objCommand.CommandText = "SELECT * FROM DesignMedia where ID=" + id;
                SqlDataReader reader = objCommand.ExecuteReader();
                for (int i = 0; reader.Read(); i++)
                {
                    itobj.Posts = (int)reader["Posts"];
                    itobj.Projects = reader["Projects"].ToString();
                }

                myConnection.Close();
                return itobj;
            }
        }
        public static ItTech dentry(int id)
        {
            ItTech itobj = new ItTech();
            SqlConnection myConnection = DBUtility.getConnection();
            using (myConnection)
            {
                myConnection.Open();
                SqlCommand objCommand = new SqlCommand();
                objCommand.Connection = myConnection;
                objCommand.CommandType = CommandType.Text;
                objCommand.CommandText = "SELECT * FROM DataEntry where ID=" + id;
                SqlDataReader reader = objCommand.ExecuteReader();
                for (int i = 0; reader.Read(); i++)
                {
                    itobj.Posts = (int)reader["Posts"];
                    itobj.Projects = reader["Projects"].ToString();
                }

                myConnection.Close();
                return itobj;
            }
        }

        public static ItTech Engg(int id)
        {
            ItTech itobj = new ItTech();
            SqlConnection myConnection = DBUtility.getConnection();
            using (myConnection)
            {
                myConnection.Open();
                SqlCommand objCommand = new SqlCommand();
                objCommand.Connection = myConnection;
                objCommand.CommandType = CommandType.Text;
                objCommand.CommandText = "SELECT * FROM Engg where ID=" + id;
                SqlDataReader reader = objCommand.ExecuteReader();
                for (int i = 0; reader.Read(); i++)
                {
                    itobj.Posts = (int)reader["Posts"];
                    itobj.Projects = reader["Projects"].ToString();
                }

                myConnection.Close();
                return itobj;
            }
        }

        public static void InsertJava(JavaSec obj , string tech)
        {
            JavaSec objjavasec = new JavaSec();
            string storeprocedure = "InsertRecordJava";
            int type1 = 0;
            switch (tech.Trim())
            {
                case "Java":
                    type1 = 1;
                    break;
                case "net":
                    type1 = 2;
                    break;
                case "Oracle":
                    type1 = 3;
                    break;
                case "Python":
                    type1 = 4;
                    break;
                case "SAP":
                    type1 = 5;
                    break;
                case "Android":
                    type1 = 6;
                    break;
            }
            SqlConnection myConnection = DBUtility.getConnection();
            using (myConnection)
            {
                myConnection.Open();
                SqlCommand objCommand = new SqlCommand(storeprocedure,myConnection);
                objCommand.Connection = myConnection;
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.Add("@ProjectId", SqlDbType.Int).Value = obj.projectId;
                objCommand.Parameters.Add("@Amount", SqlDbType.Int).Value = obj.amount;
                objCommand.Parameters.Add("@Details", SqlDbType.Text).Value = obj.details;
                objCommand.Parameters.Add("@IsAvail", SqlDbType.VarChar).Value = obj.isValid;
                objCommand.Parameters.Add("@ittype", SqlDbType.Int).Value = type1;
                objCommand.ExecuteNonQuery();
                myConnection.Close();
            }
        }


    }
}