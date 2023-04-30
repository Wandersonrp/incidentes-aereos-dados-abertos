using IncidentesAereosWebApi.Models;
using System.Linq.Expressions;

namespace IncidentesAereosWebApi.Interfaces.Servicos
{
    public interface IOcorrenciaServicos
    {
        Task<IEnumerable<OcorrenciaModel>> ListarOcorrencias();
        Task<OcorrenciaModel> ListarOcorrenciaPorId(int id);
        Task<IEnumerable<OcorrenciaModel>> ListarOcorrenciaPorExpressao(Expression<Func<OcorrenciaModel, bool>> expressao);
        Task<bool> InserirOcorrenciasBancoDados();
    }
}
