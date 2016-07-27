using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using controlPC.Models;

namespace controlPC.Controllers
{
    public class ControlPCsController : Controller
    {
        private ControlPCDBContext db = new ControlPCDBContext();

        // GET: ControlPCs
        public ActionResult Index()
        {
            return View(db.ControlPCs.ToList());
        }

        [HttpPost]
        public ActionResult Index(
            int id, 
            string ipAdress,
            int classification,
            string type,
            string typeNumber,
            string userName,
            string pcName,
            string memo
            )
        {
            var a = db.ControlPCs.Where(w => w.id == id).ToList();
            var b = db.ControlPCs.Where(w => w.ipAdress.Contains(ipAdress)).ToList();
            var c = db.ControlPCs.Where(w => w.classification == classification).ToList();
            var d = db.ControlPCs.Where(w => w.type.Contains(type)).ToList();
            var e = db.ControlPCs.Where(w => w.typeNumber.Contains(typeNumber)).ToList();
            var f = db.ControlPCs.Where(w => w.userName.Contains(userName)).ToList();
            var g = db.ControlPCs.Where(w => w.pcName.Contains(pcName)).ToList();

            var h = a.Concat(b).Concat(c).Concat(d).Concat(e).Concat(f).Concat(g).Distinct().ToList();
            if (h.Count > 0)
            {
                return View(h);
            }
            else
            {
                return View(db.ControlPCs.ToList());
            }
        }

        // GET: ControlPCs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ControlPC controlPC = db.ControlPCs.Find(id);
            if (controlPC == null)
            {
                return HttpNotFound();
            }
            return View(controlPC);
        }

        // GET: ControlPCs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ControlPCs/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ipAdress,classification,type,typeNumber,userName,pcName,memo")] ControlPC controlPC)
        {
            if (ModelState.IsValid)
            {
                db.ControlPCs.Add(controlPC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(controlPC);
        }

        // GET: ControlPCs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ControlPC controlPC = db.ControlPCs.Find(id);
            if (controlPC == null)
            {
                return HttpNotFound();
            }
            return View(controlPC);
        }

        // POST: ControlPCs/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ipAdress,classification,type,typeNumber,userName,pcName,memo")] ControlPC controlPC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(controlPC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(controlPC);
        }

        // GET: ControlPCs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ControlPC controlPC = db.ControlPCs.Find(id);
            if (controlPC == null)
            {
                return HttpNotFound();
            }
            return View(controlPC);
        }

        // POST: ControlPCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ControlPC controlPC = db.ControlPCs.Find(id);
            db.ControlPCs.Remove(controlPC);
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
