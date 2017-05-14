using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MpathY.Models;
using MpathY.ViewModels;
using System.Net.Mail;
using System.Net;

namespace MpathY.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(SearchByTypeReq req)
        {
            var conn = new wholeOrgList(req);
            return View(conn);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SearchBtn(SearchByTypeReq req)
        {
            
            return View(req);
        }

        public ActionResult testView(SearchByTypeReq req)
        {
            var conn = new orgtypedb(req);



            return View(conn);
        }
        //public ActionResult Form(SearchByTypeReq req)
        //{
        //    var conn = new wholeOrgList(req);
        //    return View(conn);
        //}
        [HttpPost]
        public ActionResult Form(string userName, string userEmail, string userNumber, string userSubject, string userMsg)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MailMessage mail = new MailMessage();

                    mail.To.Add("empathi.amaze@gmail.com");
                    mail.From = new MailAddress("empathi.amaze@gmail.com","amaze");
                    mail.Subject = "sub";

                    mail.Body = "asdf";

                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.monash.edu.au"; //Or Your SMTP Server Address
                    smtp.Credentials = new System.Net.NetworkCredential("empathi.amaze@gmail.com", "teamamze"); // ***use valid credentials***
                    smtp.Port = 456;

                    //Or your Smtp Email ID and Password
                    smtp.EnableSsl = true;
                    //smtp.Send(mail);
                }
            }
            catch(Exception e)
            {
               ViewBag.Error = "There are some errors in sending e-mail." + e.StackTrace +e.Message;
                Console.WriteLine(e.StackTrace + e.Message);
            }
            
            return View();
        }

       // OleDbConnection myConn = dbconn.GetConnection();
        
    }
}