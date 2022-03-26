using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein
{
    internal class Animal
    {
        enum Type
        {
            Carnivore,
            Herbivore
        }

        enum Size
        {
            Small = 1,
            Medium = 3,
            Large = 5
        }

        private Type type;
        private Size size;

        public Animal(Type type, Size size)
        {
            this.type = type;
            this.size = size;
        }
    }
}
