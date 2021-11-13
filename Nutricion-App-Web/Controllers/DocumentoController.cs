using NA.IServicio.Dieta;
using NA.IServicio.Documento;
using NA.Servicio.Dieta;
using NA.Servicio.Documento;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nutricion_App_Web.Controllers
{
    public class DocumentoController : Controller
    {
        private readonly IDietaServicio _dietaServicio = new DietaServicio();
        private readonly IDocumentoServicio _documentoServicio = new DocumentoServicio();


        // GET: Documento
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Documento(long id)
            {
            var dieta = _dietaServicio.ObtenerPorInforme(id);

            if(dieta != null)
            {

                var documento = _documentoServicio.ObtenerPorDieta(dieta.Id);

                if (documento != null)
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    string folder = path + "/temp/";
                    string fullFilePath = folder + documento.Nombre;

                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }

                    byte[] imagen = documento.Doc;

                    return File(imagen, documento.Nombre, fullFilePath);
                }
                else
                {
                    return RedirectToAction("Controles", "Controles", new { SinDieta = "SI" });
                }
            }
            else
            {
                return RedirectToAction("Controles", "Controles", new {SinDieta = "SI"});
            }
        }
    }
}