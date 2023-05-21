using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace IncidentesAereosWebApi.Models
{
    public class OcorrenciaModel
    {        
        private int _lesoesFataisTripulantes;
        private int _lesoesFataisPassageiros;
        private int _lesoesFataisTerceiros;
        private int _lesoesGravesTripulantes;
        private int _lesoesGravesPassageiros;
        private int _lesoesGravesTerceiros;
        private int _lesoesLevesTripulantes;
        private int _lesoesLevesPassageiros;
        private int _lesoesLevesTerceiros;
        private int _ilesosTripulantes;
        private int _ilesosPassageiros;
        private int _lesoesDesconhecidasTripulantes;
        private int _lesoesDesconhecidasPassageiros;
        private int _lesoesDesconhecidasTerceiros;
        private int _pmd;
        private int _numeroAssentos;
        private DateTime _dataOcorrencia;

        public int Id { get; set; }
        public string? Numero_da_Ocorrencia { get; set; }
        public string? Numero_da_Ficha { get; set; }        
        public string? Operador_Padronizado { get; set; }        
        public string? Classificacao_da_Ocorrencia { get; set; }        
        public DateTime Data_da_Ocorrencia { get => _dataOcorrencia; set => _dataOcorrencia = Convert.ToDateTime(value).ToUniversalTime(); }     
        public string? Hora_da_Ocorrencia { get; set; }
        public string? Municipio { get; set; }
        public string? UF { get; set; }
        public string? Regiao { get; set; }        
        public string? Descricao_do_Tipo { get; set; }
        public string? ICAO { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }        
        public string? Tipo_de_Aerodromo { get; set; }
        public string? Historico { get; set; }
        public string? Matricula { get; set; }        
        public string? Categoria_da_Aeronave { get; set; }
        public string? Operador { get; set; }        
        public string? Tipo_de_Ocorrencia { get; set; }        
        public string? Fase_da_Operacao { get; set; }
        public string? Operacao { get; set; }       
        public string? Danos_a_Aeronave { get; set; }        
        public string? Aerodromo_de_Destino { get; set; }        
        public string? Aerodromo_de_Origem { get; set; }        
        public int? Lesoes_Fatais_Tripulantes { get => _lesoesFataisTripulantes; set => _lesoesFataisTripulantes = Convert.ToInt32(value); }        
        public int? Lesoes_Fatais_Passageiros { get => _lesoesFataisPassageiros; set => _lesoesFataisPassageiros = Convert.ToInt32(value); }        
        public int? Lesoes_Fatais_Terceiros { get => _lesoesFataisTerceiros; set=> _lesoesFataisTerceiros = Convert.ToInt32(value); }        
        public int? Lesoes_Graves_Tripulantes { get => _lesoesGravesTripulantes; set => _lesoesGravesTripulantes = Convert.ToInt32(value); }        
        public int? Lesoes_Graves_Passageiros { get => _lesoesGravesPassageiros; set => _lesoesGravesPassageiros = Convert.ToInt32(value); }        
        public int? Lesoes_Graves_Terceiros { get => _lesoesGravesTerceiros; set=> _lesoesGravesTerceiros = Convert.ToInt32(value); }
        public int? Lesoes_Leves_Tripulantes { get => _lesoesLevesTripulantes; set => _lesoesLevesTripulantes = Convert.ToInt32(value); }        
        public int? Lesoes_Leves_Passageiros { get => _lesoesLevesPassageiros; set => _lesoesLevesPassageiros = Convert.ToInt32(value); }        
        public int? Lesoes_Leves_Terceiros { get => _lesoesLevesTerceiros; set => _lesoesLevesTerceiros = Convert.ToInt32(value); }        
        public int? Ilesos_Tripulantes { get => _ilesosTripulantes; set => _ilesosTripulantes = Convert.ToInt32(value); }        
        public int? Ilesos_Passageiros { get => _ilesosPassageiros; set => _ilesosPassageiros = Convert.ToInt32(value); }        
        public int? Lesoes_Desconhecidas_Tripulantes { get => _lesoesDesconhecidasTripulantes; set => _lesoesDesconhecidasTripulantes = Convert.ToInt32(value); }        
        public int? Lesoes_Desconhecidas_Passageiros { get => _lesoesDesconhecidasPassageiros; set => _lesoesDesconhecidasPassageiros = Convert.ToInt32(value); }        
        public int? Lesoes_Desconhecidas_Terceiros { get => _lesoesDesconhecidasTerceiros; set => _lesoesDesconhecidasTerceiros = Convert.ToInt32(value); }
        public string? Modelo { get; set; }
        public string? CLS { get; set; }        
        public string? Tipo_ICAO { get; set; }
        public int? PMD { get => _pmd; set => _pmd = Convert.ToInt32(value); }        
        public int? Numero_de_Assentos { get => _numeroAssentos; set => _numeroAssentos = Convert.ToInt32(value); }        
        public string? Nome_do_Fabricante { get; set; }
        public string? PSSO { get; set; }        
    }
}
