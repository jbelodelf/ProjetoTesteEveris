using JBD.ProjetoTesteEveris.Domain.DTOS;
using JBD.ProjetoTesteEveris.Domain.Entitys;
using System.Collections.Generic;

namespace JBD.ProjetoTesteEveris.Domain.Interfaces.Repository.Base
{
    public interface IMapperEntityAndDto
    {
        //Conta
        ContaEntity GetMapperDtoToEntity(ContaDTO empresaDTO);
        ContaDTO GetMapperEntityToDto(ContaEntity empresaEntity);
        List<ContaDTO> GetMapperListEntityToDto(List<ContaEntity> empresaEntity);
        List<ContaEntity> GetMapperListDtoToEntity(List<ContaDTO> empresaEntity);

        //ContaTransacao
        ContaTransacaoEntity GetMapperDtoToEntity(ContaTransacaoDTO contaTransacaoDTO);
        ContaTransacaoDTO GetMapperEntityToDto(ContaTransacaoEntity contaTransacaoEntity);
        List<ContaTransacaoDTO> GetMapperListEntityToDto(List<ContaTransacaoEntity> contaTransacaoEntity);
        List<ContaTransacaoEntity> GetMapperListDtoToEntity(List<ContaTransacaoDTO> contaTransacaoEntity);

        //ContaMovimentoHistorico
        ContaMovimentoHistoricoEntity GetMapperDtoToEntity(ContaMovimentoHistoricoDTO contaMovimentoHistoricoDTO);
        ContaMovimentoHistoricoDTO GetMapperEntityToDto(ContaMovimentoHistoricoEntity contaMovimentoHistoricoEntity);
        List<ContaMovimentoHistoricoDTO> GetMapperListEntityToDto(List<ContaMovimentoHistoricoEntity> contaMovimentoHistoricoEntity);
        List<ContaMovimentoHistoricoEntity> GetMapperListDtoToEntity(List<ContaMovimentoHistoricoDTO> contaMovimentoHistoricoEntity);
    }
}
