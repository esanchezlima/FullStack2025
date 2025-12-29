using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStack.Net.DI.MVC
{
    public class GuidServiceTransient : IGuidServiceTransient
    {
        private Guid _serviceGuid { get; }

        public GuidServiceTransient()
        {
            _serviceGuid = Guid.NewGuid();
        }
        public string GetGuid()
        {
            return _serviceGuid.ToString();
        }
    }
}
