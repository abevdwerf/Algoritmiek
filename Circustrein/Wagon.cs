using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein
{
    internal class Wagon
    {
        private const int maxCapacity = 10;

        public Wagon()
        {
            AnimalList = new List<Animal>();
        }

        public List<Animal> AnimalList { get; set; }
        public int Capacity { get;  private set; }

        public bool AddAnimal(Animal animal)
        {
            int result = (int)animal.Size + Capacity;
            bool animalAdded = false;

            //check capacity of the wagon
            if (this.Capacity < maxCapacity && result <= maxCapacity)
            {
                if (animal.Type == Program.Type.Carnivore)
                {
                    //add carnivore only when AnimalList is empty
                    if (this.AnimalList.Count == 0)
                    {
                        AnimalList.Add(animal);
                        Capacity += (int)animal.Size;
                        animalAdded = true;
                    }
                }
                else if (AnimalList.Count > 0)
                {
                    // add herbivore to animallist with carnivore
                    if (AnimalList[0].Type == Program.Type.Carnivore)
                    {
                        if (AnimalList[0].Size < animal.Size)
                        {
                            AnimalList.Add(animal);
                            Capacity += (int)animal.Size;
                            animalAdded = true;
                        }
                    }
                    else
                    {
                        AnimalList.Add(animal);
                        Capacity += (int)animal.Size;
                        animalAdded = true;
                    }
                }
                //add herbivore to empty animallist
                else 
                {
                    AnimalList.Add(animal);
                    Capacity += (int)animal.Size;
                    animalAdded = true;
                }
            }
            return animalAdded;
        }
    }
}
