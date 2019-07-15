using AutoMapper;
using JBD.ProjetoTesteEveris.Domain.DTOS;
using JBD.ProjetoTesteEveris.WebAdmin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace JBD.ProjetoTesteEveris.WebAdmin.Services
{
    public class TransacaoServiceWeb
    {
        private readonly IMapper _mapper;

        public TransacaoServiceWeb(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<ContaTransacaoViewModel> ListarEmpresas(string agOrigem, string numContaOrigem)
        {
            using (HttpClient client = new HttpClient())
            {
                ServiceBase(client);
                var uri = string.Format("ListarTransacoes/{0}/{1}", agOrigem, numContaOrigem);
                HttpResponseMessage response = client.GetAsync(uri).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                List<ContaTransacaoDTO> data = JsonConvert.DeserializeObject<List<ContaTransacaoDTO>>(stringData);

                var empresasModel = _mapper.Map<List<ContaTransacaoViewModel>>(data);
                return empresasModel;
            }
        }

        public ContaTransacaoViewModel ObterEmpresa(int IdContaTransacao)
        {
            using (HttpClient client = new HttpClient())
            {
                ServiceBase(client);
                HttpResponseMessage response = client.GetAsync("ObterTransacaoById/" + IdContaTransacao).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                ContaTransacaoDTO data = JsonConvert.DeserializeObject<ContaTransacaoDTO>(stringData);

                var empresaModel = _mapper.Map<ContaTransacaoViewModel>(data);
                return empresaModel;
            }
        }

        public void CadastrarEmpresa(ContaTransacaoViewModel contaTransacao)
        {
            using (HttpClient client = new HttpClient())
            {
                var contaTransacaoDTO = _mapper.Map<ContaTransacaoDTO>(contaTransacao);
                ServiceBase(client);
                string parametroJSON = JsonConvert.SerializeObject(contaTransacaoDTO);
                StringContent conteudo = new StringContent(parametroJSON, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("InserirTransacao", conteudo).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                ContaTransacaoDTO data = JsonConvert.DeserializeObject<ContaTransacaoDTO>(stringData);
            }
        }

        public void ServiceBase(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:52936/api/ContaTransacao/");
            MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
        }

    }
}
