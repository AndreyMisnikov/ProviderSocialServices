using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProviderSocialServices;

namespace ProviderSocialServices.Controllers
{
    public class OrganizationsController : Controller
    {
        private OrganizationsEntities db = new OrganizationsEntities();

        // GET: Organizations
        public ActionResult Index()
        {
            var organization = db.Organization.Include(o => o.OrganizationLegalForm);
            return View(organization.ToList());
        }

        // GET: Organizations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = db.Organization.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // GET: Organizations/Create
        public ActionResult Create()
        {
            ViewBag.Id_OrganizationLegalForm = new SelectList(db.OrganizationLegalForm, "Id_OrganizationLegalForm", "Name");
            return View();
        }

        // POST: Organizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Organization,Name,FullName,DateReg,Mission,Id_OrganizationLegalForm,MaterialTechnicalBase,SettlementAccount,ShortName")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                db.Organization.Add(organization);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_OrganizationLegalForm = new SelectList(db.OrganizationLegalForm, "Id_OrganizationLegalForm", "Name", organization.Id_OrganizationLegalForm);
            return View(organization);
        }

        // GET: Organizations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = db.Organization.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_OrganizationLegalForm = new SelectList(db.OrganizationLegalForm, "Id_OrganizationLegalForm", "Name", organization.Id_OrganizationLegalForm);
            return View(organization);
        }

        // POST: Organizations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Organization,Name,FullName,DateReg,Mission,Id_OrganizationLegalForm,MaterialTechnicalBase,SettlementAccount,ShortName")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_OrganizationLegalForm = new SelectList(db.OrganizationLegalForm, "Id_OrganizationLegalForm", "Name", organization.Id_OrganizationLegalForm);
            return View(organization);
        }

        // GET: Organizations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = db.Organization.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // POST: Organizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Organization organization = db.Organization.Find(id);
            db.Organization.Remove(organization);
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
