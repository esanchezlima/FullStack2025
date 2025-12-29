using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStack.Net.DI.MVC
{
    public class GuidServiceScoped : IGuidServiceScoped
    {
        private Guid _serviceGuid { get; }

        public GuidServiceScoped()
        {
            _serviceGuid = Guid.NewGuid();
        }
        public string GetGuid()
        {
            return _serviceGuid.ToString();
        }
    }
}
