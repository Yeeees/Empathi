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
    /*
     * This is the Home page controller.
     * Defines all the action within home page.
     */
    public class HomeController : Controller
    {
        //Call index page
        public ActionResult Index(SearchByTypeReq req)
        {
            var conn = new wholeOrgList(req);
            return View(conn);
        }
        //Call About page
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        //Call Contact page
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //Call Search page
        public ActionResult Search()
        {
            return View();
        }
        //Search button for iteration 1
        [HttpPost]
        public ActionResult SearchBtn(SearchByTypeReq req)
        {
            
            return View(req);
        }
        //Search result for iteration 1
        public ActionResult testView(SearchByTypeReq req)
        {
            var conn = new orgtypedb(req);



            return View(conn);
        }
        
       
    }
}