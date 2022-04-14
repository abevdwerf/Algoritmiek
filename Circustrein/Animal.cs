using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein
{
    internal class Animal
    {
        private string name;
        private Program.Type type;
        private Program.Size size;

        public Animal(string name, Program.Type type, Program.Size size)
        {
            this.name = name;
            this.type = type;
            this.size = size;
        }

        public string Name { get => name;}
        public Program.Type Type { get => type; }
        public Program.Size Size { get => size; }

        public override string ToString()
        {
            return $"Name: {Name}, Type: {Type}, Size: {Size}";
        }
    }
}
