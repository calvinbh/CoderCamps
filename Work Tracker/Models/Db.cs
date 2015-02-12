using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug_Tracker.Models
{
    public static class Db
    {
        public static List<WorkItem> WorkItems
        {
            get
            {
                return _workitems;
            }
            set
            {
                _workitems = value;
            }
        }

        private static List<WorkItem> _workitems = new List<WorkItem>()
        {
            new Bug("My application quits when I press alt-f4.",PriorityType.Medium,"Press Alt-F4"),
            new Chore("Finish this application - basic view features",PriorityType.Low,"Hurry up."),
            new Bug("Bug_Tracker.Models.Bug does not contain a constructor that takes 1 arguments", PriorityType.High,"Type anything, literally anything in VS")
        };
    }
}