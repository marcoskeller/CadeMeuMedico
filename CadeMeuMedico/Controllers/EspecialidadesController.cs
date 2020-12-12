using CadeMeuMedico.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadeMeuMedico.Controllers
{
    public class EspecialidadesController : Controller
    {
        private EntidadesCadeMeuMedicoBD db = new EntidadesCadeMeuMedicoBD();

        
        public ActionResult Index()
        {
            var especialidades = db.Especialidades.ToList();
            
            return View(especialidades);
        }

        public ActionResult Adicionar()
        {
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome");

            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Especialidades especialidade)
        {
            if(ModelState.IsValid)
            {
                db.Especialidades.Add(especialidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(especialidade);
        }

        public ActionResult Editar(long id)
        {
            Especialidades especialidade = db.Especialidades.Find(id);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome");

            return View(especialidade);
        }

        [HttpPost]
        public ActionResult Editar(Especialidades especialidade)
        {
            if(ModelState.IsValid)
            {
                db.Entry(especialidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome");
            return View(especialidade);
        }

        public ActionResult Detalhar(long id)
        {
            Especialidades especialidade = db.Especialidades.Find(id);
            ViewBag.IDEspecilaidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome");

            return View(especialidade);
        }

        public ActionResult Excluir(long id)
        {
            Especialidades especialidade = db.Especialidades.Find(id);
            db.Especialidades.Remove(especialidade);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}