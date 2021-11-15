using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CM.ZooLab.ClassLibrary
{
    public class SnakeTests
    {
        Zoo zoo;
        Snake snake;
        public SnakeTests()
        {
            zoo = new Zoo("test");
            zoo.AddEnclosure("zoo", 10000);
            snake = new Snake(new List<int> { 6, 18 }, zoo);
            snake.FeedTimes = new List<FeedTime>();
        }

        [Fact]
        public void ShouldBeAbleToCreateSnakeObject()
        {
            Assert.Equal("Snake", snake.GetType().Name);
            Assert.Equal(2, snake.RequiredSpaceSqFt);
            Assert.Equal(new string[] { "Grass", "Vegetable", "Meat" }, snake.FavoriteFood);
            Assert.Equal(new string[] { "AntiDepression" }, snake.NeededMedicine);
            Assert.Equal(new string[] { "Snake" }, snake.FriendlyFor);
        }

        [Fact]
        public void ShouldBeAbleToReturnCorrectResultForUnfriendlyAnimal()
        {
            Assert.False(snake.IsFriendlyWith(new Lion()));
        }

        [Fact]
        public void ShouldBeAbleToReturnCorrectResultForFriendlyAnimal()
        {
            Assert.True(snake.IsFriendlyWith(new Snake()));
        }
    }
}
