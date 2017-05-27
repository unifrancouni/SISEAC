using SISEAC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SISEAC.Controllers
{
    public class AfiliacionController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Lista", "Afiliacion");
        }

        public ActionResult Lista()
        {
            LlenarViewsBagsGenerales(this);

            if (Session["Sesion"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
                ViewBag.UserName = Session["Sesion"];

            string[] bc = { "Módulos", "Afiliación", "Lista" };

            ViewData["SubTitle"] = "Módulo de Afiliación";
            ViewData["Message"] = "Control de ingresos y bajas de los docentes";
            ViewData["BreadCrumb"] = bc;

            return View();
        }

        public ActionResult Solicitud()
        {
            LlenarViewsBagsGenerales(this);

            if (Session["Sesion"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
                ViewBag.UserName = Session["Sesion"];

            string[] bc = { "Módulos", "Afiliación", "Solicitud" };

            ViewData["SubTitle"] = "Módulo de Afiliación";
            ViewData["Message"] = "Control de ingresos y bajas de los docentes";
            ViewData["BreadCrumb"] = bc;

            //Para llenar los combos:
            var db = new EntStdUniAtd();
            IEnumerable<spGetAllValorCatalogo_Result> result;

            var estadoCivil = db.spGetAllValorCatalogo().Select(c => c)
                                .Where(c=>c.CodCatalogo.Equals("7"))
                                .ToList();
            result = new List<spGetAllValorCatalogo_Result>();
            result = estadoCivil;
            List<string[]> rows = new List<string[]>();
            foreach (spGetAllValorCatalogo_Result el in result)
            {
                string[] row = new string[2];
                row[0] = el.nStbValorCatalogoID.ToString();
                row[1] = el.sDescripcion;
                rows.Add(row);
            }
            ViewData["EstadoCivil"] = rows;

            var categoriaDocente = db.spGetAllValorCatalogo().Select(c => c)
                                .Where(c => c.CodCatalogo.Equals("9"))
                                .ToList();
            result = new List<spGetAllValorCatalogo_Result>();
            result = categoriaDocente;
            rows = new List<string[]>();
            foreach (spGetAllValorCatalogo_Result el in result)
            {
                string[] row = new string[2];
                row[0] = el.nStbValorCatalogoID.ToString();
                row[1] = el.sDescripcion;
                rows.Add(row);
            }
            ViewData["CategoriaDocente"] = rows;

            var gradoAcademico = db.spGetAllValorCatalogo().Select(c => c)
                                .Where(c => c.CodCatalogo.Equals("11"))
                                .ToList();
            result = new List<spGetAllValorCatalogo_Result>();
            result = gradoAcademico;
            rows = new List<string[]>();
            foreach (spGetAllValorCatalogo_Result el in result)
            {
                string[] row = new string[2];
                row[0] = el.nStbValorCatalogoID.ToString();
                row[1] = el.sDescripcion;
                rows.Add(row);
            }
            ViewData["GradoAcademico"] = rows;

            var profesion = db.spGetAllValorCatalogo().Select(c => c)
                                .Where(c => c.CodCatalogo.Equals("6"))
                                .ToList();
            result = new List<spGetAllValorCatalogo_Result>();
            result = profesion;
            rows = new List<string[]>();
            foreach (spGetAllValorCatalogo_Result el in result)
            {
                string[] row = new string[2];
                row[0] = el.nStbValorCatalogoID.ToString();
                row[1] = el.sDescripcion;
                rows.Add(row);
            }
            ViewData["profesion"] = rows;

            var facultad = db.spGetAllValorCatalogo().Select(c => c)
                                .Where(c => c.CodCatalogo.Equals("10"))
                                .ToList();
            result = new List<spGetAllValorCatalogo_Result>();
            result = facultad;
            rows = new List<string[]>();
            foreach (spGetAllValorCatalogo_Result el in result)
            {
                string[] row = new string[2];
                row[0] = el.nStbValorCatalogoID.ToString();
                row[1] = el.sDescripcion;
                rows.Add(row);
            }
            ViewData["facultad"] = rows;

            var carrera = db.spGetAllValorCatalogo().Select(c => c)
                                .Where(c => c.CodCatalogo.Equals("8"))
                                .ToList();
            result = new List<spGetAllValorCatalogo_Result>();
            result = carrera;
            rows = new List<string[]>();
            foreach (spGetAllValorCatalogo_Result el in result)
            {
                string[] row = new string[2];
                row[0] = el.nStbValorCatalogoID.ToString();
                row[1] = el.sDescripcion;
                rows.Add(row);
            }
            ViewData["carrera"] = rows;

            var departamento = db.spGetAllValorCatalogo().Select(c => c)
                                .Where(c => c.CodCatalogo.Equals("14"))
                                .ToList();
            result = new List<spGetAllValorCatalogo_Result>();
            result = departamento;
            rows = new List<string[]>();
            foreach (spGetAllValorCatalogo_Result el in result)
            {
                string[] row = new string[2];
                row[0] = el.nStbValorCatalogoID.ToString();
                row[1] = el.sDescripcion;
                rows.Add(row);
            }
            ViewData["departamento"] = rows;

            string fechaActual = string.Format("{0}/{1}/{2}", DateTime.Now.Day.ToString("00"), DateTime.Now.Month.ToString("00"), DateTime.Now.Year.ToString("0000"));

            ViewData["FechaActual"] = fechaActual;

            return View();
        }

        public static void LlenarViewsBagsGenerales(Controller c)
        {
            c.ViewBag.Notificaciones_No_Leidas = MetodosGenerales.ConsultaNotificacionesSinLeer();
        }
    }
}