using Newtonsoft.Json;

namespace IncidentesAereosWebApi.Repositorio.Servicos
{
    public class DadosAbertos<T> where T : class
    {       
        public static async Task<IEnumerable<T>> ConsumirApi(string url)
        {
            using (var cliente = new HttpClient())
            {
                var resposta = await cliente.GetAsync(url);                

                if(resposta.IsSuccessStatusCode)
                {
                    var json = await resposta.Content.ReadAsStringAsync();
                    IEnumerable<T?> t = JsonConvert.DeserializeObject<IEnumerable<T>>(json);                    
                    if(t.Count() > 0) { 
                        return t;
                    }
                }
            }
            return null;
        }
    }
}
