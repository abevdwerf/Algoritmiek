using Xunit;
using Logic.Models;
using Logic.Enums;
using Type = Logic.Enums.Type;
using System.Collections.Generic;

namespace CircusTrein.Tests
{
    public class WagonTests
    {
        [Fact]
        public void When_Animal_Is_Added_Capacity_Is_Lower()
        {
            // Arrange
            Wagon wagon = new Wagon();
            Animal animal = new Animal(Type.Carnivore, Size.Small);
            int expectedCapacity = wagon.Capacity - (int)animal.Size;

            // Act
            wagon.AddAnimal(animal);

            // Assert  
            Assert.Equal(expectedCapacity, wagon.Capacity);
        }

        [Theory, MemberData(nameof(AnimalData))]
        public void Cannot_Add_Carnivore_With_Same_Or_Bigger_Size_Then_Herbivore(bool expected, Animal newAnimal)
        {
            // Arrange
            Wagon wagon = new Wagon();
            Animal animal = new Animal(Type.Herbivore, Size.Medium);

            // Act
            wagon.AddAnimal(animal);
            bool result = wagon.CanAddAnimal(newAnimal);

            // Assert  
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> AnimalData =>
        new List<object[]>
        {
            new object[] { false, new Animal(Type.Carnivore, Size.Medium) },
            new object[] { false, new Animal(Type.Carnivore, Size.Large) }
        };

        [Fact]
        public void Cannot_Add_Multiple_Carnivores()
        {
            // Arrange
            Wagon wagon = new Wagon();
            Animal animal = new Animal(Type.Carnivore, Size.Small);
            Animal secondAnimal = new Animal(Type.Carnivore, Size.Large);

            // Act
            wagon.AddAnimal(animal);
            bool result = wagon.CanAddAnimal(secondAnimal);

            // Assert  
            Assert.False(result);
        }

        [Fact]
        public void Cannot_Add_Animals_To_Full_Wagon()
        {
            // Arrange
            Wagon wagon = new Wagon();
            Animal animal = new Animal(Type.Herbivore, Size.Large);

            // Act
            wagon.AddAnimal(animal); // Capacity of 5
            wagon.AddAnimal(animal); // Capacity of 10
            bool result = wagon.CanAddAnimal(animal);

            // Assert  
            Assert.False(result);
        }
    }
}