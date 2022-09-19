
using CentroMedico___Proyecto_Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;


namespace CentroMedico___Proyecto_Final.Controllers
{
    public class LoginController : Controller
    {
        private ProyectoFinalContext _context;
        public LoginController(ProyectoFinalContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Usuario usuario)
        {
            var usuarioValidado = ValidarUsuario(usuario);

            if (usuarioValidado != null)
            {
                usuarioValidado.RolUsuarios = _context.RolesUsuarios.Where(p => p.UsuarioId == usuarioValidado.UsuariosId).Include(P=> P.Rol).ToList();

                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, usuarioValidado.NombreUsuario),
                    new Claim("Correo", usuarioValidado.Email),
                    new Claim("id", usuarioValidado.UsuariosId.ToString())
                };

                List<string> strings = new List<string>();
                foreach (var rol in usuarioValidado.RolUsuarios)
                {
                    strings.Add(rol.Rol.Nombre);
                    claims.Add(new Claim(ClaimTypes.Role, rol.Rol.Nombre));
                }               


                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        private Usuario ValidarUsuario(Usuario usuario)
        {

            return _context.Usuarios.Where(item => item.NombreUsuario == usuario.NombreUsuario && item.Contrasenia == usuario.Contrasenia).FirstOrDefault();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "login");
        }


    }
}
