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
                        //return false when new animal size is lower or equal then existing carnivore animal
                        //return false when new animal size is bigger or equal then existing animal where the newanimal is type of carnivore
                        if (newAnimal.Size <= animal.Size && animal.Type == Type.Carnivore || newAnimal.Size >= animal.Size && newAnimal.Type == Type.Carnivore)
                        {
                            return false;
                        }
                    }
                }
                return true;
                
            }
            return false;
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
