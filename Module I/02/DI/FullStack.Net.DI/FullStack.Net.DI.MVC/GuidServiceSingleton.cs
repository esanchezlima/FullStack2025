using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStack.Net.DI.MVC
{
    public class GuidServiceSingleton : IGuidServiceSingleton
    {
        private Guid _serviceGuid { get; }

        public GuidServiceSingleton()
        {
            _serviceGuid = Guid.NewGuid();
        }
        public string GetGuid()
        {
            return _serviceGuid.ToString();
        }
    }
}
