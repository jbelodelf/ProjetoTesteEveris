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
    public class EmpresaServiceWeb
    {
        private readonly IMapper _mapper;

        public EmpresaServiceWeb(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<ContaTransacaoViewModel> ListarEmpresas()
        {
            using (HttpClient client = new HttpClient())
            {
                ServiceBase(client);
                HttpResponseMessage response = client.GetAsync("ListarEmpresas").Result;
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
                HttpResponseMessage response = client.GetAsync("ObterEmpresa/" + IdContaTransacao).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                ContaTransacaoDTO data = JsonConvert.DeserializeObject<ContaTransacaoDTO>(stringData);

                var empresaModel = _mapper.Map<ContaTransacaoViewModel>(data);
                return empresaModel;
            }
        }

        public bool VeficaDuplicidadeCnpjCpf(string cnpjcpf)
        {
            using (HttpClient client = new HttpClient())
            {
                ServiceBase(client);
                HttpResponseMessage response = client.GetAsync("GetVerificaDuplicidadeCPF/" + cnpjcpf).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<bool>(stringData);

                return data;
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
                HttpResponseMessage response = client.PostAsync("InserirEmpresa", conteudo).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                ContaTransacaoDTO data = JsonConvert.DeserializeObject<ContaTransacaoDTO>(stringData);
            }
        }

        public void AlterarEmpresa(ContaTransacaoViewModel contaTransacao)
        {
            using (HttpClient client = new HttpClient())
            {
                var contaTransacaoDTO = _mapper.Map<ContaTransacaoDTO>(contaTransacao);
                ServiceBase(client);
                string parametroJSON = JsonConvert.SerializeObject(contaTransacaoDTO);
                StringContent conteudo = new StringContent(parametroJSON, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync("AlterarEmpresa", conteudo).Result;
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
