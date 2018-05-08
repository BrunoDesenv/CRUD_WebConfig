using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web.Configuration;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var configuracao = new Configuracao().LeArquivo();

            return View(configuracao);
        }


        public ActionResult Editar(Configuracao configuracao)
        {
            return PartialView(configuracao);
        }

        public JsonResult DePara()
        {

            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = @"C:\Users\bruno.santos.eit\Desktop\Projeto\WebApplication\WebApplication\Novo\Web.config";
            Configuration objConfig = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            AppSettingsSection objAppsettings = (AppSettingsSection)objConfig.GetSection("appSettings");
            var chavesWebAntigo = objAppsettings.Settings.AllKeys;
            
            
            var webConfigAntigo = new Configuracao().LeArquivo();
            var chaves = new List<string>();


            for (int i = 0; i < chavesWebAntigo.Length; i++)
            {
                if (webConfigAntigo[i].Chave != chavesWebAntigo[i].ToString())
                {
                    chaves.Add(objAppsettings.Settings.AllKeys[i].ToString());
                }
            }


            return Json(new { Chaves = chaves } , JsonRequestBehavior.AllowGet);
        }

    }
}