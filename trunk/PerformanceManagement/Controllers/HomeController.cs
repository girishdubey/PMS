﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMSEntity;

namespace PerformanceManagement.Controllers
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
            using (var db = new PerformanceManagementDBContext())
            {
            }
            return View();
        }

        //public ActionResult Header()
        //{
        //    List<PMSEntity.Model.Master.Employee> _emp = new List<PMSEntity.Model.Master.Employee>();
        //    return PartialView(_emp);
        //}

    }
}