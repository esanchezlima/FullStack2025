using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStack.Net.DI.Concept
{
    public class ServiceLocator
    {
        private IDictionary<Type, object> _storageContainer;

        public ServiceLocator()
        {
            _storageContainer = new Dictionary<Type, object>();

            _storageContainer.Add(typeof(DataStorageSQL), new DataStorageSQL());
            _storageContainer.Add(typeof(DataStorageOracle), new DataStorageOracle());
            _storageContainer.Add(typeof(DataStorageMongoDB), new DataStorageMongoDB());
        }
        public void Add<T>(object obj)
        {
            _storageContainer.Add(typeof(T), obj);
        }
        public T GetObject<T>()
        {
            try
            {
                return (T)_storageContainer[typeof(T)];
            }
            catch (KeyNotFoundException)
            {
                throw new ApplicationException("Origen de datos no registrado");
            }
        }
    }
}
