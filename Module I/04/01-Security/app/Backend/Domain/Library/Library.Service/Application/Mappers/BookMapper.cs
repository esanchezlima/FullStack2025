using AutoMapper;
using Library.Service.Domain.Authors.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Service.Application.Dtos;

namespace Library.Service.Application.Mappers
{
    public class BookMapper : Profile
    {
        public BookMapper()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookForCreationDto, Book>();
            CreateMap<BookForUpdateDto, Book>();
            CreateMap<Book, BookForUpdateDto>();
        }
    }
}
