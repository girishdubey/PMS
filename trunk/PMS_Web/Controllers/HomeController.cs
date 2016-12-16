using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS_Entity;

namespace PMS_Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult SaveData()
        {
            using (var db = new PMSDBContext())
            {
            }
            return View();
        }

        //public ActionResult Header()
        //{
        //    List<PMS_Entity.Model.Master.Employee> _emp = new List<PMS_Entity.Model.Master.Employee>();
        //    return PartialView(_emp);
        //}

    }
}