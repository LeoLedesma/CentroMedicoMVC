using CentroMedico___Proyecto_Final.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CentroMedico___Proyecto_Final.Controllers
{
    
    public class PacientesController : Controller
    {
        private readonly ProyectoFinalContext _context;

        public PacientesController(ProyectoFinalContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "superadmin,administrador,profesional")]
        public async Task<ActionResult> Index()
        {
            var pacientes = await _context.Pacientes.ToListAsync();
            return View(pacientes);
        }

        // GET: PacientesController/Details/5
        public ActionResult Details(int id)
        {
            
            return View();
        }

        // GET: PacientesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PacientesController/Create
        [HttpPost]        
        public async Task<IActionResult> Create(Paciente paciente)
        {
            try
            {
                var validacion = _context.Pacientes.Any(p => p.Documento == paciente.Documento);
                if (!validacion)
                {
                    await _context.Pacientes.AddAsync(paciente);
                    await _context.SaveChangesAsync();
                
                }

                return RedirectToAction("Index", "Home");


            }
            catch
            {
                return View();
            }
        }

        // GET: PacientesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PacientesController/Edit/5
        [Authorize(Roles = "superadmin,administrador,profesional")]
        [HttpPost]        
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "superadmin,administrador")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        [Authorize(Roles = "superadmin,administrador")]
        [HttpPost]        
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        
    }
}
