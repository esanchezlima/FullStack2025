using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Infrastructure.Persistence.Helpers.DataMapping.PropertyMapping
{
    public interface IPropertyMappingService<TSource, TDestination>
    {
        bool ValidMappingExistsFor(string fields);

        Dictionary<string, PropertyMappingValue> GetPropertyMapping();
    }
}
