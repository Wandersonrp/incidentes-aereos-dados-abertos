using IncidentesAereosWebApi.Data.Context;
using IncidentesAereosWebApi.Interfaces.Servicos;
using IncidentesAereosWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace IncidentesAereosWebApi.Repositorio.Servicos
{
    public class OcorrenciaServicos : IOcorrenciaServicos
    {
        private readonly IncidentesAereosContext _context;

        public OcorrenciaServicos(IncidentesAereosContext context)
        {
            _context = context;
        }

        public async Task<bool> InserirOcorrenciasBancoDados()
        {
            try
            {
                var ocorrencias = await ConsumirApi();               
                if(ocorrencias != null && ocorrencias.Count() > 0)
                {
                    int contador = 1;
                    ocorrencias.ToList();
                    foreach(var o in ocorrencias)
                    {
                        o.Id = contador;                                                
                        await _context.Ocorrencia.AddAsync(o);
                        await _context.SaveChangesAsync();
                        contador++;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<IEnumerable<OcorrenciaModel>> ListarOcorrenciaPorExpressao(Expression<Func<OcorrenciaModel, bool>> expressao)
        {
            var ocorrencias = await _context.Ocorrencia.Where(expressao).ToListAsync();
            return ocorrencias;
        }

        public Task<OcorrenciaModel> ListarOcorrenciaPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OcorrenciaModel>> ListarOcorrencias()
        {            
            var ocorrencias = await _context.Ocorrencia.ToListAsync();            
            return ocorrencias;
        }

        public async Task<IEnumerable<OcorrenciaModel>> ConsumirApi()
        {
            string url = "https://sistemas.anac.gov.br/dadosabertos/Seguranca%20Operacional/Ocorrencia/V_OCORRENCIA_AMPLA.json";

            var ocorrencias = await DadosAbertos<OcorrenciaModel>.ConsumirApi(url);
            return ocorrencias;
        }
    }
}
