using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStack.Net.DI.Concept
{
    public class DataStorageMongoDB : IDataStorage
    {
        private Dictionary<int, string> _db;
        private int _count;
        public int Count { get { return _count; } }

        public DataStorageMongoDB()
        {
            _count = 0;
            _db = new Dictionary<int, string>();
            Insert("Erick Arostegui Cunza (MongoDB)");
            Insert("Bill Gates (MongoDB)");
            Insert("Steve Jobs (MongoDB)");
            Insert("Jeff Bezos (MongoDB)");
        }

        public string Get(int id)
        {
            return _db[id];
        }
        public List<string> List()
        {
            return _db.Select(s => s.Value).ToList();
        }
        public void Insert(string data)
        {
            _count++;
            _db.Add(_count, data);
        }
        public void Update(int id, string data)
        {
            _db[id] = data;
        }
        public void Delete(int id)
        {
            _db.Remove(id);
        }
    }
}
