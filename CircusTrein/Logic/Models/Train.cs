using Logic.Enums;
using Type = Logic.Enums.Type;

namespace Circustrein
{
    public class Train
    {
        List<Animal> carnivoreAnimals;
        List<Animal> herbivoreAnimals;
        List<Animal> smallHerbivoreAnimals;

        public Train()
        {
            this.Animals = new List<Animal>();
            this.Wagons = new List<Wagon>();
        }

        public List<Animal> Animals { get; set; }
        public List<Wagon> Wagons { get; set; }

        public void AddAnimal(Animal animal)
        {
            Animals.Add(animal);
            //add animal to wagon
        }

        private void SortAnimals()
        {
            //save all carnivore animals in to a list
            carnivoreAnimals = Animals.Where(a => a.Type == Type.Carnivore).OrderBy(a => a.Size).ToList();
            //save all herbivore animals with the size medium or large in to a list
            herbivoreAnimals = Animals.Where(a => a.Type == Type.Herbivore).Where(a => a.Size == Size.Medium || a.Size == Size.Large).OrderByDescending(a => a.Size).ToList();
            //save all herbivore animals with the size small in to a list
            smallHerbivoreAnimals = Animals.Where(a => a.Type == Type.Herbivore).Where(a => a.Size == Size.Small).ToList();
        }

        private void FillWagons()
        {
            SortAnimals();

            //add each carnivore animal to a new wagon
            foreach (Animal carnivoreAnimal in carnivoreAnimals)
            {
                Wagon wagon = new Wagon();
                wagon.AddAnimal(carnivoreAnimal);
                Wagons.Add(wagon);
            }

            for (int i = herbivoreAnimals.Count - 1; i >= 0; i--)
            {
                foreach (Wagon wagon in Wagons)
                {
                    //all medium and Large herbivores add to wagons
                    if (wagon.CanAddAnimal(herbivoreAnimals[i]))
                    {
                        wagon.AddAnimal(herbivoreAnimals[i]);
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
                    if (wagon.CanAddAnimal(herbivoreAnimal))
                    {
                        wagon.AddAnimal(herbivoreAnimal);
                    }
                    else
                    {
                        //add existing wagon to list
                        Wagons.Add(wagon);

                        //create new wagon
                        Wagon newWagon = new Wagon();
                        wagon = newWagon;

                        wagon.AddAnimal(herbivoreAnimal);
                    }
                }
                //add wagon to wagons list
                Wagons.Add(wagon);
            }
        }

        public List<Wagon> GetAllWagons()
        {
            FillWagons();
            return Wagons;
        }
    }
}
