using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CM.ZooLab.ClassLibrary
{
    public class VeterinarianTests
    {
        Veterinarian veterinarian = new Veterinarian("name", "surname", new List<string> { new Elephant().GetType().Name });
        [Fact]
        public void ShouldBeAbleToCreateZooKeeperObject()
        {

            Assert.Equal("name", veterinarian.FirstName);
            Assert.Equal("surname", veterinarian.LastName);
            Assert.NotNull(veterinarian.AnimalExperiences);
        }

        [Fact]
        public void ShouldBeAbleToAddAnimalExperience()
        {
            Lion lion = new Lion();
            veterinarian.AddAnimalExperience(lion);
            Assert.Contains(lion.GetType().Name, veterinarian.AnimalExperiences);
        }

        [Fact]
        public void ShouldBeAbleToReturnCorrectResultHasAnimalExperience()
        {
            Lion lion = new Lion();
            veterinarian.AddAnimalExperience(lion);
            Assert.True(veterinarian.HasAnimalExperience(new Lion()));
        }
        [Fact]
        public void ShouldBeAbleToReturnCorrectResultHasNotAnimalExperience()
        {
            Lion lion = new Lion();
            veterinarian.AddAnimalExperience(lion);
            Assert.Throws<NoNeededExperienceException>(() => veterinarian.HasAnimalExperience(new Turtle()));
        }

        //Здесь и далее надо подставлять подходящие часы относительно своего реального времени
        [Fact]
        public void ShouldBeAbleToHealAnimalIfSick()
        {
            Elephant elephant = new Elephant();
            elephant.IsSick = true;
            Assert.True(veterinarian.HealAnimal(elephant));
        }
        [Fact]
        public void ShouldNotBeAbleToHealAnimalIfNotSick()
        {
            Elephant elephant = new Elephant();
            elephant.IsSick = false;
            Assert.False(veterinarian.HealAnimal(elephant));
        }
    }
}
