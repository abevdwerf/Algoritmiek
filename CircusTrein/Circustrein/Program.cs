using Logic.Enums;
using Type = Logic.Enums.Type;
using Logic.Models;

namespace Circustrein
{
    public class Program
    {
        static void Main(string[] args)
        {
            Circus circus = new Circus();
            Schedule schedule = new Schedule();
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
                            circus.AddAnimal(new Animal(Type.Herbivore, Size.Small));
                            break;
                        }
                    case "hm":
                        {
                            circus.AddAnimal(new Animal(Type.Herbivore, Size.Medium));
                            break;
                        }
                    case "hl":
                        {
                            circus.AddAnimal(new Animal(Type.Herbivore, Size.Large));
                            break;
                        }
                    case "cs":
                        {
                            circus.AddAnimal(new Animal(Type.Carnivore, Size.Small));
                            break;
                        }
                    case "cm":
                        {
                            circus.AddAnimal(new Animal(Type.Carnivore, Size.Medium));
                            break;
                        }
                    case "cl":
                        {
                            circus.AddAnimal(new Animal(Type.Carnivore, Size.Large));
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
            foreach (Wagon wagon in schedule.GetSortedWagons(circus.Animals))
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