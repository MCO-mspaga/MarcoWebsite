using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MarcoWebsite.Models;

namespace MarcoWebsite.Controllers
{
    public class EmploymentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Index (string industryType, string searchString)
        {
            var industryList = new List<string>();

            var industryQry = from i in db.Employments
                              orderby i.Industry
                              select i.Industry;

            industryList.AddRange(industryQry.Distinct());
            ViewBag.industryType = new SelectList(industryList);

            var employer = from e in db.Employments
                           select e;


            if (!String.IsNullOrEmpty(searchString))
            {
                employer = employer.Where(e => e.Title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(industryType))
            {
                employer = employer.Where(x => x.Industry == industryType);
            }

            return View(employer);
        }
        // GET: Employments


        // GET: Employments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employment employment = db.Employments.Find(id);
            if (employment == null)
            {
                return HttpNotFound();
            }
            return View(employment);
        }

        // GET: Employments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,StartDate,EndDate,Description")] Employment employment)
        {
            if (ModelState.IsValid)
            {
                db.Employments.Add(employment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employment);
        }

        // GET: Employments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employment employment = db.Employments.Find(id);
            if (employment == null)
            {
                return HttpNotFound();
            }
            return View(employment);
        }

        // POST: Employments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,StartDate,EndDate,Description")] Employment employment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employment);
        }

        // GET: Employments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employment employment = db.Employments.Find(id);
            if (employment == null)
            {
                return HttpNotFound();
            }
            return View(employment);
        }

        // POST: Employments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employment employment = db.Employments.Find(id);
            db.Employments.Remove(employment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
