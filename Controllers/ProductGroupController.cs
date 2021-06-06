using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using XandaPOS.Edmx;

namespace XandaPOS.Controllers
{
    public class ProductGroupController : Controller
    {
        private XANDA_POSEntities db = new XANDA_POSEntities();

        // GET: ProductGroup
        public ActionResult Index()
        {
            return View(db.POS_PRODUCT_GROUP_MASTER.ToList());
        }

        // GET: ProductGroup/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POS_PRODUCT_GROUP_MASTER pOS_PRODUCT_GROUP_MASTER = db.POS_PRODUCT_GROUP_MASTER.Find(id);
            if (pOS_PRODUCT_GROUP_MASTER == null)
            {
                return HttpNotFound();
            }
            return View(pOS_PRODUCT_GROUP_MASTER);
        }

        // GET: ProductGroup/Create
        public ActionResult Create(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            POS_PRODUCT_GROUP_MASTER pOS_PRODUCT_GROUP_MASTER = db.POS_PRODUCT_GROUP_MASTER.Find(id);

            if (pOS_PRODUCT_GROUP_MASTER == null)
            {
                return HttpNotFound();
            }

            var prodGrpId = db.sp_GetNewProdGrpId();
            
            pOS_PRODUCT_GROUP_MASTER.prod_grp_id = prodGrpId.First().ToString(); 
            pOS_PRODUCT_GROUP_MASTER.prod_grp_name = "";
            pOS_PRODUCT_GROUP_MASTER.prod_grp_type = "";

            return View(pOS_PRODUCT_GROUP_MASTER);
        }

        // POST: ProductGroup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "prod_grp_id,prod_grp_name,prod_grp_type")] POS_PRODUCT_GROUP_MASTER pOS_PRODUCT_GROUP_MASTER)
        {
            //if (string.IsNullOrEmpty(ModelState.Values[1].ToString()){

            //}
            if (ModelState.IsValid)
            {
                db.POS_PRODUCT_GROUP_MASTER.Add(pOS_PRODUCT_GROUP_MASTER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pOS_PRODUCT_GROUP_MASTER);
        }

        // GET: ProductGroup/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POS_PRODUCT_GROUP_MASTER pOS_PRODUCT_GROUP_MASTER = db.POS_PRODUCT_GROUP_MASTER.Find(id);
            if (pOS_PRODUCT_GROUP_MASTER == null)
            {
                return HttpNotFound();
            }
            return View(pOS_PRODUCT_GROUP_MASTER);
        }

        // POST: ProductGroup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "prod_grp_id,prod_grp_name,prod_grp_type")] POS_PRODUCT_GROUP_MASTER pOS_PRODUCT_GROUP_MASTER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pOS_PRODUCT_GROUP_MASTER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pOS_PRODUCT_GROUP_MASTER);
        }

        // GET: ProductGroup/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POS_PRODUCT_GROUP_MASTER pOS_PRODUCT_GROUP_MASTER = db.POS_PRODUCT_GROUP_MASTER.Find(id);
            if (pOS_PRODUCT_GROUP_MASTER == null)
            {
                return HttpNotFound();
            }
            return View(pOS_PRODUCT_GROUP_MASTER);
        }

        // POST: ProductGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            POS_PRODUCT_GROUP_MASTER pOS_PRODUCT_GROUP_MASTER = db.POS_PRODUCT_GROUP_MASTER.Find(id);
            db.POS_PRODUCT_GROUP_MASTER.Remove(pOS_PRODUCT_GROUP_MASTER);
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
