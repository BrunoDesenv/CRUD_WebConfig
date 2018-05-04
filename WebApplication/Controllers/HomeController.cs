using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            //https://pt.stackoverflow.com/questions/235672/passar-um-objeto-para-modal
            var webConfigCompleto = new List<Configuracao>();
            dynamic appSettings = new AppSettingsWrapper();

            foreach (var item in appSettings._items)
            {
                webConfigCompleto.Add(new Configuracao
                {
                    Chave = item,
                    Valor = appSettings._items[item]
                });
            }

            ViewBag.Configuracao = webConfigCompleto;

            return View();
        }

        [HttpPost]
        public JsonResult Index(string teste)
        {
            Configuration objConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            AppSettingsSection objAppsettings = (AppSettingsSection)objConfig.GetSection("appSettings");
            //Edit
            if (objAppsettings != null)
            {
                objAppsettings.Settings["Endereco_Assets"].Value = teste;
                objConfig.Save();
            }

            return Json(JsonRequestBehavior.AllowGet);
        }

        public ActionResult _Editar(Configuracao configuracao)
        {
            return PartialView(configuracao);
        }
    }
}