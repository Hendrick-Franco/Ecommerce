using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ecommerce_.Models;

namespace Ecommerce_.Controllers
{
    public class CarrinhoProdutoesController : Controller
    {
        private Context db = new Context();

        // GET: CarrinhoProdutoes
        public ActionResult Index()
        {
            return View(db.carrinhoProdutos.ToList());
        }

        // GET: CarrinhoProdutoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarrinhoProduto carrinhoProduto = db.carrinhoProdutos.Find(id);
            if (carrinhoProduto == null)
            {
                return HttpNotFound();
            }
            return View(carrinhoProduto);
        }

        // GET: CarrinhoProdutoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarrinhoProdutoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "carrinhoId,quantidade")] CarrinhoProduto carrinhoProduto)
        {
            if (ModelState.IsValid)
            {
                db.carrinhoProdutos.Add(carrinhoProduto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carrinhoProduto);
        }

        // GET: CarrinhoProdutoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarrinhoProduto carrinhoProduto = db.carrinhoProdutos.Find(id);
            if (carrinhoProduto == null)
            {
                return HttpNotFound();
            }
            return View(carrinhoProduto);
        }

        // POST: CarrinhoProdutoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "carrinhoId,quantidade")] CarrinhoProduto carrinhoProduto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carrinhoProduto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carrinhoProduto);
        }

        // GET: CarrinhoProdutoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarrinhoProduto carrinhoProduto = db.carrinhoProdutos.Find(id);
            if (carrinhoProduto == null)
            {
                return HttpNotFound();
            }
            return View(carrinhoProduto);
        }

        // POST: CarrinhoProdutoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarrinhoProduto carrinhoProduto = db.carrinhoProdutos.Find(id);
            db.carrinhoProdutos.Remove(carrinhoProduto);
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
