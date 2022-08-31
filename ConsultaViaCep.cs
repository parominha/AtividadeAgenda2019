using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AtividadeAgenda2019
{
    public class ConsultaViaCep
    {
        public ViaCep Consulta(string CEP)
        {
            string oURL = "https://viacep.com.br/ws/" + CEP + "/json/";

            HttpClient _httpClient = new HttpClient();
            HttpResponseMessage result = _httpClient.GetAsync(oURL).Result;

            string JsonRetorno = result.Content.ReadAsStringAsync().Result;
            ViaCep oviaCEP = new ViaCep();
            oviaCEP = JsonConvert.DeserializeObject<ViaCep>(JsonRetorno);
            return oviaCEP;
        }
    }
}
