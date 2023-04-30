using IncidentesAereosWebApi.Interfaces.Genericos;

namespace IncidentesAereosWebApi.Repositorio.Genericos
{
    public class ServicoGenerico<T> : IServicosGenericos<T> where T : class
    {
        public Task<T> Listar()
        {
            throw new NotImplementedException();
        }

        public Task<T> ListarPorId()
        {
            throw new NotImplementedException();
        }
    }
}
