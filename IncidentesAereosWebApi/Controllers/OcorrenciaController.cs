﻿using IncidentesAereosWebApi.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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

        [Route("/ocorrencias")]
        [HttpGet]
        public async Task<IActionResult> ListarOcorrencias()
        {
            var ocorrencias = await _ocorrencia.ListarOcorrencias();

            if (ocorrencias != null && ocorrencias.Count() > 0)
                return Ok(ocorrencias);
            else
                return BadRequest("Não foi possível retornar todas as ocorrências.");
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
        public async Task<IActionResult> ListarOcorrenciaAno(int ano)
        {            
            if (Regex.IsMatch(ano.ToString(), @"^\d{4}$"))
            {
                var ocorrencias = await _ocorrencia.ListarOcorrenciaPorExpressao(o => o.Data_da_Ocorrencia.Year == ano);

                if (ocorrencias != null && ocorrencias.Count() > 0)
                    return Ok(ocorrencias);
                else
                    return BadRequest($"Não foi possível retornar as ocorrências por: {ano}.");
            }
            else
                return BadRequest("Informe um ano válido. Ex.: 2013.");
        }

        [Route("/ocorrencias/fabricante/{fabricante}")]
        [HttpGet]
        public async Task<IActionResult> ListarOcorrenciasPorFabricante(string fabricante)
        {
            if(fabricante != null && fabricante != string.Empty)
                fabricante = fabricante.TrimStart().TrimEnd();

            if (Regex.IsMatch(fabricante, "[a-zA-Z]+"))
            {
                fabricante = fabricante.ToUpper();
                var ocorrencias = await _ocorrencia.ListarOcorrenciaPorExpressao(o => o.Nome_do_Fabricante.Contains(fabricante));

                if (ocorrencias != null && ocorrencias.Count() > 0)
                    return Ok(ocorrencias);
                else
                    return BadRequest($"Não foi possível retornar as ocorrências por: {fabricante}");
            }
            else
                return BadRequest("Informe um nome de fabricante válido. Ex.: CESSNA AIRCRAFT");
        }

        /// <summary>
        /// Retorna a lista de ocorrências por tipo de operação.
        /// </summary>
        /// <param name="operacao">O tipo de operação pode ser: Voo Privado, Voo de Instrução e Voo Regular</param>
        /// <returns></returns>
        [Route("/ocorrencias/operacao/{operacao}")]
        [HttpGet]
        public async Task<IActionResult> ListarOcorrenciasPorOperacao(string operacao)
        {
            if (operacao != null && operacao != string.Empty)
                operacao = operacao.TrimStart().TrimEnd();

            if (Regex.IsMatch(operacao, "[a-zA-Z]+"))
            {
                //operacao = operacao.ToUpper();
                var ocorrencias = await _ocorrencia.ListarOcorrenciaPorExpressao(o => o.Operacao == operacao);

                if (ocorrencias != null && ocorrencias.Count() > 0)
                    return Ok(ocorrencias);
                else
                    return BadRequest($"Não foi possível retornar as ocorrências por: {operacao}");
            }
            else
                return BadRequest("Informe uma operação válida. Ex.: Voo Privado");
        }

        [Route("/ocorrencias/inicio/{anoInicio}/fim/{anoFinal}")]
        [HttpGet]
        public async Task<IActionResult> ListarOcorrenciasPorPeriodo(int anoInicio, int anoFinal)
        {
            if (Regex.IsMatch(anoInicio.ToString(), @"^\d{4}$") && Regex.IsMatch(anoFinal.ToString(), @"^\d{4}$"))
            {
                var ocorrencias = await _ocorrencia.ListarOcorrenciaPorExpressao(o => o.Data_da_Ocorrencia.Year >= anoInicio && o.Data_da_Ocorrencia.Year <= anoFinal);

                if (ocorrencias != null && ocorrencias.Count() > 0)
                    return Ok(ocorrencias);
                else
                    return BadRequest($"Não foi possível retornar as ocorrências pelo período: {anoInicio}-{anoFinal}");
            }
            else
                return BadRequest($"Informa um período válido: 2019-2021");
        }
    }
}
