using Library.Service.Application.Dtos;
using Library.Service.Domain.Authors.Entities;
using Library.Service.Infrastructure.Persistence.Helpers.DataMapping.PropertyMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Infrastructure.Persistence.Helpers.DataMapping.ModelMapping
{
    public class AuthorPropertyMappingService : PropertyMappingService<AuthorDto, Author>, IAuthorPropertyMappingService
    {
        private static Dictionary<string, PropertyMappingValue> _authorPropertyMapping =
           new Dictionary<string, PropertyMappingValue>(StringComparer.OrdinalIgnoreCase)
           {
               { "Id", new PropertyMappingValue(new List<string>() { "AuthorId" } ) },
               { "Genre", new PropertyMappingValue(new List<string>() { "Genre" } )},
               { "Age", new PropertyMappingValue(new List<string>() { "DateOfBirth" } , true) },
               { "Name", new PropertyMappingValue(new List<string>() { "FirstName", "LastName" }) }
           };
        public AuthorPropertyMappingService() : base(_authorPropertyMapping)
        {

        }
    }
}
