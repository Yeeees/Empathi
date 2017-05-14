using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MpathY.Models;
using MpathY.ViewModels;
using System.Data;
using System.Data.OleDb;

namespace MpathY.Controllers
{
    public class OrgController : Controller
    {
      
        
       public ActionResult testView(SearchByTypeReq req)
        {
            var conn = new orgtypedb(req);
           

           
           return View(conn);
        }
        
        //
        // GET: /Org/ShowName
        public ActionResult ShowName()
        {
            var Org = new Organisation() { OrgId=1,Name="RefugeeOrgs"}; 
            return View(Org);
        }




        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        [Route("Org/created/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public  ActionResult ByCreateDate(int year,int month)
        {
            return Content(year+"/"+month);
        }

        public ActionResult PassToView()
        {
            var org = new Organisation() { OrgId = 2, Name = "testOrg" };
            
            return View(org);
        }

        public ActionResult ClassOrgView()
        {
            var org = new Organisation() { OrgId = 1, Name = "testOrg" };
            var type = new List<Classification> 
            {
                new Classification {Id =1,Name="Food"},
                new Classification {Id =2,Name="Medical"}
            };

            var ClassOrgModel = new ClassificationOrgModel
            {
                Org = org,
                Type = type
            };
            return View(ClassOrgModel);
        }
	}
}