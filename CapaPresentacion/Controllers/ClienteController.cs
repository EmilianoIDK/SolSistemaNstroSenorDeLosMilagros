using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidades;
using CapaAplicación;

namespace CapaPresentacion.Controllers
{
    public class ClienteController : Controller
    {
        [Filtro.SesionIntranetController]
        [HttpGet]
        // Lista 
        public ActionResult Lista(string msg)
        {
            try
            {
                ViewBag.mensaje = msg;
                List<entCliente> lista = logCliente.Instancia.ListarClientes();
                return View(lista);
            }
            catch (Exception e)
            {
                return RedirectToAction("MenuPrincipal", "Intranet", new { msg = "Ocurrió un error inesperado." });
            }
        }

        [Filtro.SesionIntranetController]
        [HttpGet]
        // Buscar Cliente por ID
        public ActionResult Buscar(int idCliente)
        {
            try
            {
                // Buscar el cliente utilizando el logCliente
                entCliente cliente = logCliente.Instancia.BuscarCliente(idCliente);

                // Verificar si se encontró el cliente
                if (cliente != null)
                {
                    return View("Detalles", cliente); // Muestra los detalles del cliente encontrado
                }
                else
                {
                    return RedirectToAction("Lista", "Cliente", new { msg = "Cliente no encontrado." });
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Lista", "Cliente", new { msg = e.Message });
            }
        }

        [Filtro.SesionIntranetController]
        [HttpGet]
        // Insertar
        public ActionResult Insertar(string msg)
        {
            try
            {
                ViewBag.mensaje = msg;
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Lista", "Cliente", new { msg = ex.Message });
            }
        }

        [Filtro.SesionIntranetController]
        [HttpPost]
        public ActionResult Insertar(FormCollection formulario)
        {
            try
            {
                bool inserto = false;
                entCliente c = new entCliente();
                c.dni = Convert.ToInt32(formulario["txtDni"]);
                c.nombres = Convert.ToString(formulario["txtNombres"]);
                c.apellidos = Convert.ToString(formulario["txtApellidos"]);
                c.celular = Convert.ToString(formulario["txtCelular"]);
                c.telefono = Convert.ToString(formulario["txtTelefono"]);
                c.email = Convert.ToString(formulario["txtEmail"]);
                c.estado = Convert.ToBoolean(formulario["estado"]);

                inserto = logCliente.Instancia.InsertarCliente(c);
                if (inserto)
                {
                    return RedirectToAction("Lista", "Cliente");
                }
                else
                {
                    return View(formulario);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Lista", "Cliente", new { msg = ex.Message });
            }
        }

        [Filtro.SesionIntranetController]
        [HttpGet]
        // Editar
        public ActionResult Editar(int idCliente)
        {
            try
            {
                entCliente c = logCliente.Instancia.BuscarCliente(idCliente);
                return View(c);
            }
            catch (Exception e)
            {
                return RedirectToAction("Lista", "Cliente", new { msg = e.Message });
            }
        }

        [Filtro.SesionIntranetController]
        [HttpPost]
        public ActionResult Editar(FormCollection formulario)
        {
            try
            {
                bool actualizo = false;
                entCliente c = new entCliente();
                c.idCliente = Convert.ToInt32(formulario["txtIdCliente"]);
                c.dni = Convert.ToInt32(formulario["txtDni"]);
                c.nombres = Convert.ToString(formulario["txtNombres"]);
                c.apellidos = Convert.ToString(formulario["txtApellidos"]);
                c.celular = Convert.ToString(formulario["txtCelular"]);
                c.telefono = Convert.ToString(formulario["txtTelefono"]);
                c.email = Convert.ToString(formulario["txtEmail"]);
                c.estado = Convert.ToBoolean(formulario["estado"]);

                actualizo = logCliente.Instancia.EditarCliente(c);
                if (actualizo)
                {
                    return RedirectToAction("Lista", "Cliente");
                }
                else
                {
                    return View(formulario);
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Lista", "Cliente", new { msg = e.Message });
            }
        }

        [Filtro.SesionIntranetController]
        [HttpGet]
        // Eliminar
        public ActionResult Eliminar(int idCliente)
        {
            try
            {
                bool elimino = logCliente.Instancia.EliminarCliente(idCliente);

                if (elimino)
                {
                    return RedirectToAction("Lista", "Cliente");
                }

                // Si no se eliminó, puedes redirigir a la lista con un mensaje o manejarlo de otra manera.
                return RedirectToAction("Lista", "Cliente", new { msg = "No se pudo eliminar el cliente." });

            }
            catch (Exception e)
            {
                return RedirectToAction("Lista", "Cliente", new { msg = e.Message });
            }
        }

    }
}
