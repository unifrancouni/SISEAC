using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SISEAC.Models;

namespace SISEAC.Controllers
{
    public class ValoresCatalogosController : Controller
    {


        public ActionResult Index(int? catalogoid)
        {
            if (Session["Sesion"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
                ViewBag.UserName = Session["Sesion"];


            if (catalogoid==null)
            {
                return RedirectToAction("Index", "CatalogosBasicos");
            }


            int catalogo_id = (int)catalogoid;

            var db = new EntStdUniAtd();
            var nombreCatalogo = db.StbCatalogo.Where(c => c.nStbCatalogoID == catalogo_id).Select(c => c.sDescripcion).FirstOrDefault();

            if (nombreCatalogo == null)
                return RedirectToAction("_404", "Home");

            string[] bc = { "Módulos", "Catálogos Básicos", "Valores Catálogos", nombreCatalogo };

            ViewData["SubTitle"] = "Módulo de Catálogos Básicos";
            ViewData["Message"] = "Control de los catálogos del sistema - Detalles";
            ViewData["BreadCrumb"] = bc;


            var consulta = db.spGetValorCatalogo(catalogo_id).Select(c => c).ToList();
            IEnumerable<spGetValorCatalogo_Result> result = new List<spGetValorCatalogo_Result>();
            result = consulta;

            string strSQL;
            strSQL = "SELECT ISNULL(MAX(CAST(sCodigoInterno AS INT)) ,0) FROM StbValorCatalogo where nStbCatalogoID=" + catalogo_id.ToString();

            var ultimo = 0;
            ultimo = db.Database.SqlQuery<int>(strSQL).FirstOrDefault();
            int maximo = ultimo + 1;
            string Codigo = maximo.ToString();

            ViewBag.Codigo = Codigo;

            if(TempData["Mensaje"]!=null && TempData["MensajeType"]!=null)
            {
                ViewBag.Mensaje = TempData["Mensaje"];
                ViewBag.MensajeType = TempData["MensajeType"];
                ViewBag.MensajeTitle = TempData["MensajeTitle"];
            }
            else
            {
                ViewBag.Mensaje = "";
                ViewBag.MensajeType = "";
                ViewBag.MensajeTitle = "";
            }

            return View(result);
        }

        [HttpPost]
        public ActionResult Create(int valorCatalogo_id, int catalogo_id, string Codigo, string Nombre, string Activo)
        {

            var db = new Models.EntStdUniAtd();

            string strSQL;
            strSQL = "SELECT ISNULL(MAX(CAST(sCodigoInterno AS INT)) ,0) FROM StbValorCatalogo where nStbCatalogoID=" + catalogo_id.ToString();
            var ultimo = 0;
            ultimo = db.Database.SqlQuery<int>(strSQL).FirstOrDefault();
            int maximo = ultimo + 1;
            Codigo = maximo.ToString();


            strSQL = "SELECT 1 FROM StbValorCatalogo WHERE nStbValorCatalogoID<>"+ valorCatalogo_id + " AND (nStbCatalogoID="+catalogo_id.ToString()+" AND sCodigoInterno='" + Codigo + "' OR sDescripcion='" + Nombre + "' )";
            var consulta = db.Database.SqlQuery<int>(strSQL).ToList();
            if (consulta.Count > 0)
            {
                TempData["Mensaje"] = "Error: El código o nombre del catálogo ya existe en la base de datos.";
                TempData["MensajeTitle"] = "Error";
                TempData["MensajeType"] = "error";

                return RedirectToAction("Index", new { catalogoid=catalogo_id });
            }

            int nActivo = (Activo != null) ? 1 : 0;
            strSQL = "EXEC spCreateValorCatalogo " + valorCatalogo_id+", "+ catalogo_id.ToString() + ", '" + Codigo + "', '" + Nombre + "', "+nActivo+", '"+Session["Sesion"]+"'";
            var result = db.Database.ExecuteSqlCommand(strSQL);
            if (result == 1)
            {
                TempData["Mensaje"] = "Correcto: Se grabó registro correctamente.";
                TempData["MensajeTitle"] = "Bien!";
                TempData["MensajeType"] = "success";
                
                return RedirectToAction("Index", new {catalogoid=catalogo_id} );
            }
            else
            {
                TempData["Mensaje"] = "No se pudo grabar registro.";
                TempData["MensajeTitle"] = "Error";
                TempData["MensajeType"] = "error";

                return RedirectToAction("Index", new { catalogoid = catalogo_id });
            }

        }

        [HttpPost]
        public ActionResult Inactivar(int id)
        {
            var db = new Models.EntStdUniAtd();

            string strSQL;
            strSQL = "SELECT nActivo FROM StbValorCatalogo WHERE nStbValorCatalogoID=" + id;
            var consulta = db.Database.SqlQuery<int>(strSQL).FirstOrDefault();

            if (consulta == 0)
                return Json(2);

            strSQL = "Exec spInactivarValorCatalogo " + id.ToString();
            db.Database.ExecuteSqlCommand(strSQL);

            strSQL = "SELECT nActivo FROM StbValorCatalogo WHERE nStbValorCatalogoID=" + id;
            consulta = db.Database.SqlQuery<int>(strSQL).First();

            return Json(consulta);
        }

    }
}