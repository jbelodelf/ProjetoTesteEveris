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
    public class ContaMovimentoHistoricoRepository : IContaMovimentoHistoricoRepository
    {
        private readonly IMapperEntityAndDto _mapper;
        private IConfiguration _configuration;

        public ContaMovimentoHistoricoRepository(IMapperEntityAndDto mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _configuration = configuration;
        }

        public List<ContaMovimentoHistoricoDTO> ListarContaMovimentoHistoricos(int cdConta)
        {
            List<ContaMovimentoHistoricoEntity> ListarContaMovimentoHistoricos = new List<ContaMovimentoHistoricoEntity>();
            //string[] includes = new string[] { "Unidades", "Contatos" };
            Expression<Func<ContaMovimentoHistoricoEntity, bool>> expressionFiltro = (a => a.CdConta == cdConta);

            using (var rep = new RepositoryBase<ContaMovimentoHistoricoEntity>(_configuration))
            {
                ListarContaMovimentoHistoricos = rep.Select(expressionFiltro).ToList();
            }

            return _mapper.GetMapperListEntityToDto(ListarContaMovimentoHistoricos);
        }

        public ContaMovimentoHistoricoDTO ObterContaMovimentoHistoricoById(int Id)
        {
            ContaMovimentoHistoricoEntity contaMovimentoHistorico = null;
            //string[] includes = new string[] { "Unidades", "Contatos" };
            Expression<Func<ContaMovimentoHistoricoEntity, bool>> expressionFiltro = (a => a.CdHistorico == (Int64)Id);

            using (var rep = new RepositoryBase<ContaMovimentoHistoricoEntity>(_configuration))
            {
                contaMovimentoHistorico = rep.Select(expressionFiltro).FirstOrDefault();
            }

            return _mapper.GetMapperEntityToDto(contaMovimentoHistorico);
        }

        public void Salvar(ContaMovimentoHistoricoDTO contaMovimentoHistorico)
        {
            using (var rep = new RepositoryBase<ContaMovimentoHistoricoEntity>(_configuration))
            {
                rep.Insert(_mapper.GetMapperDtoToEntity(contaMovimentoHistorico));
            }
        }
    }
}
