using CentroMedico___Proyecto_Final.Models;
using CentroMedico___Proyecto_Final.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;

namespace CentroMedico___Proyecto_Final.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        private readonly ProyectoFinalContext _context;
        public UsuariosController(ProyectoFinalContext context)
        {
            this._context = context;
        }

        [Authorize(Roles = "superadmin,administrador")]
        public async Task<IActionResult> Index()
        {
            return View(_context.Usuarios);
        }
                

        public IActionResult Guardar()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Guardar(Usuario usuario)
        {
            if(ModelState.IsValid)
            {
                if(await ValidarUsuario(usuario))
                {
                    await _context.Usuarios.AddAsync(usuario);
                    await _context.SaveChangesAsync();

                    //Se le asigna por defecto el rol "usuario"
                    await _context.RolesUsuarios.AddAsync(new RolUsuario() { RolesId = 5, UsuarioId = usuario.UsuariosId });

                    return RedirectToAction("Index", "Login");
                }else
                {
                    return View();
                }

            }
            return View();
        }

        [Authorize(Roles = "superadmin,administrador")]
        public IActionResult Editar(int? id)
        {
            if (id == 0 || id is null)
            {
                return NotFound("Id no existente");
            }
            else
            {
                
                var usuario = _context.Usuarios.FirstOrDefault(l => l.UsuariosId == id);

                if (usuario == null)
                {
                    return NotFound("No encontrado");
                }

                return View(usuario);
            }
        }

        [Authorize(Roles = "superadmin,administrador")]
        [HttpPost]
        public async Task<IActionResult> Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if (await ValidarUsuario(usuario, true))
                {
                    _context.Usuarios.Update(usuario);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View();
            }
            else
            {
                return View();
            }
        }

        [Authorize(Roles = "superadmin,administrador")]
        public IActionResult Eliminar(int? id)
        {
            if (id == 0 || id is null)
            {
                return NotFound("Id no existente");
            }
            else
            {
                var libro = _context.Usuarios.FirstOrDefault(l => l.UsuariosId == id);

                if (libro == null)
                {
                    return NotFound("No encontrado");
                }

                return View(libro);
            }
        }

        [Authorize(Roles = "superadmin,administrador")]
        [HttpPost]
        public IActionResult Eliminar(Usuario usuario)
        {
            var usuarioEncontrado = _context.Usuarios.Where(u => u.NombreUsuario == usuario.NombreUsuario && u.Email == usuario.Email && u.UsuariosId == usuario.UsuariosId).First();
            if(usuarioEncontrado !=null)
            {
                _context.Usuarios.Remove(usuarioEncontrado);
                _context.SaveChanges();
                
            }

            return RedirectToAction("Index");
        }

        public IActionResult AsociarPaciente(int? id)
        {
            if (id == 0 || id is null)
            {
                return NotFound("Id no existente");
            }
            else
            {
                var viewModel = new UsuarioPacienteViewModel();
                viewModel.Usuario = _context.Usuarios.Where(p => p.UsuariosId == id).FirstOrDefault();                

                if (viewModel.Usuario == null)
                {
                    return NotFound("No encontrado");
                }

                return View(viewModel);
            }
        }

        [Authorize(Roles = "superadmin,administrador,paciente,profesional,usuario")]
        public ActionResult Details(int id)
        {
            if (User.Claims.Any(p => p.Type == "id" && p.Value == id.ToString()))
            {
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult AsociarPaciente(UsuarioPacienteViewModel viewModel)
        {
            
            _context.Pacientes.Add(viewModel.Paciente);
            _context.RolesUsuarios.Add(new RolUsuario() { UsuarioId = viewModel.Usuario.UsuariosId, RolesId = 3 });            
            _context.SaveChanges();

            var usuario = _context.Usuarios.Where(p=> p.UsuariosId == viewModel.Usuario.UsuariosId).FirstOrDefault();
            usuario.PacienteId = viewModel.Paciente.PacienteId;

            _context.Usuarios.Update(usuario);
            _context.SaveChanges();


            return RedirectToAction("Index", "Home");
        }




        /// <summary>
        /// Valida que no exista algun usuario con email, nombreUsuario, paciente o profesional indicado.
        /// </summary>
        /// <returns></returns>
        private async Task<bool> ValidarUsuario(Usuario usuario, bool isForUpdate = false)
        {
            var validaciones = new List<Task<bool>>(){
                ValidarNombreUsuario(usuario, isForUpdate), 
                ValidarEmail(usuario, isForUpdate),
                ValidarPaciente(usuario, isForUpdate),
                ValidarProfesional(usuario, isForUpdate)};
            
            while(validaciones.Count>0)
            {
                var validacionTerminada = await Task.WhenAny(validaciones);

                if (await validacionTerminada)                
                    return false;

                validaciones.Remove(validacionTerminada);
            }

            return true;
        }

        

       

        private async Task<bool> ValidarNombreUsuario(Usuario usuario, bool isForUpdate = false)
        {
            if(isForUpdate)            
                return _context.Usuarios.Any(p => p.NombreUsuario == usuario.NombreUsuario && p.UsuariosId != usuario.UsuariosId);

            
            return _context.Usuarios.Any(p => p.NombreUsuario == usuario.NombreUsuario);
        }

        private async Task<bool> ValidarEmail(Usuario usuario, bool isForUpdate = false)
        {
            if (isForUpdate)
                return _context.Usuarios.Any(p => p.Email == usuario.Email && p.UsuariosId != usuario.UsuariosId);

            return _context.Usuarios.Any(p => p.Email == usuario.Email);
        }

        private async Task<bool> ValidarPaciente(Usuario usuario, bool isForUpdate = false)
        {
            if (usuario.PacienteId is not null)
            {
                if (isForUpdate)
                    return _context.Usuarios.Any(p => p.PacienteId == usuario.PacienteId && p.UsuariosId != usuario.UsuariosId);

                return _context.Usuarios.Any(p => p.PacienteId == usuario.PacienteId);

            }

            return false;
        }

        private async Task<bool> ValidarProfesional(Usuario usuario, bool isForUpdate = false)
        {
            if (usuario.ProfesionalId is not null)
            {
                if (isForUpdate)
                    return _context.Usuarios.Any(p => p.ProfesionalId == usuario.ProfesionalId && p.UsuariosId != usuario.UsuariosId);

                return _context.Usuarios.Any(p => p.ProfesionalId == usuario.ProfesionalId);

            }

            return false;
        }
    }
}
