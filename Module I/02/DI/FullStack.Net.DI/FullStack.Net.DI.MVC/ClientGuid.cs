using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStack.Net.DI.MVC
{
    public class ClientGuid
    {
        private readonly IGuidServiceTransient _guidServiceTransient;
        private readonly IGuidServiceScoped _guidServiceScoped;
        private readonly IGuidServiceSingleton _guidServiceSingleton;

        public ClientGuid(
            IGuidServiceTransient guidServiceTransient,
            IGuidServiceScoped guidServiceScoped,
            IGuidServiceSingleton guidServiceSingleton
        )
        {
            _guidServiceTransient = guidServiceTransient;
            _guidServiceScoped = guidServiceScoped;
            _guidServiceSingleton = guidServiceSingleton;            
        }

        public string GetGuidTransient() {
            return _guidServiceTransient.GetGuid();
        }
        public string GetGuidScoped()
        {
            return _guidServiceScoped.GetGuid();
        }
        public string GetGuidSingleton()
        {
            return _guidServiceSingleton.GetGuid();
        }
    }
}
