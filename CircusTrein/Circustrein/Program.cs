using System;
using Logic.Enums;
using Type = Logic.Enums.Type;

namespace Circustrein
{
    public class Program
    {
        static void Main(string[] args)
        {
            Train train = new Train();
            string userInput = "";
            int count = 1;

            while (userInput != "2")
            {
                Console.WriteLine("Enter the type and size of the animal (by entering the first letter of the type and the size.)");
                Console.WriteLine("Herbivore: hs, hm, hl. Carnivore: cs, cm, cl");

                switch (Console.ReadLine())
                {
                    case "hs":
                        {
                            train.AddAnimal(new Animal(Type.Herbivore, Size.Small));
                            break;
                        }
                    case "hm":
                        {
                            train.AddAnimal(new Animal(Type.Herbivore, Size.Medium));
                            break;
                        }
                    case "hl":
                        {
                            train.AddAnimal(new Animal(Type.Herbivore, Size.Large));
                            break;
                        }
                    case "cs":
                        {
                            train.AddAnimal(new Animal(Type.Carnivore, Size.Small));
                            break;
                        }
                    case "cm":
                        {
                            train.AddAnimal(new Animal(Type.Carnivore, Size.Medium));
                            break;
                        }
                    case "cl":
                        {
                            train.AddAnimal(new Animal(Type.Carnivore, Size.Large));
                            break;
                        }
                    default:
                            Console.WriteLine("Wrong action!! try again");
                        break;
                }

                Console.WriteLine("Enter 1 to add another animal");
                Console.WriteLine("Enter 2 to show all wagons");
                userInput = Console.ReadLine();
            }

            //show all wagons
            foreach (Wagon wagon in train.GetAllWagons())
            {
                Console.WriteLine("Wagon " + count + ":");
                Console.WriteLine("\t Capacity: " + wagon.Capacity);
                Console.WriteLine("\t Animals:");
                foreach (Animal animal in wagon.AnimalList)
                {
                    Console.WriteLine("\t\t " + animal.ToString());
                }
                count++;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}