using Organizer.Helpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Organizer.ViewModel.AppViewModel
{
    public class OrganizerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Activity> _activities = new ObservableCollection<Activity>();
        public ICommand PrioritizeCommand { get; set; }
        public ICommand AddActivityCommand { get; set; }
        public ICommand DeleteActivityCommand { get; set; }

        public ObservableCollection<Activity> Activities
        {
            get { return this._activities; }
            set
            {
                if (this._activities == value)
                    return;

                this._activities = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Activities)));
            }
        }
        public OrganizerViewModel()
        {
            this.PrioritizeCommand = new ParameterCommand(this.Prioritize);
            this.AddActivityCommand = new ParameterCommand(this.AddActivity);
            this.DeleteActivityCommand = new ParameterCommand(this.DeleteActivity);
            this.Activities.Add(new Activity("Hello", true));
            this.Activities.Add(new Activity("there", false));
        }

        public void Prioritize(object activity)
        {
            if (activity.Equals(null))
            {
                //MessageBox
                return;
            }
            Activity prioritizedActivity = activity as Activity;
            prioritizedActivity = this.Activities.FirstOrDefault(activ => activ.Note == prioritizedActivity.Note);
            prioritizedActivity.IsPrioritized = true;
        }

        public void AddActivity(object note)
        {
            if (note.Equals(null))
            {
                //MessageBox
                return;
            }

            if(this.Activities.Any(activ => activ.Note == note.ToString()))
            {
                //MessageBox
                return;
            }
            this.Activities.Add(new Activity(note.ToString(), false));
        }

        public void DeleteActivity(object activity)
        {
            if (activity.Equals(null))
            {
                //MessageBox
                return;
            }
            Activity activ = activity as Activity;
            this.Activities.Remove(activ);
        }
    }
}
