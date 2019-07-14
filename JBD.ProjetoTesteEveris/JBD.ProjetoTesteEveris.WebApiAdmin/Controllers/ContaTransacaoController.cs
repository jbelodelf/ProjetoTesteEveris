using System.Net;
using JBD.ProjetoTesteEveris.Application.Interfaces;
using JBD.ProjetoTesteEveris.Domain.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace JBD.ProjetoTesteEveris.WebApiAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaTransacaoController : ControllerBase
    {
        IContaTransacaoRepositoryApp _transacaoApp;

        public ContaTransacaoController(IContaTransacaoRepositoryApp transacaoApp)
        {
            _transacaoApp = transacaoApp;
        }

        [AcceptVerbs("GET")]
        [Route("ListarTransacoes")]
        public ObjectResult Get(string agOrigem, string numContaOrigem)
        {
            var transacoesDTO = _transacaoApp.ListarContaTransacaos(agOrigem, numContaOrigem);
            return StatusCode((int)HttpStatusCode.OK, transacoesDTO);
        }

        [AcceptVerbs("GET")]
        [Route("ObterTransacaoById/{id}")]
        public ObjectResult Get(int id)
        {
            var transacoesDTO = _transacaoApp.ObterContaTransacaoById(id);
            return StatusCode((int)HttpStatusCode.OK, transacoesDTO);
        }

        [AcceptVerbs("POST")]
        [Route("InserirTransacao")]
        public ObjectResult Post([FromBody] ContaTransacaoDTO contaTransacao)
        {
            _transacaoApp.Salvar(contaTransacao);
            return StatusCode((int)HttpStatusCode.Created, contaTransacao);
        }
    }
}
