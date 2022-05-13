using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein
{
    public class Wagon
    {
        private const int maxCapacity = 10;

        public Wagon()
        {
            AnimalList = new List<Animal>();
        }

        public List<Animal> AnimalList { get; set; }
        public int Capacity { get;  private set; }

        public bool CanAddAnimal(Animal animal)
        {
            int capacityWithNewAnimal = (int)animal.Size + Capacity;
            bool canAddAnimal = false;

            //check capacity of the wagon
            if (this.Capacity < maxCapacity && capacityWithNewAnimal <= maxCapacity)
            {
                if (animal.Type == Logic.Enums.Type.Carnivore)
                {
                    //add carnivore only when AnimalList is empty
                    if (this.AnimalList.Count == 0)
                    {
                        canAddAnimal = true;
                    }
                }
                else if (AnimalList.Count > 0)
                {
                    // add herbivore to animallist with carnivore
                    if (AnimalList[0].Type == Logic.Enums.Type.Carnivore)
                    {
                        if (AnimalList[0].Size < animal.Size)
                        {
                            canAddAnimal = true;
                        }
                    }
                    else
                    {
                        canAddAnimal = true;
                    }
                }
                //add herbivore to empty animallist
                else
                {
                    canAddAnimal = true;
                }
            }
            return canAddAnimal;
        }

        public void AddAnimal(Animal animal)
        {
            if (!CanAddAnimal(animal))
            {
                throw new Exception();
            }

            AnimalList.Add(animal);
            Capacity += (int)animal.Size;
        }
    }
}
