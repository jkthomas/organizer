using Organizer.Helpers.Commands;
using Organizer.Helpers.Parsers;
using Organizer.ViewModel.Deserializers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Organizer.ViewModel.AppViewModel
{
    //TODO: Create save command and implement
    public class OrganizerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        private ObservableCollection<ActivityViewModel> _activities = new ObservableCollection<ActivityViewModel>();
        public ICommand PrioritizeCommand { get; set; }
        public ICommand AddActivityCommand { get; set; }
        public ICommand DeleteActivityCommand { get; set; }

        public ObservableCollection<ActivityViewModel> Activities
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
            this.Activities = InitialDeserializer.Deserialize(JsonParser.Parse("activities.json"));
            this.PrioritizeCommand = new ParameterCommand(this.Prioritize);
            this.AddActivityCommand = new ParameterCommand(this.AddActivity);
            this.DeleteActivityCommand = new ParameterCommand(this.DeleteActivity);
        }

        public void Prioritize(object activity)
        {
            if (activity == null)
            {
                MessageBox.Show("No activity selected for prioritization...");
                return;
            }
            ActivityViewModel prioritizedActivity = activity as ActivityViewModel;
            prioritizedActivity = this.Activities.FirstOrDefault(activ => activ.Note == prioritizedActivity.Note);
            prioritizedActivity.Priority += 1;
            if(prioritizedActivity.Priority > 3)
            {
                prioritizedActivity.Priority = 1;
            }
        }

        public void AddActivity(object note)
        {
            if (note == null)
            {
                MessageBox.Show("Activity note field is empty...");
                return;
            }

            if(this.Activities.Any(activ => activ.Note == note.ToString()))
            {
                MessageBox.Show("Activity with exactly same note already exists...");
                return;
            }
            this.Activities.Add(new ActivityViewModel(note.ToString(), 1));
        }

        public void DeleteActivity(object activity)
        {
            if (activity == null)
            {
                MessageBox.Show("You need to specify activity for deletion...");
                return;
            }
            ActivityViewModel activ = activity as ActivityViewModel;
            this.Activities.Remove(activ);
        }
    }
}
