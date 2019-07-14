using JBD.ProjetoTesteEveris.Data.Repositories.Base;
using JBD.ProjetoTesteEveris.Domain.DTOS;
using JBD.ProjetoTesteEveris.Domain.Entitys;
using JBD.ProjetoTesteEveris.Domain.Interfaces.Repository;
using JBD.ProjetoTesteEveris.Domain.Interfaces.Repository.Base;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace JBD.ProjetoTesteEveris.Data.Repositories
{
    public class ContaTransacaoRepository : IContaTransacaoRepository
    {
        private readonly IMapperEntityAndDto _mapper;
        private IConfiguration _configuration;

        public ContaTransacaoRepository(IMapperEntityAndDto mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _configuration  = configuration;
        }

        public List<ContaTransacaoDTO> ListarContaTransacaos(string agOrigem, string numContaOrigem)
        {
            List<ContaTransacaoEntity> ListarContaTransacaos = new List<ContaTransacaoEntity>();
            Expression<Func<ContaTransacaoEntity, bool>> expressionFiltro = (a => a.AgContaOrigem == agOrigem && a.NumContaOrigem == numContaOrigem);

            using (var rep = new RepositoryBase<ContaTransacaoEntity>(_configuration))
            {
                ListarContaTransacaos = rep.Select(expressionFiltro).ToList();
            }

            return _mapper.GetMapperListEntityToDto(ListarContaTransacaos);
        }

        public ContaTransacaoDTO ObterContaTransacaoById(int Id)
        {
            ContaTransacaoEntity contaTransacao = null;
            Expression<Func<ContaTransacaoEntity, bool>> expressionFiltro = (a => a.CdTransacao == (Int64)Id);

            using (var rep = new RepositoryBase<ContaTransacaoEntity>(_configuration))
            {
                contaTransacao = rep.Select(expressionFiltro).FirstOrDefault();
            }

            return _mapper.GetMapperEntityToDto(contaTransacao);
        }

        public void Salvar(ContaTransacaoDTO contaTransacao)
        {
            using (var rep = new RepositoryBase<ContaTransacaoEntity>(_configuration))
            {
                rep.Insert(_mapper.GetMapperDtoToEntity(contaTransacao));
            }
        }

        public void Atualizar(ContaTransacaoDTO contaTransacao)
        {
            using (var rep = new RepositoryBase<ContaTransacaoEntity>(_configuration))
            {
                rep.Update(_mapper.GetMapperDtoToEntity(contaTransacao));
            }
        }
    }
}
