using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Test.BusinessRule;
using Test.Common.Model;
using Test2.Models;

namespace Test2.Controllers
{
    public class MingZuController : Controller
    {
        private CeShiDBContext db = new CeShiDBContext();

        // GET: /MingZu/
        public ActionResult Index()
        {
            return View((new clsMingZuR()).GetMingZus());
        }

        // GET: /MingZu/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            b_MingZu b_mingzu = db.b_MingZu.Find(id);
            if (b_mingzu == null)
            {
                return HttpNotFound();
            }
            return View(b_mingzu);
        }

        // GET: /MingZu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /MingZu/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MingZu,PaiXu,TianJiaShiJian,ZhuangTai")] b_MingZu b_mingzu)
        {
            if (ModelState.IsValid)
            {
                db.b_MingZu.Add(b_mingzu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(b_mingzu);
        }

        // GET: /MingZu/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            b_MingZu b_mingzu = db.b_MingZu.Find(id);
            if (b_mingzu == null)
            {
                return HttpNotFound();
            }
            return View(b_mingzu);
        }

        // POST: /MingZu/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(b_MingZu b_mingzu, string YuanMingZu)
        {
            if (ModelState.IsValid)
            {
                clsMingZuR clsMingZu = new clsMingZuR();
                int iRet = clsMingZu.UpdateMingZu(b_mingzu, YuanMingZu);
                if (iRet >= 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "修改失败。");
                }
            }
            return View(b_mingzu);
        }

        // GET: /MingZu/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            b_MingZu b_mingzu = db.b_MingZu.Find(id);
            if (b_mingzu == null)
            {
                return HttpNotFound();
            }
            return View(b_mingzu);
        }

        // POST: /MingZu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            b_MingZu b_mingzu = db.b_MingZu.Find(id);
            db.b_MingZu.Remove(b_mingzu);
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
