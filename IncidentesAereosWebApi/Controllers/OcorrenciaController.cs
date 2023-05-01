using IncidentesAereosWebApi.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

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
        public async Task<IActionResult> ListarOcorrenciaPorUf(string uf)
        {
            if (uf != null && uf != string.Empty)
                uf = uf.Trim();

            if (Regex.IsMatch(uf, "^[A-Za-z]{2}$"))
            {
                uf = uf.ToUpper();

                var ocorrencias = await _ocorrencia.ListarOcorrenciaPorExpressao(o => o.UF == uf);

                if (ocorrencias != null && ocorrencias.Count() > 0)
                    return Ok(ocorrencias);
                else
                    return BadRequest($"Não foi possível retornar as ocorrências por: {uf}");
            }
            else
                return BadRequest("Informe uma UF válida. Ex.: MG.");
        }

        [Route("/ocorrencias/icao/{icao}")]
        [HttpGet]
        public async Task<IActionResult> ListarOcorrenciaPorIcao(string icao)
        {
            if (icao != null && icao != string.Empty)
                icao = icao.Trim();

            if (Regex.IsMatch(icao, "^[A-Za-z]{4}$"))
            {
                icao = icao.ToUpper();

                var ocorrencias = await _ocorrencia.ListarOcorrenciaPorExpressao(o => o.ICAO == icao);

                if (ocorrencias != null && ocorrencias.Count() > 0)
                    return Ok(ocorrencias);
                else
                    return BadRequest($"Não foi possível retornar as ocorrências por: {icao}");
            }
            else
                return BadRequest("Informe um ICAO válido. Ex.: SBCF.");
        }

        [Route("/ocorrencias/municipio/{municipio}")]
        [HttpGet]
        public async Task<IActionResult> ListarOcorrenciaPorMunicipio(string municipio)
        {
            if(municipio != null && municipio != string.Empty)
                municipio = municipio.TrimStart().TrimEnd();

            if (Regex.IsMatch(municipio, "[a-zA-Z]+"))
            {
                municipio = municipio.ToUpper();

                var ocorrencias = await _ocorrencia.ListarOcorrenciaPorExpressao(o => o.Municipio == municipio);

                if (ocorrencias != null && ocorrencias.Count() > 0)
                    return Ok(ocorrencias);
                else
                    return BadRequest($"Não foi possível retornar as ocorrências por: {municipio}");
            }
            else
                return BadRequest("Informe um município válido. Ex.: São Paulo.");
        }

        [Route("/ocorrencias/fatais")]
        [HttpGet]
        public async Task<IActionResult> ListarOcorrenciaVitimasFatais()
        {
            var ocorrencias = await _ocorrencia.ListarOcorrenciaPorExpressao(o => o.Lesoes_Fatais_Tripulantes > 0 || o.Lesoes_Fatais_Passageiros > 0 || o.Lesoes_Fatais_Terceiros > 0 || o.Historico.Contains("faleceram") || o.Historico.Contains("faleceu"));

            if (ocorrencias != null && ocorrencias.Count() > 0)
                return Ok(ocorrencias);
            else
                return BadRequest("Nenhuma ocorrência com vítimas fatais foi encontrada.");
        }

        [Route("/ocorrencias/ano/{ano}")]
        [HttpGet]
        public async Task<IActionResult> ListarOcorrenciaAno(string ano)
        {
            if (ano != null && ano != string.Empty)
                ano = ano.Trim();

            if(Regex.IsMatch(ano, @"^\d{4}$"))
            {
                var ocorrencias = await _ocorrencia.ListarOcorrenciaPorExpressao(o => o.Data_da_Ocorrencia.Contains(ano));

                if (ocorrencias != null && ocorrencias.Count() > 0)
                    return Ok(ocorrencias);
                else
                    return BadRequest($"Não foi possível retornar as ocorrências por: {ano}.");
            }
            else 
                return BadRequest("Informe um ano válido. Ex.: 2013.");
        }
    }
}
