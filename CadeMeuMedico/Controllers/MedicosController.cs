using CadeMeuMedico.Models;
using System.Linq;

using System.Web.Mvc;

namespace CadeMeuMedico.Controllers
{
    public class MedicosController : Controller
    {

        private EntidadesCadeMeuMedicoBD db = new EntidadesCadeMeuMedicoBD();

        // GET: Medicos
        public ActionResult Index()
        {
            var medicos = db.Medicos.Include("Cidades")
                                    .Include("Especialidades")
                                    .ToList();

            return View(medicos);
        }

        public ActionResult Adicionar()
        {
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome");
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome");

            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Medicos medico)
        {
            if (ModelState.IsValid)
            {
                db.Medicos.Add(medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCidade = new SelectList(db.Cidades, "Cidade", "Nome", medico.Cidades);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "Especialidade", "Nome", medico.Especialidades);

            return View(medico);
        }
    }
}