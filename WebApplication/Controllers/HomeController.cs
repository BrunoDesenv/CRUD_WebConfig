using System.Configuration;
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
            ViewBag.Configuracao = new Configuracao().LeArquivo();

            return View();
        }

        [HttpPost]
        public JsonResult Index(string teste)
        {
            Configuration objConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/WebNovo.config");
            AppSettingsSection objAppsettings = (AppSettingsSection)objConfig.GetSection("appSettings");
            //Edit
            if (objAppsettings != null)
            {
                objAppsettings.Settings["Endereco_Assets"].Value = teste;
                objConfig.Save();
            }

            return Json(JsonRequestBehavior.AllowGet);
        }

        public ActionResult Editar(Configuracao configuracao)
        {
            return PartialView(configuracao);
        }

        public JsonResult DePara()
        {
     
    
            return Json(JsonRequestBehavior.AllowGet);
        }

    }
}