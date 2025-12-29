using AutoMapper;
using Library.Service.Domain.Authors.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Service.Application.Dtos;
using Library.Service.Infrastructure.Persistence.Extensions;

namespace Library.Service.Application.Mappers
{
    public class AuthorMapper : Profile
    {
        public AuthorMapper()
        {
            CreateMap<Author, AuthorDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge(src.DateOfDeath)));

            CreateMap<AuthorForCreationDto, Author>();
            CreateMap<AuthorForCreationWithDateOfDeathDto, Author>();
            CreateMap<AuthorForUpdateDto, Author>();
            CreateMap<Author, AuthorForUpdateDto>();
        }
    }
}
