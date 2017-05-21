using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace MpathY.Controllers
{
    //This class is for connection between system and Access database
    public class dbconn
    {
        public static OleDbConnection GetConnection()
        {
            string conn_str = System.Configuration.ConfigurationManager.AppSettings["ConnString"].ToString() + System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["dbPath"]) + ";";
            OleDbConnection conn = new OleDbConnection(conn_str);
           
            return conn;
        }
    }
}