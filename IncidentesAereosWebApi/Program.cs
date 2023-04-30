using IncidentesAereosWebApi.Data.Context;
using IncidentesAereosWebApi.Interfaces.Servicos;
using IncidentesAereosWebApi.Repositorio.Servicos;
using Microsoft.EntityFrameworkCore;

namespace IncidentesAereosWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Contexto
            builder.Services.AddDbContext<IncidentesAereosContext>(option =>
            option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            // inje��o de depend�ncia
            builder.Services.AddScoped<IOcorrenciaServicos, OcorrenciaServicos>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}