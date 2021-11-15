using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CM.ZooLab.ClassLibrary
{
    public abstract class Animal
    {
        public abstract int RequiredSpaceSqFt
        {
            get;
        }
        public abstract string[] FavoriteFood
        {
            get;
        }
        public abstract string[] NeededMedicine
        {
            get;
        }
        public abstract string[] FriendlyFor
        {
            get;
        }
        public List<FeedTime> FeedTimes
        {
            get;
            set;
        } = new List<FeedTime>();
        public List<int> FeedSchedule
        {
            get;
            protected set;
        }
        public bool IsSick
        {
            get;
            set;
        }
        public int ID
        {
            get;
            protected set;
        }

        public abstract bool IsFriendlyWith(Animal animal);

        public void Feed(List<Food> foods, FeedTime feedTime)
        {
            bool isFed = false;
            foreach (Food food in foods)
            {
                if (isFed) continue;
                if (FavoriteFood.Contains(food.GetType().Name))
                {
                    FeedTimes.Add(feedTime);
                    isFed = true;
                }
            }
        }
        public void AddFeedSchedule(List<int> hours)
        {
            FeedSchedule = hours;
        }
        public void Heal(List<Medicine> medicines)
        {
            bool isHealed = false;
            foreach (Medicine medicine in medicines)
            {
                if (isHealed) continue;
                if (NeededMedicine.Contains(medicine.GetType().Name))
                {
                    IsSick = false;
                    isHealed = true;
                }
            }
        }
    }
}
