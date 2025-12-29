using Library.Service.Domain.Authors.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Service.Application.Dtos;
using Library.Service.Infrastructure.Persistence.Helpers.DataMapping.PropertyMapping;

namespace Library.Service.Infrastructure.Persistence.Helpers.DataMapping.ModelMapping
{
    public interface IAuthorPropertyMappingService : IPropertyMappingService<AuthorDto, Author>
    {

    }
}
