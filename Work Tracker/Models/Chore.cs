using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug_Tracker.Models
{
    public class Chore : WorkItem
    {
        public string Description { get; set; }

        public Chore(string title, PriorityType priority, string description)
            : base(title, WorkItemType.Chore, priority)
        {
            Description = description;
        }
    }
}