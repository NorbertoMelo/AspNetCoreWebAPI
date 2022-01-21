using AutoMapper;
using SmartSchool.WEBAPI.Models;
using SmartSchool.WEBAPI.Helpers;
using SmartSchool.WEBAPI.V2.Dtos;

namespace SmartSchool.WEBAPI.V2
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            // Mapeamento para Aluno
            CreateMap<Aluno, AlunoDto>()
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => $"{src.Nome} {src.SobreNome}")
                )
                .ForMember(
                    dest => dest.Idade,
                    opt => opt.MapFrom(src => src.DataNasc.GetCurrentAge())
                );
            CreateMap<AlunoDto,Aluno>();
            CreateMap<Aluno,AlunoRegistrarDto>().ReverseMap();
            
        }
    }
}