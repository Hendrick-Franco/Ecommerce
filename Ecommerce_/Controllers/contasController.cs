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
    public class contasController : Controller
    {
       
        private Context db = new Context();
        
        // GET: contas
        public ActionResult Index()
        {

            return View(db.Conta.ToList());
        }

        // GET: contas/Details/5/perfil
        public ActionResult Details(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            conta conta = db.Conta.Find(id);
            if (conta == null)
            {
                return HttpNotFound();
            }
            return View(conta);
        }


        // GET: contas/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: contas/Login
        public ActionResult Login()
        {


            return View();
        }

        // POST: contas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "contaId,email,senha,nome,cpf")] conta conta)
        {
            if (ModelState.IsValid)
            {
                db.Conta.Add(conta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(conta);
        }
        //Validar login

        public ActionResult Logar(string email, string senha)
        {
            try {
                using (var context = new Context())
                {
                    var SQL = context.Conta
                        .Where(c => c.email == email && c.senha == senha).First();
                   
                    if (Session["id"] == null && Session["email"] ==null && Session["id"] == null)
                    {
                        Session.Timeout = 20;
                        Session.Add("id", SQL.contaId);
                        Session.Add("nome", SQL.nome);
                        Session.Add("email", SQL.email);
                    }
                    

                    




                    return RedirectToAction($"Details/{SQL.contaId}");

                }
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }
        }

        public ActionResult Deslogar()
        {
            if (Session["id"] != null && Session["email"] != null && Session["id"] != null)
            {
                Session.Timeout = 20;
                Session.RemoveAll();
                return View("Login");
            }

            return View();
        }



        // GET: contas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            conta conta = db.Conta.Find(id);
            if (conta == null)
            {
                return HttpNotFound();
            }
            return View(conta);
        }

        // POST: contas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "contaId,email,senha,nome,cpf")] conta conta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(conta);
        }

        // GET: contas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            conta conta = db.Conta.Find(id);
            if (conta == null)
            {
                return HttpNotFound();
            }
            return View(conta);
        }

        // POST: contas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            conta conta = db.Conta.Find(id);
            db.Conta.Remove(conta);
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
