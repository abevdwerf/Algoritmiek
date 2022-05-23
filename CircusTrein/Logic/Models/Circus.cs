namespace Logic.Models
{
    public class Circus
    {
        private List<Animal> animals;

        public Circus()
        {
            animals = new List<Animal>();
        }

        public IEnumerable<Animal> Animals { get { return animals; } }

        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
        }
    }
}
