using Type = Logic.Enums.Type; 

namespace Logic.Models
{
    public class Wagon
    {
        public Wagon()
        {
            AnimalList = new List<Animal>();
        }

        public List<Animal> AnimalList { get; set; }
        public int Capacity { get; private set; } = 10;

        public bool CanAddAnimal(Animal newAnimal)
        {
            int capacityWithNewAnimal = this.Capacity - (int)newAnimal.Size;

            //check capacity of the wagon
            if (capacityWithNewAnimal >= 0)
            {
                if (AnimalList.Count > 0)
                {
                    foreach (Animal animal in AnimalList)
                    {
                        return CanTheseAnimalsBeTogetherInThisWagon(newAnimal, animal);
                    }
                }
                return true;
                
            }
            return false;
        }

        private static bool CanTheseAnimalsBeTogetherInThisWagon(Animal newAnimal, Animal animal)
        {
            return newAnimal.Size <= animal.Size && animal.Type == Type.Carnivore || newAnimal.Size >= animal.Size && newAnimal.Type == Type.Carnivore;
        }

        public void AddAnimal(Animal animal)
        {
            if (!CanAddAnimal(animal))
            {
                throw new Exception();
            }

            AnimalList.Add(animal);
            Capacity -= (int)animal.Size;
        }
    }
}
