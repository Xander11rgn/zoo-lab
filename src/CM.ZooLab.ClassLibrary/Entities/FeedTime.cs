using System;
using System.Collections.Generic;
using System.Text;

namespace CM.ZooLab.ClassLibrary
{
    public class FeedTime
    {
        public DateTime TimeToFeed { get; set; }
        public ZooKeeper FedByZooKeeper { get; set; }

        public FeedTime(DateTime timeToFeed, ZooKeeper fedByZooKeeper)
        {
            TimeToFeed = timeToFeed;
            FedByZooKeeper = fedByZooKeeper;
        }
    }
}
