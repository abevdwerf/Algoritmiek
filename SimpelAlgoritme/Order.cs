using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpelAlgoritme
{
    internal class Order
    {
        public Order(List<Product> productList)
        {
            this.ProductList = productList;
        }

        public List<Product> ProductList { get; set; }
        
        //testen...
        public Double GiveMaximumPrice()
        {
            if (ProductList.Count == 0)
            {
                throw new InvalidOperationException("Empty list");
            }

            double maxPrice = 0;
            foreach (Product product in ProductList)
            {
                if (product.Price > maxPrice)
                {
                    maxPrice = product.Price;
                }
            }
            return maxPrice;
        }

        public Double GiveAveragePrice()
        {
            if (ProductList.Count == 0)
            {
                throw new InvalidOperationException("Empty list");
            }

            double price = 0;
            foreach (Product product in ProductList)
            {
                price += product.Price;
            }

            price /= ProductList.Count;
            price = Math.Round(price, 2);
            return price;
        }

        //public List<Product> GetAllProducts(Double minimumPrice)
        //{

        //}

        public void SortProductByPrice()
        {
            if (ProductList.Count == 0)
            {
                throw new InvalidOperationException("Empty list");
            }

            List<double> priceList = new List<double>();


            foreach (Product product in ProductList)
            {
                priceList.Add(product.Price);
            }

            double temporary;

            for (int j = 0; j <= priceList.Count - 2; j++)
            {
                for (int i = 0; i <= priceList.Count - 2; i++)
                {
                    if (priceList[i] > priceList[i + 1])
                    {
                        temporary = priceList[i + 1];
                        priceList[i + 1] = priceList[i];
                        priceList[i] = temporary;
                    }
                }
            }

            Console.WriteLine("Sorted:");
            foreach (double p in priceList)
                Console.WriteLine(p + " ");
        }
    }
}
