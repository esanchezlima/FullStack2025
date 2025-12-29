using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStack.Net.DI.Concept
{
    public class ClientDISetter
    {
        private IDataStorage _dataStorage;
        public IDataStorage DataStorage
        {
            set { _dataStorage = value; }
        }


        public int Count { get { return _dataStorage.Count; } }
        public string Get(int id)
        {
            return _dataStorage.Get(id);
        }
        public List<string> List()
        {
            return _dataStorage.List();
        }
        public void Insert(string data)
        {
            _dataStorage.Insert(data);
        }
        public void Update(int id, string data)
        {
            _dataStorage.Update(id, data);
        }
        public void Delete(int id)
        {
            _dataStorage.Delete(id);
        }
    }
}
