using AutoMapper;
using SmartSchool.WEBAPI.Models;
using SmartSchool.WEBAPI.Helpers;
using SmartSchool.WEBAPI.V1.Dtos;

namespace SmartSchool.WEBAPI.V1
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

            // Mapeamento para Professor
            CreateMap<Professor, ProfessorDto>()
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => $"{src.Nome} {src.SobreNome}")
                );
            CreateMap<ProfessorDto,Professor>();
            CreateMap<Professor,ProfessorRegistrarDto>().ReverseMap();
        }
    }
}