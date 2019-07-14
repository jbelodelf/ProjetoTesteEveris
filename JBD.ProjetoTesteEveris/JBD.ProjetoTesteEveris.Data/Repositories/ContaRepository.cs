using JBD.ProjetoTesteEveris.Data.Repositories.Base;
using JBD.ProjetoTesteEveris.Domain.DTOS;
using JBD.ProjetoTesteEveris.Domain.Entitys;
using JBD.ProjetoTesteEveris.Domain.Enuns;
using JBD.ProjetoTesteEveris.Domain.Interfaces.Repository;
using JBD.ProjetoTesteEveris.Domain.Interfaces.Repository.Base;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace JBD.ProjetoTesteEveris.Data.Repositories
{
    public class ContaRepository : IContaRepository
    {
        private readonly IMapperEntityAndDto _mapper;
        private IConfiguration _configuration;

        public ContaRepository(IMapperEntityAndDto mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _configuration = configuration;
        }

        public void Deletar(int Id)
        {
            Expression<Func<ContaEntity, bool>> expressionFiltro = (a => a.ContaStatus != (int)StatusEnum.Excluido && a.CdConta == (Int64)Id);

            using (var rep = new RepositoryBase<ContaEntity>(_configuration))
            {
                ContaEntity conta = rep.Select(expressionFiltro).FirstOrDefault();
                if(conta != null)
                {
                    rep.Delete(conta);
                }
            }
        }

        public List<ContaDTO> ListarContas(string agOrigem, string numContaOrigem, string agDestino, string numContaDestino)
        {
            List<ContaEntity> ListaContas = new List<ContaEntity>();
            Expression<Func<ContaEntity, bool>> expressionFiltro = (a => a.ContaAgencia.Trim() == agOrigem.Trim() && a.ContaNumero.Trim() == numContaOrigem.Trim());

            using (var rep = new RepositoryBase<ContaEntity>(_configuration))
            {
                for (int i = 1; i <= 2; i++)
                {
                    var Conta = rep.Select(expressionFiltro).FirstOrDefault();
                    if (Conta != null)
                        ListaContas.Add(Conta);

                    if (i == 1)
                    {
                        expressionFiltro = (a => a.ContaAgencia.Trim() == agDestino.Trim() && a.ContaNumero.Trim() == numContaDestino.Trim());
                    }
                }
            }

            return _mapper.GetMapperListEntityToDto(ListaContas);
        }

        public List<ContaDTO> ListarContas(string nome, string cnpjcpf)
        {
            List<ContaEntity> ListarContas = new List<ContaEntity>();
            Expression<Func<ContaEntity, bool>> expressionFiltro = (a => a.ContaStatus != (int)StatusEnum.Excluido);

            using (var rep = new RepositoryBase<ContaEntity>(_configuration))
            {
                ListarContas = rep.Select(expressionFiltro).ToList();
            }

            return _mapper.GetMapperListEntityToDto(ListarContas);
        }

        public ContaDTO ObterContaById(int Id)
        {
            ContaEntity contaEntity = new ContaEntity();
            Expression<Func<ContaEntity, bool>> expressionFiltro = (a => a.ContaStatus != (int)StatusEnum.Excluido && a.CdConta == (Int64)Id);

            using (var rep = new RepositoryBase<ContaEntity>(_configuration))
            {
                contaEntity = rep.Select(expressionFiltro).FirstOrDefault();
            }

            return _mapper.GetMapperEntityToDto(contaEntity);
        }

        public void Salvar(ContaDTO conta)
        {
            using (var rep = new RepositoryBase<ContaEntity>(_configuration))
            {
                rep.Insert(_mapper.GetMapperDtoToEntity(conta));
            }
        }

        public void Atualizar(ContaDTO conta)
        {
            using (var rep = new RepositoryBase<ContaEntity>(_configuration))
            {
                rep.Update(_mapper.GetMapperDtoToEntity(conta));
            }
        }

        public ContaDTO ObterConta(string agConta, string numConta)
        {
            ContaEntity contaEntity = new ContaEntity();
            Expression<Func<ContaEntity, bool>> expressionFiltro = (a => a.ContaStatus != (int)StatusEnum.Excluido && a.ContaAgencia.Trim() == agConta.Trim() && a.ContaNumero.Trim() == numConta.Trim());

            using (var rep = new RepositoryBase<ContaEntity>(_configuration))
            {
                contaEntity = rep.Select(expressionFiltro).FirstOrDefault();
            }

            return _mapper.GetMapperEntityToDto(contaEntity);
        }
    }
}
