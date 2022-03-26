using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpelAlgoritme
{
    internal class Product
    {
        public string Name { get; private set; }
        public Double Price { get; private set; }

        public Product(string name, Double price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
}
