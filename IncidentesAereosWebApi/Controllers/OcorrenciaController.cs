using IncidentesAereosWebApi.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace IncidentesAereosWebApi.Controllers
{
    [Route("/ocorrencias/v1")]
    [ApiController]
    public class OcorrenciaController : ControllerBase
    {
        private readonly IOcorrenciaServicos _ocorrencia;

        public OcorrenciaController(IOcorrenciaServicos ocorrencia)
        {
            _ocorrencia = ocorrencia;
        }

        [HttpGet]
        public async Task<IActionResult> ListarOcorrencias()
        {
            try
            {
                var ocorrencias = await _ocorrencia.ListarOcorrencias();

                if (ocorrencias != null && ocorrencias.Count() > 0)
                    return Ok(ocorrencias);
                else
                    return NotFound("Nenhuma ocorrência encontrada.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Ocorreu um erro ao retornar todas as ocorrências.");
            }
        }

        [Route("/ocorrencias/v1/uf/{uf}")]
        [HttpGet]
        public async Task<IActionResult> ListarOcorrenciaPorUf(string uf)
        {
            try
            {
                string regex = "^[A-Za-z]{2}$";

                if (uf != null && uf != string.Empty)
                    uf = uf.Trim();

                if (Regex.IsMatch(uf, regex))
                {
                    uf = uf.ToUpper();

                    var ocorrencias = await _ocorrencia.ListarOcorrenciaPorExpressao(o => o.UF == uf);

                    if (ocorrencias != null && ocorrencias.Count() > 0)
                        return Ok(ocorrencias);
                    else
                        return NotFound($"Nenhuma ocorrência por: '{uf}' encontrada.");
                }
                else
                    return BadRequest("Informe uma UF válida. Ex.: MG.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Ocorreu um erro ao retornar as ocorrências por UF.");
            }
        }

        [Route("/ocorrencias/v1/icao/{icao}")]
        [HttpGet]
        public async Task<IActionResult> ListarOcorrenciaPorIcao(string icao)
        {
            try
            {
                string regex = "^[A-Za-z]{4}$";

                if (icao != null && icao != string.Empty)
                    icao = icao.Trim();

                if (Regex.IsMatch(icao, regex))
                {
                    icao = icao.ToUpper();

                    var ocorrencias = await _ocorrencia.ListarOcorrenciaPorExpressao(o => o.ICAO == icao);

                    if (ocorrencias != null && ocorrencias.Count() > 0)
                        return Ok(ocorrencias);
                    else
                        return NotFound($"Nenhuma ocorrência por: '{icao}' encontrada.");
                }
                else
                    return BadRequest("Informe um ICAO válido. Ex.: SBCF.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Ocorreu um erro ao retornar as ocorrências por ICAO.");
            }
        }

        [Route("/ocorrencias/v1/municipio/{municipio}")]
        [HttpGet]
        public async Task<IActionResult> ListarOcorrenciaPorMunicipio(string municipio)
        {
            try
            {
                string regex = "[a-zA-Z]+";

                if (municipio != null && municipio != string.Empty)
                    municipio = municipio.TrimStart().TrimEnd();

                if (Regex.IsMatch(municipio, regex))
                {
                    municipio = municipio.ToUpper();

                    var ocorrencias = await _ocorrencia.ListarOcorrenciaPorExpressao(o => o.Municipio == municipio);

                    if (ocorrencias != null && ocorrencias.Count() > 0)
                        return Ok(ocorrencias);
                    else
                        return NotFound($"Nenhuma ocorrência por: '{municipio}' encontrada.");
                }
                else
                    return BadRequest("Informe um município válido. Ex.: São Paulo.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: ${ex.Message}");
                return StatusCode(500, "Ocorreu um erro ao retornar as ocorrências por município.");
            }
        }

        [Route("/ocorrencias/v1/fatais/")]
        [HttpGet]
        public async Task<IActionResult> ListarOcorrenciaVitimasFatais()
        {
            try
            {
                var ocorrencias = await _ocorrencia.ListarOcorrenciaPorExpressao(o => o.Lesoes_Fatais_Tripulantes > 0 || o.Lesoes_Fatais_Passageiros > 0 || o.Lesoes_Fatais_Terceiros > 0 || o.Historico.Contains("faleceram") || o.Historico.Contains("faleceu"));

                if (ocorrencias != null && ocorrencias.Count() > 0)
                    return Ok(ocorrencias);
                else
                    return NotFound("Nenhuma ocorrência com vítimas fatais foi encontrada.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: ${ex.Message}");
                return StatusCode(500, "Ocorreu um erro ao retornar as ocorrências com vítimas fatais.");
            }
        }

        [Route("/ocorrencias/v1/ano/{ano}")]
        [HttpGet]
        public async Task<IActionResult> ListarOcorrenciaAno(int ano)
        {
            try
            {
                string regex = @"^\d{4}$";

                if (Regex.IsMatch(ano.ToString(), regex))
                {
                    var ocorrencias = await _ocorrencia.ListarOcorrenciaPorExpressao(o => o.Data_da_Ocorrencia.Year == ano);

                    if (ocorrencias != null && ocorrencias.Count() > 0)
                        return Ok(ocorrencias);
                    else
                        return NotFound($"Nenhuma ocorrência por: '{ano}' encontrada.");
                }
                else
                    return BadRequest("Informe um ano válido. Ex.: 2013.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Ocorreu um erro ao retornar as ocorrências por ano.");
            }
        }

        [Route("/ocorrencias/v1/fabricante/{fabricante}")]
        [HttpGet]
        public async Task<IActionResult> ListarOcorrenciasPorFabricante(string fabricante)
        {
            try
            {
                string regex = "[a-zA-Z]+";

                if (fabricante != null && fabricante != string.Empty)
                    fabricante = fabricante.TrimStart().TrimEnd();

                if (Regex.IsMatch(fabricante, regex))
                {
                    fabricante = fabricante.ToUpper();
                    var ocorrencias = await _ocorrencia.ListarOcorrenciaPorExpressao(o => o.Nome_do_Fabricante.Contains(fabricante));

                    if (ocorrencias != null && ocorrencias.Count() > 0)
                        return Ok(ocorrencias);
                    else
                        return NotFound($"Nenhuma ocorrência por: {fabricante} encontrada.");
                }
                else
                    return BadRequest("Informe um nome de fabricante válido. Ex.: CESSNA AIRCRAFT");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Ocorreu um erro ao retornar as ocorrências por fabricante.");
            }
        }

        /// <summary>
        /// Retorna a lista de ocorrências por tipo de operação.
        /// </summary>
        /// <param name="operacao">O tipo de operação pode ser: Voo Privado, Voo de Instrução e Voo Regular</param>
        /// <returns></returns>
        [Route("/ocorrencias/v1/operacao/{operacao}")]
        [HttpGet]
        public async Task<IActionResult> ListarOcorrenciasPorOperacao(string operacao)
        {
            try
            {
                string regex = "[a-zA-Z]+";

                if (operacao != null && operacao != string.Empty)
                    operacao = operacao.TrimStart().TrimEnd();

                if (Regex.IsMatch(operacao, regex))
                {
                    //operacao = operacao.ToUpper();
                    var ocorrencias = await _ocorrencia.ListarOcorrenciaPorExpressao(o => o.Operacao == operacao);

                    if (ocorrencias != null && ocorrencias.Count() > 0)
                        return Ok(ocorrencias);
                    else
                        return NotFound($"Nunhuma ocorrência por: '{operacao}' encontrada");
                }
                else
                    return BadRequest("Informe uma operação válida. Ex.: Voo Privado");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Ocorreu um erro ao retornar as ocorrências por operação.");
            }
        }

        [Route("/ocorrencias/v1/periodo")]
        [HttpGet]
        public async Task<IActionResult> ListarOcorrenciasPorPeriodo([FromQuery] int anoInicio, [FromQuery] int anoFinal)
        {
            try
            {
                string regex = @"^\d{4}$";

                if (Regex.IsMatch(anoInicio.ToString(), regex) && Regex.IsMatch(anoFinal.ToString(), regex))
                {
                    var ocorrencias = await _ocorrencia.ListarOcorrenciaPorExpressao(o => o.Data_da_Ocorrencia.Year >= anoInicio && o.Data_da_Ocorrencia.Year <= anoFinal);

                    if (ocorrencias != null && ocorrencias.Count() > 0)
                        return Ok(ocorrencias);
                    else
                        return NotFound($"Nenhuma ocorrência pelo período: '{anoInicio}-{anoFinal}' encontrada");
                }
                else
                    return BadRequest($"Informe um período válido. Ex.: 2019-2021");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Ocorreu um erro ao retornar as ocorrências por período.");
            }
        }

        /// <summary>
        /// Retorna a lista de ocorrências por fase da operação.
        /// </summary>
        /// <param name="faseOperacao">A fase da operação pode ser: Decolagem, Corrida após pouso, Cruzeiro, Descida, Subida, Pouso, Aproximação, Táxi, Arremetida, Manobra, Procedimento de Aproximação, Estacionamento, Indeterminada, Voo a baixa altura, Em rota, Circuto de Tráfego[sic], Operação de Solo, Cheque de motor ou rotor.</param>
        /// <returns></returns>
        [Route("/ocorrencias/v1/fase/{faseOperacao}")]
        [HttpGet]
        public async Task<IActionResult> ListarOcorrenciasPorFaseOperacao(string faseOperacao)
        {
            try
            {
                string regex = "[a-zA-Z]+";

                if (faseOperacao != null && faseOperacao != string.Empty)
                    faseOperacao = faseOperacao.Trim();

                if (Regex.IsMatch(faseOperacao, regex))
                {
                    var ocorrencias = await _ocorrencia.ListarOcorrenciaPorExpressao(o => o.Fase_da_Operacao == faseOperacao);

                    if (ocorrencias != null && ocorrencias.Count() > 0)
                        return Ok(ocorrencias);
                    else
                        return NotFound($"Nenhuma ocorrência por: '{faseOperacao}' encontrada");
                }
                else
                    return BadRequest("Informe uma fase de operação válida. Ex.: Cruzeiro");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Ocorreu um erro ao retornar as ocorrências por fase de operação.");
            }
        }

        [Route("/ocorrencias/v1/{numeroOcorrencia}")]
        [HttpGet]
        public async Task<IActionResult> ListarPorNumeroOcorrencia(int numeroOcorrencia)
        {
            try
            {
                string regex = @"^\d";
                string numeroOcorrenciaString = numeroOcorrencia.ToString();

                if (Regex.IsMatch(numeroOcorrenciaString, regex))
                {
                    var ocorrencia = await _ocorrencia.ListarOcorrenciaPorExpressao(o => o.Numero_da_Ocorrencia == numeroOcorrenciaString);

                    if (ocorrencia != null && ocorrencia.Count() > 0)
                        return Ok(ocorrencia);
                    else
                        return NotFound($"Nenhuma ocorrência de número {numeroOcorrenciaString} encontrada.");
                }
                else
                    return BadRequest("Informe um número de ocorrência válido. Ex.: 4256");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Ocorreu um erro ao retornar as ocorrências por número de ocorrência.");
            }
        }
    }
}
