using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidades;
using CapaAplicación;

namespace CapaPresentacion.Controllers
{
    public class EmpleadoController : Controller
    {

        [Filtro.SesionIntranetController]
        [HttpGet]
        public ActionResult Lista(String msg)
        {
            try
            {
                ViewBag.mensaje = msg;
                List<entEmpleado> lista = logEmpleado.Instancia.ListarEmpleado();
                return View(lista);
            }
            catch (Exception e) 
            {
                return RedirectToAction("MenuPrincipal", "Intranet", new { msg = "Ocurrio un error inesperado." });
            }
        }

        [Filtro.SesionIntranetController]
        [HttpGet]
        public ActionResult Insertar(String msg)
        {
            try
            {
                ViewBag.mensaje = msg;
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Lista", "Empleado", new { msg = ex.Message });
            }
        }

        [Filtro.SesionIntranetController]
        [HttpPost]
        public ActionResult Insertar(FormCollection formulario)
        {
            try
            {
                Boolean inserto = false;
                entEmpleado e = new entEmpleado();
                e.nombres = Convert.ToString(formulario["txtNombres"]);
                e.apellidos = Convert.ToString(formulario["txtApellidos"]);
                e.documentoIdentidad = Convert.ToString(formulario["txtDni"]);
                e.celular = Convert.ToString(formulario["txtCelular"]);
                e.correo = Convert.ToString(formulario["txtCorreo"]);
                e.usuario = Convert.ToString(formulario["txtUsuario"]);
                e.contrasena = Convert.ToString(formulario["txtContrasena"]);
                e.cargo = Convert.ToString(formulario["txtCargo"]);
              

                inserto = logEmpleado.Instancia.InsertarEmpleado(e);
                if (inserto)
                {
                    return RedirectToAction("Lista", "Empleado");
                }
                else 
                { 
                    return View(formulario);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Lista", "Empleado", new { msg = ex.Message });
            }
        }

    }
}