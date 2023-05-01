using IncidentesAereosWebApi.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace IncidentesAereosWebApi.Controllers
{    
    [ApiController]
    public class OcorrenciaController : ControllerBase
    {
        private readonly IOcorrenciaServicos _ocorrencia;

        public OcorrenciaController(IOcorrenciaServicos ocorrencia)
        {
            _ocorrencia = ocorrencia;
        }

        [Route("/ocorrencias/uf/{uf}")]
        [HttpGet]
        public async Task<IActionResult> ListarOcorrenciaPorUf(string? uf)
        {
            if (uf != null && uf != string.Empty && uf.Length == 2)
                uf = uf.ToUpper();

            var ocorrencias = await _ocorrencia.ListarOcorrenciaPorExpressao(o => o.UF == uf);

            if (ocorrencias != null && ocorrencias.Count() > 0)
                return Ok(ocorrencias);
            else
                return BadRequest($"Não foi possível retornar as ocorrências por: {uf}");
        }

        [Route("/ocorrencias/icao/{icao}")]
        [HttpGet]
        public async Task<IActionResult> ListarOcorrenciaPorIcao(string? icao)
        {
            if(icao != null && icao != string.Empty) 
                icao = icao.ToUpper();

            var ocorrencias = await _ocorrencia.ListarOcorrenciaPorExpressao(o => o.ICAO == icao);

            if (ocorrencias != null && ocorrencias.Count() > 0)
                return Ok(ocorrencias);
            else
                return BadRequest($"Não foi possível retornar as ocorrências por: {icao}");
        }

        [Route("/ocorrencias/municipio/{municipio}")]
        [HttpGet]
        public async Task<IActionResult> ListarOcorrenciaPorMunicipio(string? municipio)
        {
            if (municipio != null && municipio != string.Empty)
                municipio = municipio.ToUpper();

            var ocorrencias = await _ocorrencia.ListarOcorrenciaPorExpressao(o => o.Municipio == municipio);

            if (ocorrencias != null && ocorrencias.Count() > 0)
                return Ok(ocorrencias);
            else
                return BadRequest($"Não foi possível retornar as ocorrências por: {municipio}");
        }

        [Route("/ocorrencias/fatais")]
        [HttpGet]
        public async Task<IActionResult> ListarOcorrenciaVitimasFatais()
        {
            var ocorrencias = await _ocorrencia.ListarOcorrenciaPorExpressao(o => o.Lesoes_Fatais_Tripulantes > 0 || o.Lesoes_Fatais_Passageiros > 0 || o.Lesoes_Fatais_Terceiros > 0);

            if (ocorrencias != null && ocorrencias.Count() > 0)
                return Ok(ocorrencias);
            else
                return BadRequest("Nenhuma ocorrência com vítimas fatais foi encontrada.");
        }
    }
}
