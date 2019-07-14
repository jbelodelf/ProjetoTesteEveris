using AutoMapper;
using JBD.ProjetoTesteEveris.Domain.DTOS;
using JBD.ProjetoTesteEveris.Domain.Entitys;
using JBD.ProjetoTesteEveris.Domain.Interfaces.Repository.Base;
using System.Collections.Generic;

namespace JBD.ProjetoTesteEveris.CrossCutting
{
    public class MapperEntityAndDto : IMapperEntityAndDto
    {
        private readonly IMapper _mapper;
        public MapperEntityAndDto(IMapper mapper)
        {
            _mapper = mapper;
        }

        //Conta
        public ContaEntity GetMapperDtoToEntity(ContaDTO contaDTO)
        {
            return _mapper.Map<ContaEntity>(contaDTO);
        }

        public ContaDTO GetMapperEntityToDto(ContaEntity contaEntity)
        {
            return _mapper.Map<ContaDTO>(contaEntity);
        }

        public List<ContaEntity> GetMapperListDtoToEntity(List<ContaDTO> contaDTO)
        {
            return _mapper.Map<List<ContaEntity>>(contaDTO);
        }

        public List<ContaDTO> GetMapperListEntityToDto(List<ContaEntity> contaEntity)
        {
            return _mapper.Map<List<ContaDTO>>(contaEntity);
        }

        //ContaTransacao
        public ContaTransacaoEntity GetMapperDtoToEntity(ContaTransacaoDTO contaTransacaoDTO)
        {
            return _mapper.Map<ContaTransacaoEntity>(contaTransacaoDTO);
        }

        public ContaTransacaoDTO GetMapperEntityToDto(ContaTransacaoEntity contaTransacaoEntity)
        {
            return _mapper.Map<ContaTransacaoDTO>(contaTransacaoEntity);
        }

        public List<ContaTransacaoEntity> GetMapperListDtoToEntity(List<ContaTransacaoDTO> contaTransacaoDTO)
        {
            return _mapper.Map<List<ContaTransacaoEntity>>(contaTransacaoDTO);
        }

        public List<ContaTransacaoDTO> GetMapperListEntityToDto(List<ContaTransacaoEntity> contaTransacaoEntity)
        {
            return _mapper.Map<List<ContaTransacaoDTO>>(contaTransacaoEntity);
        }


        //ContaMovimentoHistorico
        public ContaMovimentoHistoricoEntity GetMapperDtoToEntity(ContaMovimentoHistoricoDTO contaMovimentoHistoricoDTO)
        {
            return _mapper.Map<ContaMovimentoHistoricoEntity>(contaMovimentoHistoricoDTO);
        }

        public ContaMovimentoHistoricoDTO GetMapperEntityToDto(ContaMovimentoHistoricoEntity contaMovimentoHistoricoEntity)
        {
            return _mapper.Map<ContaMovimentoHistoricoDTO>(contaMovimentoHistoricoEntity);
        }

        public List<ContaMovimentoHistoricoEntity> GetMapperListDtoToEntity(List<ContaMovimentoHistoricoDTO> contaMovimentoHistoricoDTO)
        {
            return _mapper.Map<List<ContaMovimentoHistoricoEntity>>(contaMovimentoHistoricoDTO);
        }

        public List<ContaMovimentoHistoricoDTO> GetMapperListEntityToDto(List<ContaMovimentoHistoricoEntity> contaMovimentoHistoricoEntity)
        {
            return _mapper.Map<List<ContaMovimentoHistoricoDTO>>(contaMovimentoHistoricoEntity);
        }
    }
}
