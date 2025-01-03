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

        [Filtro.SesionIntranetController]
        [HttpGet]
        public ActionResult Editar(int idEmpleado)
        {
            try
            {
                entEmpleado e = new entEmpleado();
                e = logEmpleado.Instancia.BuscarEmpleado(idEmpleado);
                return View(e);
            }
            catch (Exception e)
            {
                return RedirectToAction("Lista", "Empleado", new { msg = e.Message });
            }
        }

        [Filtro.SesionIntranetController]
        [HttpPost]
        public ActionResult Editar(FormCollection formulario)
        {
            try
            {
                Boolean inserto = false;
                entEmpleado e = new entEmpleado();
                e.idEmpleado = Convert.ToInt32(formulario["idEmpleado"]);
                e.nombres = Convert.ToString(formulario["nombres"]);
                e.apellidos = Convert.ToString(formulario["apellidos"]);
                e.documentoIdentidad = Convert.ToString(formulario["documentoIdentidad"]);
                e.celular = Convert.ToString(formulario["celular"]);
                e.correo = Convert.ToString(formulario["correo"]);
                e.usuario = Convert.ToString(formulario["usuario"]);
                e.contrasena = Convert.ToString(formulario["contrasena"]);
                e.cargo = Convert.ToString(formulario["cargo"]);
                e.estado = Convert.ToBoolean(formulario["estado"]);

                inserto = logEmpleado.Instancia.EditarEmpleado(e);
                if (inserto)
                {
                    return RedirectToAction("Lista", "Empleado");
                }
                else
                {
                    return View(formulario);
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Lista", "Empleado", new { msg = e.Message });
            }
        }
        [Filtro.SesionIntranetController]
        [HttpGet]
        public ActionResult Eliminar(int idEmpleado)
        {
            try
            {
                Boolean elimino = false;
                elimino = logEmpleado.Instancia.EliminarEmpleado(idEmpleado);
                if (elimino)
                {
                    return RedirectToAction("Lista", "Empleado");
                }
                else 
                {
                    return View();
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Lista", "Empleado", new { msg = e.Message });
            }
        }
    }
}