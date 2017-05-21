using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace MpathY.Models
{
    //Get whole organisation list, in order to put these organisation into map.
    public class wholeOrgList
    {
        public static OleDbConnection conn;
        public SearchByTypeReq request;
        public wholeOrgList(SearchByTypeReq req)
        {
            request = req;
        }
        public OleDbConnection getConn()
        {
            return conn;
        }
        public List<Organisation> GetConnection()
        {
            string conn_str = System.Configuration.ConfigurationManager.AppSettings["ConnString"].ToString() + System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["dbPath"]) + ";";
            OleDbConnection conn = new OleDbConnection(conn_str);

            List<Organisation> orgList = new List<Organisation>();
            conn.Open();
            OleDbCommand select = new OleDbCommand();
            select.Connection = conn;
            string query = "Select distinct o.Organisation_Name,c.Classification_Name ,o.Address,o.Latitude,o.Longitude,o.Email,o.Phone_Number,o.Suburb,o.Postcode From Organization o,Classification c,Search s where o.Organisation_ID = s.Organization_ID and s.Classification_ID = c.Classification_ID ";

            select.CommandText = query;


            OleDbDataReader readerForOrg = select.ExecuteReader();
            while (readerForOrg.Read())
            {
                bool flag = false;//check whether the current organisation is existed in the list
                if (orgList.Count == 0)
                    flag = true;
                foreach (Organisation org in orgList)
                {
                    if (org.Name.Equals(readerForOrg[0].ToString()) && org.Address.Equals(readerForOrg[2].ToString()))
                    {
                        org.services.Add(readerForOrg[1].ToString());
                        org.servicesLine += readerForOrg[1].ToString() + " ";

                    }
                    else
                    {
                        flag = true;
                    }
                }
                if (flag)
                {
                    Organisation newOrg = new Organisation();
                    newOrg.Name = readerForOrg[0].ToString();

                    newOrg.Address = readerForOrg[2].ToString();
                    string test = readerForOrg[1].ToString();
                    newOrg.getServices().Add(readerForOrg[1].ToString());
                    newOrg.servicesLine += readerForOrg[1].ToString() + "";

                    newOrg.Latitude = readerForOrg[3].ToString();
                    newOrg.Longitude = readerForOrg[4].ToString();
                    newOrg.Email = readerForOrg[5].ToString();
                    newOrg.Phone_Number = readerForOrg[6].ToString();
                    newOrg.Suburb = readerForOrg[7].ToString();
                    newOrg.Postcode = readerForOrg[8].ToString();
                    orgList.Add(newOrg);
                }



            }

            conn.Close();

            return orgList;
        }

    }
}