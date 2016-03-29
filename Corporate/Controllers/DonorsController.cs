using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Corporate.Models;

namespace Corporate.Controllers
{
    public class DonorsController : Controller
    {
        private CorporateContext db = new CorporateContext();

        // GET: Donors
        public ActionResult Index()
        {
            return View(db.Donors.ToList());
        }

        // GET: Donors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donor donor = db.Donors.Find(id);
            if (donor == null)
            {
                return HttpNotFound();
            }
            return View(donor);
        }

        //// GET: Donors/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        public ActionResult Create(int? id)
        {
            DonationViewModel model = new DonationViewModel();
            model.DonationID = id;
            return View(model);
        }

        // POST: Donors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DonationID,FirstName,LastName,Address1,Address2,State,Zipcode,Phone,Email,EmailUpdateFlag,Employer,Occupation,OccupationStatus")] DonationViewModel model)
        {

            if (ModelState.IsValid)
            {
                Donor donor = new Donor();
                donor.FirstName = model.FirstName;
                donor.LastName = model.LastName;
                donor.Address1 = model.Address1;
                donor.Address2 = model.Address2;
                donor.Zipcode = model.Zipcode;
                donor.State = model.State;
                donor.Phone = model.Phone;
                donor.Employer = model.Employer;
                donor.Occupation = model.Occupation;
                donor.OccupationStatus = model.OccupationStatus;
                donor.Email = model.Email;
                donor.EmailUpdateFlag = model.EmailUpdateFlag;
                db.Donors.Add(donor);
                db.SaveChanges();
                Session["DonorID"] = donor.DonorID;

                Donation donation = db.Donations.Find(model.DonationID);
                donation.DonorID = donor.DonorID;
                db.Entry(donation).State = EntityState.Modified;
                db.SaveChanges();

                Session["DonationID"] = donation.DonationID;

                var values = new System.Web.Routing.RouteValueDictionary();
                values.Add("donationID", donation.DonationID);
                values.Add("donorID", donor.DonorID);
                return RedirectToAction("Index", "Paypal", values);
            }

            return View(model);
        }

        // GET: Donors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donor donor = db.Donors.Find(id);
            if (donor == null)
            {
                return HttpNotFound();
            }
            return View(donor);
        }

        // POST: Donors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DonorID,FirstName,LastName,Address1,Address2,State,Zipcode,Phone,Email,EmailUpdateFlag,Employer,Occupation,OccupationStatus")] Donor donor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donor);
        }

        // GET: Donors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donor donor = db.Donors.Find(id);
            if (donor == null)
            {
                return HttpNotFound();
            }
            return View(donor);
        }

        // POST: Donors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donor donor = db.Donors.Find(id);
            db.Donors.Remove(donor);
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
