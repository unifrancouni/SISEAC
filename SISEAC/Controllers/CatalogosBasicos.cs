using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SISEAC.Models;
using SignalR_Chat.Hubs;

namespace SISEAC.Controllers
{
    public class CatalogosBasicosController : Controller
    {
        public ActionResult Index()
        {

            LlenarViewsBagsGenerales(this);

            if (Session["Sesion"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
                ViewBag.UserName = Session["Sesion"];

            string[] bc = { "Módulos", "Catálogos Básicos", "Generales" };

            ViewData["SubTitle"] = "Módulo de Catálogos Básicos";
            ViewData["Message"] = "Control de los catálogos del sistema";
            ViewData["BreadCrumb"] = bc;

            var db = new EntStdUniAtd();

            var consulta = db.spGetCatalogo().Select(c => c).ToList();
            IEnumerable<spGetCatalogo_Result> result = new List<spGetCatalogo_Result>();
            result = consulta;

            string strSQL;

            strSQL = "SELECT ISNULL(MAX(CAST(sCodigoInterno AS INT)) ,0) FROM StbCatalogo";
            var ultimo = 0;
            ultimo = db.Database.SqlQuery<int>(strSQL).FirstOrDefault();
            int maximo = ultimo+1;
            string Codigo = maximo.ToString();
            ViewBag.Codigo = Codigo;

            if (TempData["Mensaje"] != null && TempData["MensajeType"] != null)
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

        public ActionResult FacultadCarrera()
        {

            LlenarViewsBagsGenerales(this);

            if (Session["Sesion"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
                ViewBag.UserName = Session["Sesion"];

            string[] bc = { "Módulos", "Catálogos Básicos", "Facultades" };

            ViewData["SubTitle"] = "Módulo de Catálogos Básicos";
            ViewData["Message"] = "Control de los catálogos del sistema";
            ViewData["BreadCrumb"] = bc;

            var db = new EntStdUniAtd();

            var consulta = db.StbFacultad.Select(c => c).ToList();
            IEnumerable<StbFacultad> result = new List<StbFacultad>();
            result = consulta;

            string strSQL;

            strSQL = "SELECT ISNULL(MAX(CAST(sCodigoInterno AS INT)) ,0) FROM StbFacultad";
            var ultimo = 0;
            ultimo = db.Database.SqlQuery<int>(strSQL).FirstOrDefault();
            int maximo = ultimo + 1;
            string Codigo = maximo.ToString();
            ViewBag.Codigo = Codigo;

            if (TempData["Mensaje"] != null && TempData["MensajeType"] != null)
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

        public ActionResult Carrera(int? catalogoid)
        {
            if (Session["Sesion"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
                ViewBag.UserName = Session["Sesion"];


            if (catalogoid == null)
            {
                return RedirectToAction("FacultadCarrera", "CatalogosBasicos");
            }


            int catalogo_id = (int)catalogoid;

            var db = new EntStdUniAtd();
            var nombreCatalogo = db.StbFacultad.Where(c => c.nStbFacultadID == catalogo_id).Select(c => c.sDescripcion).FirstOrDefault();

            if (nombreCatalogo == null)
                return RedirectToAction("_404", "Home");

            string[] bc = { "Módulos", "Catálogos Básicos", "Facultad", "Carreras de la "+ nombreCatalogo };

            ViewData["SubTitle"] = "Módulo de Catálogos Básicos";
            ViewData["Message"] = "Control de los catálogos del sistema";
            ViewData["BreadCrumb"] = bc;


            var consulta = db.StbCarrera.Select(c => c).Where(c=>c.nStbFacultadID==catalogo_id).ToList();
            IEnumerable<StbCarrera> result = new List<StbCarrera>();
            result = consulta;

            string strSQL;
            strSQL = "SELECT ISNULL(MAX(CAST(sCodigoInterno AS INT)) ,0) FROM StbCarrera where nStbFacultadID=" + catalogo_id.ToString();

            var ultimo = 0;
            ultimo = db.Database.SqlQuery<int>(strSQL).FirstOrDefault();
            int maximo = ultimo + 1;
            string Codigo = maximo.ToString();

            ViewBag.Codigo = Codigo;

            if (TempData["Mensaje"] != null && TempData["MensajeType"] != null)
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

        public ActionResult Departamento(int? catalogoid)
        {
            if (Session["Sesion"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
                ViewBag.UserName = Session["Sesion"];


            if (catalogoid == null)
            {
                return RedirectToAction("FacultadCarrera", "CatalogosBasicos");
            }


            int catalogo_id = (int)catalogoid;

            var db = new EntStdUniAtd();
            var nombreCatalogo = db.StbCarrera.Where(c => c.nStbCarreraID == catalogo_id).Select(c => c.sDescripcion).FirstOrDefault();

            if (nombreCatalogo == null)
                return RedirectToAction("_404", "Home");

            string[] bc = { "Módulos", "Catálogos Básicos", "Facultad", "Carreras de la " + nombreCatalogo };

            ViewData["SubTitle"] = "Módulo de Catálogos Básicos";
            ViewData["Message"] = "Control de los catálogos del sistema";
            ViewData["BreadCrumb"] = bc;


            var consulta = db.StbDepartamento.Select(c => c).Where(c => c.nStbCarreraID == catalogo_id).ToList();
            IEnumerable<StbDepartamento> result = new List<StbDepartamento>();
            result = consulta;

            string strSQL;
            strSQL = "SELECT ISNULL(MAX(CAST(sCodigoInterno AS INT)) ,0) FROM StbDepartamento where nStbCarreraID=" + catalogo_id.ToString();

            var ultimo = 0;
            ultimo = db.Database.SqlQuery<int>(strSQL).FirstOrDefault();
            int maximo = ultimo + 1;
            string Codigo = maximo.ToString();

            ViewBag.Codigo = Codigo;

            if (TempData["Mensaje"] != null && TempData["MensajeType"] != null)
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
        public ActionResult Create(string Catalogo_id, string Codigo, string Nombre, string Activo)
        {
            var db = new EntStdUniAtd();

            int cid = int.Parse(Catalogo_id);
            
            string strSQL;

            strSQL = "SELECT ISNULL(MAX(CAST(sCodigoInterno AS INT)) ,0) FROM StbCatalogo";
            var ultimo = 0;
            ultimo = db.Database.SqlQuery<int>(strSQL).FirstOrDefault();
            int maximo = ultimo+1;
            Codigo = maximo.ToString();


                strSQL = "SELECT 1 FROM StbCatalogo WHERE nStbCatalogoID<>"+Catalogo_id+" AND(sCodigoInterno='" + Codigo + "' OR sDescripcion='" + Nombre + "' )";
                var consulta = db.Database.SqlQuery<int>(strSQL).ToList();
                if (consulta.Count > 0)
                {
                    TempData["Mensaje"] = "Error: El código o nombre del catálogo ya existe en la base de datos.";
                    TempData["MensajeTitle"] = "Error";
                    TempData["MensajeType"] = "error";

                    return RedirectToAction("Index");
                }
            


            int nActivo = (Activo!=null) ? 1 : 0;
            strSQL = "EXEC spCreateCatalogo "+cid+", '" + Codigo + "', '" + Nombre + "', '"+nActivo+"', '"+Session["Sesion"]+"'";
            var result = db.Database.ExecuteSqlCommand(strSQL);
            if (result == 1) {
                TempData["Mensaje"] = "Correcto: Se grabó registro correctamente.";
                TempData["MensajeTitle"] = "Bien!";
                TempData["MensajeType"] = "success";

                if (cid==0)
                    ChatHub.SendNotificacion("A_CB", "Se ha agregado un catálogo", "El catálogo '"+Nombre+"' ha sido agregado.", "5");
                else
                {
                    ChatHub.SendNotificacion("E_CB", "Se ha editado un catálogo", "El catálogo '" + Nombre + "' ha sido modificado por: "+Session["Sesion"], "5");
                }

                return RedirectToAction("Index");
            }
            else
            {
                TempData["Mensaje"] = "Error: El código o nombre del catálogo ya existe en la base de datos.";
                TempData["MensajeTitle"] = "Error";
                TempData["MensajeType"] = "error";

                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public ActionResult CreateFacultad(string Catalogo_id, string Codigo, string Nombre, string Activo)
        {
            var db = new EntStdUniAtd();

            int cid = int.Parse(Catalogo_id);

            string strSQL;

            strSQL = "SELECT ISNULL(MAX(CAST(sCodigoInterno AS INT)) ,0) FROM StbFacultad";
            var ultimo = 0;
            ultimo = db.Database.SqlQuery<int>(strSQL).FirstOrDefault();
            int maximo = ultimo + 1;
            Codigo = maximo.ToString();


            strSQL = "SELECT 1 FROM StbFacultad WHERE nStbFacultadID<>" + Catalogo_id + " AND(sCodigoInterno='" + Codigo + "' OR sDescripcion='" + Nombre + "' )";
            var consulta = db.Database.SqlQuery<int>(strSQL).FirstOrDefault();
            if (consulta!=0)
            {
                TempData["Mensaje"] = "Error: El código o nombre de la Facultad ya existe en la base de datos.";
                TempData["MensajeTitle"] = "Error";
                TempData["MensajeType"] = "error";

                return RedirectToAction("FacultadCarrera");
            }



            int nActivo = (Activo != null) ? 1 : 0;
            strSQL = "EXEC spCreateFacultad " + cid + ", '" + Codigo + "', '" + Nombre + "', '" + nActivo + "', '" + Session["Sesion"] + "'";
            var result = db.Database.ExecuteSqlCommand(strSQL);
            if (result == 1)
            {
                TempData["Mensaje"] = "Correcto: Se grabó registro correctamente.";
                TempData["MensajeTitle"] = "Bien!";
                TempData["MensajeType"] = "success";

                if (cid == 0)
                    ChatHub.SendNotificacion("A_CB", "Se ha agregado una Facultad", "La Facultad '" + Nombre + "' ha sido agregada.", "5");
                else
                {
                    ChatHub.SendNotificacion("E_CB", "Se ha editado una Facultad", "La Facultad '" + Nombre + "' ha sido modificada por: " + Session["Sesion"], "5");
                }

                return RedirectToAction("FacultadCarrera");
            }
            else
            {
                TempData["Mensaje"] = "Error: El código o nombre de la Facultad ya existe en la base de datos.";
                TempData["MensajeTitle"] = "Error";
                TempData["MensajeType"] = "error";

                return RedirectToAction("FacultadCarrera");
            }

        }

        [HttpPost]
        public ActionResult CreateCarrera(int valorCatalogo_id, int catalogo_id, string Codigo, string Nombre, string Activo)
        {

            var db = new Models.EntStdUniAtd();

            string strSQL;
            strSQL = "SELECT ISNULL(MAX(CAST(sCodigoInterno AS INT)) ,0) FROM StbCarrera where nStbFacultadID=" + catalogo_id.ToString();
            var ultimo = 0;
            ultimo = db.Database.SqlQuery<int>(strSQL).FirstOrDefault();
            int maximo = ultimo + 1;
            Codigo = maximo.ToString();


            strSQL = "SELECT 1 FROM StbCarrera WHERE nStbCarreraID<>" + valorCatalogo_id + " AND (nStbFacultadID=" + catalogo_id.ToString() + " AND sCodigoInterno='" + Codigo + "' OR sDescripcion='" + Nombre + "' )";
            var consulta = db.Database.SqlQuery<int>(strSQL).ToList();
            if (consulta.Count > 0)
            {
                TempData["Mensaje"] = "Error: El código o nombre de la carrera ya existe en la base de datos.";
                TempData["MensajeTitle"] = "Error";
                TempData["MensajeType"] = "error";

                return RedirectToAction("Carrera", new { catalogoid = catalogo_id });
            }

            int nActivo = (Activo != null) ? 1 : 0;
            strSQL = "EXEC spCreateCarrera " + valorCatalogo_id + ", " + catalogo_id.ToString() + ", '" + Codigo + "', '" + Nombre + "', " + nActivo + ", '" + Session["Sesion"] + "'";
            var result = db.Database.ExecuteSqlCommand(strSQL);
            if (result == 1)
            {
                TempData["Mensaje"] = "Correcto: Se grabó registro correctamente.";
                TempData["MensajeTitle"] = "Bien!";
                TempData["MensajeType"] = "success";

                return RedirectToAction("Carrera", new { catalogoid = catalogo_id });
            }
            else
            {
                TempData["Mensaje"] = "No se pudo grabar registro.";
                TempData["MensajeTitle"] = "Error";
                TempData["MensajeType"] = "error";

                return RedirectToAction("Carrera", new { catalogoid = catalogo_id });
            }

        }

        [HttpPost]
        public ActionResult CreateDepartamento(int valorCatalogo_id, int catalogo_id, string Codigo, string Nombre, string Activo)
        {

            var db = new Models.EntStdUniAtd();

            string strSQL;
            strSQL = "SELECT ISNULL(MAX(CAST(sCodigoInterno AS INT)) ,0) FROM StbDepartamento where nStbCarreraID=" + catalogo_id.ToString();
            var ultimo = 0;
            ultimo = db.Database.SqlQuery<int>(strSQL).FirstOrDefault();
            int maximo = ultimo + 1;
            Codigo = maximo.ToString();


            strSQL = "SELECT 1 FROM StbDepartamento WHERE nStbDepartamentoID<>" + valorCatalogo_id + " AND (nStbCarreraID=" + catalogo_id.ToString() + " AND sCodigoInterno='" + Codigo + "' OR sDescripcion='" + Nombre + "' )";
            var consulta = db.Database.SqlQuery<int>(strSQL).ToList();
            if (consulta.Count > 0)
            {
                TempData["Mensaje"] = "Error: El código o nombre del departamento ya existe en la base de datos.";
                TempData["MensajeTitle"] = "Error";
                TempData["MensajeType"] = "error";

                return RedirectToAction("Departamento", new { catalogoid = catalogo_id });
            }

            int nActivo = (Activo != null) ? 1 : 0;
            strSQL = "EXEC spCreateDepartamento " + valorCatalogo_id + ", " + catalogo_id.ToString() + ", '" + Codigo + "', '" + Nombre + "', " + nActivo + ", '" + Session["Sesion"] + "'";
            var result = db.Database.ExecuteSqlCommand(strSQL);
            if (result == 1)
            {
                TempData["Mensaje"] = "Correcto: Se grabó registro correctamente.";
                TempData["MensajeTitle"] = "Bien!";
                TempData["MensajeType"] = "success";

                return RedirectToAction("Departamento", new { catalogoid = catalogo_id });
            }
            else
            {
                TempData["Mensaje"] = "No se pudo grabar registro.";
                TempData["MensajeTitle"] = "Error";
                TempData["MensajeType"] = "error";

                return RedirectToAction("Departamento", new { catalogoid = catalogo_id });
            }

        }

        [HttpPost]
        public ActionResult Inactivar(int id)
        {
            var db = new Models.EntStdUniAtd();
            
            string strSQL;
            strSQL = "SELECT nActivo FROM StbCatalogo WHERE nStbCatalogoID=" + id;
            var consulta = db.Database.SqlQuery<int>(strSQL).First();

            if (consulta == 0)
                return Json(2);

            strSQL = "Exec spInactivarCatalogo "+id.ToString();
            db.Database.ExecuteSqlCommand(strSQL);

            strSQL = "SELECT nActivo FROM StbCatalogo WHERE nStbCatalogoID=" + id;
            consulta = db.Database.SqlQuery<int>(strSQL).First();

            return Json(consulta);
        }

        [HttpPost]
        public ActionResult InactivarFacultad(int id)
        {
            var db = new Models.EntStdUniAtd();

            string strSQL;
            strSQL = "SELECT nActivo FROM StbFacultad WHERE nStbFacultadID=" + id;
            var consulta = db.Database.SqlQuery<int>(strSQL).First();

            if (consulta == 0)
                return Json(2);

            strSQL = "Exec spInactivarFacultad " + id.ToString();
            db.Database.ExecuteSqlCommand(strSQL);

            strSQL = "SELECT nActivo FROM StbFacultad WHERE nStbFacultadID=" + id;
            consulta = db.Database.SqlQuery<int>(strSQL).First();

            return Json(consulta);
        }

        [HttpPost]
        public ActionResult InactivarCarrera(int id)
        {
            var db = new Models.EntStdUniAtd();

            string strSQL;
            strSQL = "SELECT nActivo FROM StbCarrera WHERE nStbCarreraID=" + id;
            var consulta = db.Database.SqlQuery<int>(strSQL).First();

            if (consulta == 0)
                return Json(2);

            strSQL = "Exec spInactivarCarrera " + id.ToString();
            db.Database.ExecuteSqlCommand(strSQL);

            strSQL = "SELECT nActivo FROM StbCarrera WHERE nStbCarreraID=" + id;
            consulta = db.Database.SqlQuery<int>(strSQL).First();

            return Json(consulta);
        }

        [HttpPost]
        public ActionResult InactivarDepartamento(int id)
        {
            var db = new Models.EntStdUniAtd();

            string strSQL;
            strSQL = "SELECT nActivo FROM StbDepartamento WHERE nStbDepartamentoID=" + id;
            var consulta = db.Database.SqlQuery<int>(strSQL).FirstOrDefault();

            if (consulta == 0)
                return Json(2);

            strSQL = "Exec spInactivarDepartamento " + id.ToString();
            db.Database.ExecuteSqlCommand(strSQL);

            strSQL = "SELECT nActivo FROM StbDepartamento WHERE nStbDepartamentoID=" + id;
            consulta = db.Database.SqlQuery<int>(strSQL).First();

            return Json(consulta);
        }

        public static void LlenarViewsBagsGenerales(Controller c)
        {
            c.ViewBag.Notificaciones_No_Leidas = MetodosGenerales.ConsultaNotificacionesSinLeer();
        }

    }
}