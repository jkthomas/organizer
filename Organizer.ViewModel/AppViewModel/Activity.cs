using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.ViewModel.AppViewModel
{
    public class Activity
    {
        public string Note { get; set; }
        public bool IsPrioritized { get; set; }
        public Activity(string note, bool prioritized)
        {
            this.Note = note;
            this.IsPrioritized = prioritized;
        }

        public override string ToString()
        {
            return this.Note;
        }
    }
}
