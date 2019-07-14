using AutoMapper;
using JBD.ProjetoTesteEveris.Domain.DTOS;
using JBD.ProjetoTesteEveris.Domain.Entitys;

namespace JBD.ProjetoTesteEveris.CrossCutting.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ContaEntity, ContaDTO>().ReverseMap();
            CreateMap<ContaTransacaoEntity, ContaTransacaoDTO>().ReverseMap();
            CreateMap<ContaMovimentoHistoricoEntity, ContaMovimentoHistoricoDTO>().ReverseMap();
        }
    }
}
