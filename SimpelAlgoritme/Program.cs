using System;

namespace SimpelAlgoritme
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            List<Product> productList = new List<Product>();

            productList.Add(new Product("Brood", 2.50));
            productList.Add(new Product("Appel", 0.50));
            productList.Add(new Product("Melk", 1.25));
            
            Order order = new Order(productList);

            Console.WriteLine("maximum price of order: " + order.GiveMaximumPrice());
            Console.WriteLine("average price of order: " + order.GiveAveragePrice());

            double minimumPrice = 1.25;
            Console.WriteLine("All products with mimimumprice of: " + minimumPrice);
            List<Product> allProducts = new List<Product>();
            allProducts = order.GetAllProducts(minimumPrice);
            foreach (Product p in allProducts)
            {
                Console.WriteLine(p.Name + " ");
            }

            order.SortProductByPrice();
            Console.Read();
        }
    }
}