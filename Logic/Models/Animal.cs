using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Enums;
using Type = Logic.Enums.Type;

namespace Circustrein
{
    public class Animal
    {
        private string name;
        private Type type;
        private Size size;

        public Animal(string name, Type type, Size size)
        {
            this.name = name;
            this.type = type;
            this.size = size;
        }

        public string Name { get => name;}
        public Type Type { get => type; }
        public Size Size { get => size; }

        public override string ToString()
        {
            return $"Name: {Name}, Type: {Type}, Size: {Size}";
        }
    }
}
