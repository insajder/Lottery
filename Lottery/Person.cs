using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Lottery
{
    class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public Person() { }

        public Person(string name, string lastName, string phone)
        {
            Name = name;
            LastName = lastName;
            Phone = phone;
        }

        public void PrintPerson()
        {
            WriteLine($"{Name} {LastName}, {Phone}");
        }

        public override string ToString()
        {
            return $"{Name} {LastName}, {Phone}";
        }
    }
}
