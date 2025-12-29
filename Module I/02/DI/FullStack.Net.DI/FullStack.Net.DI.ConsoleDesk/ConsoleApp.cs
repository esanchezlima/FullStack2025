using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStack.Net.DI.ConsoleDesk
{
    public class ConsoleApp
    {
        private IPerson _person;
        public ConsoleApp(IPerson person)
        {
            _person = person;
        }
        public async Task RunAsync()
        {
            Console.WriteLine($"Name: {_person.Name}");
            Console.WriteLine($"Name: {_person.Age}");
        }
    }
}
