using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS_Entity;
using PMS_Entity.Model.Master;

namespace PMS_Api.Controllers
{
    public class ClientRegistrationController : Controller
    {
        private PerformanceManagementDBContext db = new PerformanceManagementDBContext();

        //
        // GET: /ClientRegistration/

        public ActionResult Index()
        {
            return View(db.ClientRegistrations.ToList());
        }

        //
        // GET: /ClientRegistration/Details/5

        public ActionResult Details(long id = 0)
        {
            ClientRegistration clientregistration = db.ClientRegistrations.Find(id);
            if (clientregistration == null)
            {
                return HttpNotFound();
            }
            return View(clientregistration);
        }

        //
        // GET: /ClientRegistration/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ClientRegistration/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientRegistration clientregistration)
        {
            if (ModelState.IsValid)
            {
                db.ClientRegistrations.Add(clientregistration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientregistration);
        }

        //
        // GET: /ClientRegistration/Edit/5

        public ActionResult Edit(long id = 0)
        {
            ClientRegistration clientregistration = db.ClientRegistrations.Find(id);
            if (clientregistration == null)
            {
                return HttpNotFound();
            }
            return View(clientregistration);
        }

        //
        // POST: /ClientRegistration/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClientRegistration clientregistration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientregistration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientregistration);
        }

        //
        // GET: /ClientRegistration/Delete/5

        public ActionResult Delete(long id = 0)
        {
            ClientRegistration clientregistration = db.ClientRegistrations.Find(id);
            if (clientregistration == null)
            {
                return HttpNotFound();
            }
            return View(clientregistration);
        }

        //
        // POST: /ClientRegistration/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ClientRegistration clientregistration = db.ClientRegistrations.Find(id);
            db.ClientRegistrations.Remove(clientregistration);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}