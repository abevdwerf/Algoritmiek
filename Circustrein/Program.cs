using System;

namespace Circustrein
{
    internal class Program
    {
        public enum Type
        {
            Carnivore = 0,
            Herbivore = 1
        }

        public enum Size
        {
            Small = 1,
            Medium = 3,
            Large = 5
        }

        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            List<Wagon> wagons = new List<Wagon>();

            //create animals
            Animal tiger = new Animal("tiger", Type.Carnivore, Size.Medium);
            Animal lion = new Animal("lion", Type.Carnivore, Size.Small);
            Animal owl = new Animal("owl", Type.Carnivore, Size.Small);
            Animal snake = new Animal("snake", Type.Carnivore, Size.Small);

            Animal monkey = new Animal("monkey", Type.Herbivore, Size.Small);
            Animal cow = new Animal("cow", Type.Herbivore, Size.Large);
            Animal giraffe = new Animal("giraffe", Type.Herbivore, Size.Medium);
            Animal goat = new Animal("goat", Type.Herbivore, Size.Medium)

            //add animals to the list 
            animals.Add(tiger);
            animals.Add(lion);
            animals.Add(owl);
            animals.Add(snake);
            animals.Add(monkey);
            animals.Add(cow);
            animals.Add(giraffe);
            animals.Add(goat);

            //show all animals;
            Console.WriteLine("all animals:");
            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }

            //save all carnivore animals in to a list
            List<Animal> carnivoreAnimals = animals.Where(a => a.Type == Type.Carnivore).OrderBy(a => a.Size).ToList();
            //save all herbivore animals with the size medium or large in to a list
            List<Animal> herbivoreAnimals = animals.Where(a => a.Type == Type.Herbivore).Where(a => a.Size == Size.Medium || a.Size == Size.Large).OrderByDescending(a => a.Size).ToList();
            //save all herbivore animals with the size small in to a list
            List <Animal> smallHerbivoreAnimals = animals.Where(a => a.Type == Type.Herbivore).Where(a => a.Size == Size.Small).ToList();

            //add each carnivore animal to a new wagon
            foreach (Animal carnivoreAnimal in carnivoreAnimals)
            {
                Wagon wagon = new Wagon();
                wagon.AddAnimal(carnivoreAnimal);
                wagons.Add(wagon); 
            }

            for (int i = herbivoreAnimals.Count - 1; i >= 0; i--)
            {
                foreach (Wagon wagon in wagons)
                {
                    //all medium and Large herbivores add to wagons
                    if (wagon.AddAnimal(herbivoreAnimals[i]))
                    {
                        herbivoreAnimals.Remove(herbivoreAnimals[i]);
                        break;
                    }       
                }
            }

            //merge 2 lists together
            herbivoreAnimals.AddRange(smallHerbivoreAnimals);

            //if there are herbivore animals left then add them to a new wagon
            if (herbivoreAnimals.Count > 0)
            {
                Wagon wagon = new Wagon();

                foreach (Animal herbivoreAnimal in herbivoreAnimals)
                {
                    if (!wagon.AddAnimal(herbivoreAnimal))
                    {
                        //wagon reached max capacity
                        wagons.Add(wagon);

                        //create new wagon
                        Wagon newWagon = new Wagon();
                        newWagon.AddAnimal(herbivoreAnimal);
                        wagon = newWagon;
                    }
                }
                //add wagon to wagons list
                wagons.Add(wagon);
            }

            int count = 1;

            //show all wagons
            foreach (Wagon wagon in wagons)
            {
                Console.WriteLine("Wagon " + count + ":");
                Console.WriteLine("\t Points: " + wagon.Capacity);
                Console.WriteLine("\t Animals:");
                foreach (Animal animal in wagon.AnimalList)
                {
                    Console.WriteLine("\t\t " + animal.ToString());
                }
                count++;
            }
            
            Console.Read();
        }
    }
}