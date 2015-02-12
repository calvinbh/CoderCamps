using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug_Tracker.Models
{
    public class Bug : WorkItem
    {
        public string StepsToReproduce { get; set; }

        public Bug(string title, PriorityType priority, string stepsToReproduce)
            : base(title, WorkItemType.Bug, priority)
        {
            StepsToReproduce = stepsToReproduce;
        }
    }
}