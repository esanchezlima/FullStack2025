using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStack.Net.DI.ConsoleDesk
{
    public class Person : IPerson
    {
        public Person()
        {
            Name = "Erick Aróstegui";
            Age = 40;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
