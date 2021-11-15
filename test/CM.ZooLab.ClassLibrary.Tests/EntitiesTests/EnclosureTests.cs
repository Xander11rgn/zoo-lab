using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CM.ZooLab.ClassLibrary
{
    public class EnclosureTests
    {
        Zoo zoo;
        public EnclosureTests()
        {
            zoo = new Zoo("test");
            zoo.AddEnclosure("test", 100);
            zoo.Enclosures[0].Animals = new List<Animal>();
        }

        [Fact]
        public void ShouldBeAbleToCreateEnclosureTempObject()
        {
            Enclosure enclosure = new Enclosure();
            Assert.NotNull(enclosure);
        }

        [Fact]
        public void ShouldBeAbleToCreateEnclosureObject()
        {
            Assert.NotEmpty(zoo.Enclosures);
            Assert.Equal("test", zoo.Enclosures[0].Name);
            Assert.Equal(100, zoo.Enclosures[0].SquareFeet);
            Assert.Equal(zoo, zoo.Enclosures[0].ParentZoo);
        }

        [Fact]
        public void ShouldBeAbleToAddAnimalCorrect()
        {
            zoo.Enclosures[0].AddAnimals(new Snake());
            zoo.Enclosures[0].AddAnimals(new Snake());
            Assert.NotEmpty(zoo.Enclosures[0].Animals);
        }
        [Fact]
        public void ShouldNotBeAbleToAddAnimalNoAvailableSpace()
        {
            Assert.Throws<NoAvailableSpaceException>(() => zoo.Enclosures[0].AddAnimals(new Lion()));
        }
        [Fact]
        public void ShouldNotBeAbleToAddAnimalNotFriendlyAnimal()
        {
            zoo.Enclosures[0].AddAnimals(new Snake());
            Assert.Throws<NotFriendlyAnimalException>(() => zoo.Enclosures[0].AddAnimals(new Turtle()));
        }
    }
}
