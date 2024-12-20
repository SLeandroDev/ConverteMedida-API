using ConversorDeMedidas.API.Services;
using Microsoft.AspNetCore.Mvc;
using static ConversorDeMedidas.API.Services.ConversorServiceComprimento;
using static ConversorDeMedidas.API.Services.ConversorServiceLiquido;
using static ConversorDeMedidas.API.Services.ConversorServicePeso;

namespace ConversorDeMedidas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/comprimento")]
    public class ConversorComprimentoController : ControllerBase
    {
        private readonly ConversorServiceComprimento _conversorServiceComprimento;

        public ConversorComprimentoController()
        {
            _conversorServiceComprimento = new ConversorServiceComprimento();
        }

        [HttpGet()]
        public ActionResult<double> Convert(double valor, string unidadeOrigem, string unidadeDestino)
        {
            if (valor == 0)
            {
                return BadRequest("Favor preencha um valor para ser convertido.");
            }

            var mensagemErro = unidadeOrigem switch
            {
                "Selecione" => "Favor selecionar uma unidade de origem.",
                _ when unidadeDestino == "Selecione" => "Favor selecionar uma unidade de destino.",
                _ when unidadeOrigem == unidadeDestino => "Favor selecionar opções diferentes para conversão.",
                _ => null
            };

            if (!string.IsNullOrEmpty(mensagemErro))
            {
                return BadRequest(mensagemErro);
            }

            if (!Enum.TryParse<UnidadeComprimento>(unidadeOrigem, true, out var origem) ||
                !Enum.TryParse<UnidadeComprimento>(unidadeDestino, true, out var destino))
            {
                return BadRequest("Unidades de origem ou destino inválidas.");
            }

            var resultado = _conversorServiceComprimento.Converter(valor, origem, destino);
            return Ok(resultado);
        }
    }

    [Route("api/[controller]/peso")]
    public class ConversorPesoController : ControllerBase
    {
        private readonly ConversorServicePeso _conversorServicePeso;

        public ConversorPesoController()
        {
            _conversorServicePeso = new ConversorServicePeso();
        }

        [HttpGet()]
        public ActionResult<double> Convert(double valor, string unidadeOrigem, string unidadeDestino)
            {

            if (valor == 0)
            {
                return BadRequest("Favor preencha um valor para ser convertido.");
            }

            var mensagemErro = unidadeOrigem switch
            {
                "Selecione" => "Favor selecionar uma unidade de origem.",
                _ when unidadeDestino == "Selecione" => "Favor selecionar uma unidade de destino.",
                _ when unidadeOrigem == unidadeDestino => "Favor selecionar opções diferentes para conversão.",
                _ => null
            };

            if (!string.IsNullOrEmpty(mensagemErro))
            {
                return BadRequest(mensagemErro);
            }

            if (!Enum.TryParse<UnidadePeso>(unidadeOrigem, true, out var origem) ||
                !Enum.TryParse<UnidadePeso>(unidadeDestino, true, out var destino))
            {
                return BadRequest("Unidades de origem ou destino inválidas.");
            }
            var resultado = _conversorServicePeso.Converter(valor, origem, destino);
            return Ok(resultado);
        }
    }

    [Route("api/[controller]/liquido")]
    public class ConversorLiquidoController : ControllerBase
    {
        private readonly ConversorServiceLiquido _conversorServiceLiquido;

        public ConversorLiquidoController()
        {
            _conversorServiceLiquido = new ConversorServiceLiquido();
        }

        [HttpGet()]
        public ActionResult<double> Convert(double valor, string unidadeOrigem, string unidadeDestino)
        {
            if(valor == 0)
{
                return BadRequest("Favor preencha um valor para ser convertido.");
            }

            var mensagemErro = unidadeOrigem switch
            {
                "Selecione" => "Favor selecionar uma unidade de origem.",
                _ when unidadeDestino == "Selecione" => "Favor selecionar uma unidade de destino.",
                _ when unidadeOrigem == unidadeDestino => "Favor selecionar opções diferentes para conversão.",
                _ => null
            };

            if (!string.IsNullOrEmpty(mensagemErro))
            {
                return BadRequest(mensagemErro);
            }

            if (!Enum.TryParse<UnidadeLiquido>(unidadeOrigem, true, out var origem) ||
                !Enum.TryParse<UnidadeLiquido>(unidadeDestino, true, out var destino))
            {
                return BadRequest("Unidades de origem ou destino inválidas.");
            }
            var resultado = _conversorServiceLiquido.Converter(valor, origem, destino);
            return Ok(resultado);
        }
    }
}
