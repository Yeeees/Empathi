using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace MpathY.Models
{
    public class orgtypedb
    {
        public static OleDbConnection conn;
        public SearchByTypeReq request;
        public orgtypedb(SearchByTypeReq req)
        {
            request = req;
            // OleDbConnection conn = GetConnection();
        }
        public OleDbConnection getConn()
        {
            return conn;
        }
        //public static OleDbConnection GetConnection()
        public List<string> GetConnection()
        {
            string conn_str = System.Configuration.ConfigurationManager.AppSettings["ConnString"].ToString() + System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["dbPath"]) + ";";
            OleDbConnection conn = new OleDbConnection(conn_str);
            
            List<string> orgList = new List<string>();
            conn.Open();
            OleDbCommand select = new OleDbCommand();
            select.Connection = conn;
            string query = "Select distinct Organisation_Name From Organization where Organisation_ID in (select Organization_ID from Search where ";
            List<string> ls = new List<string>();
            if (request.Monetary_Job)
                ls.Add("1");
            if (request.Volunteer)
                ls.Add("2");
            if (request.English_Education)
                ls.Add("3");
            if (request.Health)
                ls.Add("4");
            if (request.Accommodation)
                ls.Add("5");
            if (request.Legal_Service)
                ls.Add("6");
            if (request.Personal_Care_Food)
                ls.Add("7");
            if (request.Drug_alcohol_Counselling)
                ls.Add("8");
            if (request.Humanitarian_Settlement)
                ls.Add("9");

            if (ls.Count != 0)
            {
                query += "Classification_ID =" + ls[0];
                if (ls.Count > 1)
                {
                    foreach (var it in ls)
                    {
                        query += " or Classification_ID =" + it;
                    }
                }


                query += ");";

                //    select.CommandText = "Select Organisation_Name From Organization where Organisation_ID in (select Organization_ID from Search where Classification_ID = 7);";

                select.CommandText = query;

                OleDbDataReader reader = select.ExecuteReader();
                while (reader.Read())
                {
                    orgList.Add(reader[0].ToString());
                }
            }
            conn.Close();

            return orgList;
            //return conn;
        }
        public List<string> selectStatement(OleDbConnection conne)
        {
            List<string> orgList = new List<string>();
            conne.Open();
            OleDbCommand select = new OleDbCommand();
            select.Connection = conne;
            select.CommandText = "Select Organisation_Name From Organization;";
            OleDbDataReader reader = select.ExecuteReader();
            while (reader.Read())
            {
                orgList.Add(reader[1].ToString());
            }
            conne.Close();
            return orgList;
        }
    }
}