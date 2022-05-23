namespace Logic.Models
{
    public class Train
    {
        public Train()
        {
            this.Wagons = new List<Wagon>();
        }

        public List<Wagon> Wagons { get; set; }

        private void FillWagons(IEnumerable<Animal> animals)
        {
            foreach (Animal animal in animals)
            {
                if (Wagons.Count == 0)
                {
                    Wagon firstWagon = new Wagon();
                    AddWagon(firstWagon);
                }

                foreach (Wagon wagon in Wagons.ToList())
                {
                    if (wagon.CanAddAnimal(animal))
                    {
                        wagon.AddAnimal(animal);
                        break;
                    }
                    else
                    {
                        Wagon newWagon = new Wagon();
                        newWagon.AddAnimal(animal);
                        AddWagon(newWagon);
                    }
                }
            }
        }

        private void AddWagon(Wagon wagon)
        {
            Wagons.Add(wagon);
        }

        public List<Wagon> GetAllWagons(IEnumerable<Animal> animals)
        {
            FillWagons(animals);
            return Wagons;
        }
    }
}
