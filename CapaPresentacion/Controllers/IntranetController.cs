using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidades;
using CapaAplicación;

namespace CapaPresentacion.Controllers
{
    public class IntranetController : Controller
    {
        [HttpGet]
        public ActionResult InicioSesion(String msg)
        {
         
                Session["Empleado"] = null;
                ViewBag.mensaje = msg;
                return View();
        }

        [HttpPost]
        public ActionResult InicioSesion(FormCollection formulario)
        {
            try
            {
                String Usuario = Convert.ToString(formulario["txtusuario"]);
                String Contrasena = Convert.ToString(formulario["txtcontrasena"]);
                entEmpleado e = logEmpleado.Instancia.Verificar_Inicio_Sesion(Usuario, Contrasena);
                if (e != null)
                {
                    Session["Empleado"] = e;
                    return View("MenuPrincipal");
                }
                else
                {
                    return RedirectToAction("InicioSesion", "Intranet", new { msg = "Usuario y/o contraseña incorrectos"});
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("InicioSesion", "Intranet", new { msg = ex.Message });
            }
        }

        [Filtro.SesionIntranetController]
        public ActionResult MenuPrincipal()
        {
            
                return View();
            
        }
    }
}