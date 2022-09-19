using CentroMedico___Proyecto_Final.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentroMedico___Proyecto_Final.Controllers
{
    [Authorize(Roles = "superadmin,administrador")]
    public class RolesController : Controller
    {
        private readonly ProyectoFinalContext _context;
        public RolesController(ProyectoFinalContext context)
        {
            _context = context;
        }

        // GET: RolesController
        public async Task<ActionResult> Index()
        {
            return View(_context.Roles);
        }

        // GET: RolesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RolesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolesController/Create
        [HttpPost]
        public ActionResult Create(Rol rol)
        {
            try
            {
                var coincidencia = _context.Roles.Any(p => p.Nombre == rol.Nombre);
                if (!coincidencia)
                {
                    _context.Roles.Add(rol);
                    _context.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RolesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RolesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: RolesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RolesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
