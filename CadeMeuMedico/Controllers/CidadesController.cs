using CadeMeuMedico.Models;
using System;
using System.Collections.Generic;
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

        [HttpPost]
        public ActionResult Adicionar(Cidades cidade)
        {
            if(ModelState.IsValid)
            {
                db.Cidades.Add(cidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}