using System;

namespace SimpelAlgoritme
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product brood = new Product("Brood", 2.50);
            Product appel = new Product("Appel", 0.50);
            Product melk = new Product("Melk", 1.25);
            
            List<Product> productList = new List<Product>();
            productList.Add(brood);
            productList.Add(appel);
            productList.Add(melk);
            Order order = new Order(productList);

            Console.WriteLine("maximum price of order: " + order.GiveMaximumPrice());
            Console.WriteLine("average price of order: " + order.GiveAveragePrice());
            //order.GetAllProducts();
            order.SortProductByPrice();
            Console.Read();
        }
    }
}