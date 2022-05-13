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
        private Type type;
        private Size size;

        public Animal(Type type, Size size)
        {
            this.type = type;
            this.size = size;
        }

        public Type Type { get => type; }
        public Size Size { get => size; }

        public override string ToString()
        {
            return $"Type: {Type}, Size: {Size}";
        }
    }
}
