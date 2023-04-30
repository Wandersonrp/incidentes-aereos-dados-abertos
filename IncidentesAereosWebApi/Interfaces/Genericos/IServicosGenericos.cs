namespace IncidentesAereosWebApi.Interfaces.Genericos
{
    public interface IServicosGenericos<T> where T : class
    {
        Task<T> Listar();
        Task<T> ListarPorId();
    }
}
