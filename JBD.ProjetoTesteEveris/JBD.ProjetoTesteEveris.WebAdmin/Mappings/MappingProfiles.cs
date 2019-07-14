using AutoMapper;
using JBD.ProjetoTesteEveris.Domain.DTOS;
using JBD.ProjetoTesteEveris.WebAdmin.Models;

namespace JBD.ProjetoTesteEveris.WebAdmin.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ContaTransacaoDTO, ContaTransacaoViewModel>().ReverseMap();
        }
    }
}
