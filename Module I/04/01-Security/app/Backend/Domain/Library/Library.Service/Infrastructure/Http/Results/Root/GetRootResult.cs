using Library.Service.Infrastructure.Http.Helpers.LinksBuilders.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Service.Infrastructure.Http.Results.Root
{
    public class GetRootResult
    {
        public List<LinkDto> LinkedResources { get; set; }
    }
}
