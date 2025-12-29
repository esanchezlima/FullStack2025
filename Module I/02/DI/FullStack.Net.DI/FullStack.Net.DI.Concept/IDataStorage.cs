using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStack.Net.DI.Concept
{
    public interface IDataStorage
    {
        public int Count { get; }
        string Get(int id);
        List<string> List();
        void Insert(string data);
        void Update(int id, string data);
        void Delete(int id);
    }
}
