using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug_Tracker.Models
{
    public abstract class WorkItem
    {
        public string Title { get; set; }

        public DateTime DateCreated { get; set; }

        public WorkItemType WorkItemType { get; set; }

        public PriorityType PriorityType { get; set; }

        //public int Id {get;set;}

        // public bool isComplete { get; set; }

        // public DateTime DateCompleted { get; set; }

        public WorkItem(string title, WorkItemType workItemType, PriorityType priority)
        {
            Title = title;
            DateCreated = DateTime.Now;
            WorkItemType = workItemType;
            PriorityType = priority;
        }
    }

    /// <summary>
    /// Enters the priority (low, medium, high)
    /// </summary>
    public enum PriorityType
    {
        Low, //0
        Medium, //1
        High, //2
    }

    /// <summary>
    /// Enters the type of Work Item (bug or ReallyJustATask)
    /// </summary>
    public enum WorkItemType
    {
        Bug, //0
        Chore //1
    }
}