using IncidentesAereosWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace IncidentesAereosWebApi.Data.Context
{
    public class IncidentesAereosContext : DbContext
    {        
        private readonly IConfiguration _configuration;
        public IncidentesAereosContext(DbContextOptions<IncidentesAereosContext> options, IConfiguration configuration) 
            : base(options)
        {            
            _configuration = configuration;
        }         
        
        public DbSet<OcorrenciaModel> Ocorrencia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OcorrenciaModel>()
                .ToTable(_configuration["VAR:TABLE"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Id)
                .HasColumnName(_configuration["VAR:ID"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Numero_da_Ocorrencia)                
                .HasColumnName(_configuration["VAR:NUMERO_OCORRENCIA"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Numero_da_Ficha)
                .HasColumnName(_configuration["VAR:NUMERO_FICHA"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Operador_Padronizado)
                .HasColumnName(_configuration["VAR:OPERADOR_PADRONIZADO"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Classificacao_da_Ocorrencia)
                .HasColumnName(_configuration["VAR:CLASSIFICACAO_OCORRENCIA"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Data_da_Ocorrencia)
                .HasColumnName(_configuration["VAR:DATA_OCORRENCIA"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Hora_da_Ocorrencia)
                .HasColumnName(_configuration["VAR:HORA_OCORRENCIA"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Municipio)
                .HasColumnName(_configuration["VAR:MUNICIPIO"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.UF)
                .HasColumnName(_configuration["VAR:UF"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Regiao)
                .HasColumnName(_configuration["VAR:REGIAO"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Descricao_do_Tipo)
                .HasColumnName(_configuration["VAR:DESCRICAO_TIPO"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.ICAO)
                .HasColumnName(_configuration["VAR:ICAO"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Latitude)
                .HasColumnName(_configuration["VAR:LATITUDE"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Longitude)
                .HasColumnName(_configuration["VAR:LONGITUDE"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Tipo_de_Aerodromo)
                .HasColumnName(_configuration["VAR:TIPO_AERODROMO"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Historico)
                .HasColumnName(_configuration["VAR:HISTORICO"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Matricula)
                .HasColumnName(_configuration["VAR:MATRICULA"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Categoria_da_Aeronave)
                .HasColumnName(_configuration["VAR:CATEGORIA_AERONAVE"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Operador)
                .HasColumnName(_configuration["VAR:OPERADOR"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Tipo_de_Ocorrencia)
                .HasColumnName(_configuration["VAR:TIPO_OCORRENCIA"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Fase_da_Operacao)
                .HasColumnName(_configuration["VAR:FASE_OPERACAO"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Operacao)
                .HasColumnName(_configuration["VAR:OPERACAO"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Danos_a_Aeronave)
                .HasColumnName(_configuration["VAR:DANOS_AERONAVE"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Aerodromo_de_Destino)
                .HasColumnName(_configuration["VAR:AERODROMO_DESTINO"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Aerodromo_de_Origem)
                .HasColumnName(_configuration["VAR:AERODROMO_ORIGEM"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Lesoes_Fatais_Tripulantes)
                .HasColumnName(_configuration["VAR:LESOES_FATAIS_TRIPULANTES"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Lesoes_Fatais_Passageiros)
                .HasColumnName(_configuration["VAR:LESOES_FATAIS_PASSAGEIROS"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Lesoes_Fatais_Terceiros)
                .HasColumnName(_configuration["VAR:LESOES_FATAIS_TERCEIROS"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Lesoes_Graves_Tripulantes)
                .HasColumnName(_configuration["VAR:LESOES_GRAVES_TRIPULANTES"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Lesoes_Graves_Passageiros)
                .HasColumnName(_configuration["VAR:LESOES_GRAVES_PASSAGEIROS"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Lesoes_Graves_Terceiros)
                .HasColumnName(_configuration["VAR:LESOES_GRAVES_TERCEIROS"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Lesoes_Leves_Tripulantes)
                .HasColumnName(_configuration["VAR:LESOES_LEVES_TRIPULANTES"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Lesoes_Leves_Passageiros)
                .HasColumnName(_configuration["VAR:LESOES_LEVES_PASSAGEIROS"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Lesoes_Leves_Terceiros)
                .HasColumnName(_configuration["VAR:LESOES_LEVES_TERCEIROS"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Ilesos_Tripulantes)
                .HasColumnName(_configuration["VAR:ILESOS_TRIPULANTES"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Ilesos_Passageiros)
                .HasColumnName(_configuration["VAR:ILESOS_PASSAGEIROS"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Lesoes_Desconhecidas_Tripulantes)
                .HasColumnName(_configuration["VAR:LESOES_DESCONHECIDAS_TRIPULANTES"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Lesoes_Desconhecidas_Passageiros)
                .HasColumnName(_configuration["VAR:LESOES_DESCONHECIDAS_PASSAGEIROS"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Lesoes_Desconhecidas_Terceiros)
                .HasColumnName(_configuration["VAR:LESOES_DESCONHECIDAS_TERCEIROS"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Modelo)
                .HasColumnName(_configuration["VAR:MODELO"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.CLS)
                .HasColumnName(_configuration["VAR:CLS"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Tipo_ICAO)
                .HasColumnName(_configuration["VAR:TIPO_ICAO"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.PMD)
                .HasColumnName(_configuration["VAR:PMD"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Numero_de_Assentos)
                .HasColumnName(_configuration["VAR:NUMERO_ASSENTOS"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.Nome_do_Fabricante)
                .HasColumnName(_configuration["VAR:NOME_FABRICANTE"]);

            modelBuilder.Entity<OcorrenciaModel>()
                .Property(p => p.PSSO)
                .HasColumnName(_configuration["VAR:PSSO"]);            
        }
    }
}
