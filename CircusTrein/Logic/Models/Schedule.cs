namespace Logic.Models
{
    public class Schedule
    {
        public IEnumerable<Wagon> GetSortedWagons(IEnumerable<Animal> animals)
        {
            Train train = new Train();
            return train.GetAllWagons(animals);
        }
    }
}
