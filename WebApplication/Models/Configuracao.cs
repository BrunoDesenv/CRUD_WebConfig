using System.Collections.Generic;

namespace WebApplication.Models
{
    public class Configuracao
    {
        public string Chave { get; set; }
        public string Valor { get; set; }

        public List<Configuracao> LeArquivo()
        {
            dynamic appSettings = new AppSettingsWrapper();
            var webConfigCompleto = new List<Configuracao>();

            foreach (var item in appSettings.items)
            {
                webConfigCompleto.Add(new Configuracao
                {
                    Chave = item,
                    Valor = appSettings.items[item]
                });
            }

            return webConfigCompleto;
        }

        public void AtualizarArquivoNovo(List<Configuracao> arquivoAntigo)
        {
            string caminho = "WebNovo.config";
            dynamic appSettings = new AppSettingsWrapper(caminho);

    
        }
    }
}