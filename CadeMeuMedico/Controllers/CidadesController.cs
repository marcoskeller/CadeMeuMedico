using CadeMeuMedico.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadeMeuMedico.Controllers
{
    public class CidadesController : Controller
    {
        private EntidadesCadeMeuMedicoBD db = new EntidadesCadeMeuMedicoBD();


        public ActionResult Index()
        {
            var cidades = db.Cidades.ToList();
                                    
            return View(cidades);
        }

        public ActionResult Adicionar()
        {
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome");
        
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Cidades cidade)
        {
            if(ModelState.IsValid)
            {
                db.Cidades.Add(cidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cidade);
        }

        public ActionResult Editar(long id)
        {
            Cidades cidade = db.Cidades.Find(id);
            
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome");

            return View(cidade);
        }

        [HttpPost]
        public ActionResult Editar(Cidades cidade)
        {
            if(ModelState.IsValid)
            {
                db.Entry(cidade).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome");

            return View(cidade);
        }

        public ActionResult Detalhar(long id)
        {
            Cidades cidade = db.Cidades.Find(id);

            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome");

            return View(cidade);
        }

        public ActionResult Excluir(long id)
        {
            Cidades cidade = db.Cidades.Find(id);
            db.Cidades.Remove(cidade);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}