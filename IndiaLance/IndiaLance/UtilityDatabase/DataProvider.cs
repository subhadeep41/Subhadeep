using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using IndiaLance.Models;

namespace IndiaLance.UtilityDatabase
{
    public class DataProvider
    {
        //get the connection string from web.config
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
    }
}