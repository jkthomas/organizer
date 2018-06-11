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
    public class OrganizerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        private ObservableCollection<ActivityViewModel> _activities = new ObservableCollection<ActivityViewModel>();
        public ICommand PrioritizeCommand { get; set; }
        public ICommand AddActivityCommand { get; set; }
        public ICommand DeleteActivityCommand { get; set; }
        public ICommand SaveActivitiesCommand { get; set; }

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
            try
            {
                this.Activities = InitialDeserializer.Deserialize(JsonParser.Parse("activities.json"));
            }
            catch (Exception e)
            {
                MessageBox.Show("There was an error when opening activities file: " + e.Message);
            }
            this.PrioritizeCommand = new ParameterCommand(this.Prioritize);
            this.AddActivityCommand = new ParameterCommand(this.AddActivity);
            this.DeleteActivityCommand = new ParameterCommand(this.DeleteActivity);
            this.SaveActivitiesCommand = new RelayCommand(this.SaveActivities);
        }

        public void Prioritize(object activity)
        {
            try
            {
                if (activity == null)
                {
                    MessageBox.Show("No activity selected for prioritization...");
                    return;
                }
                ActivityViewModel prioritizedActivity = activity as ActivityViewModel;
                prioritizedActivity = this.Activities.FirstOrDefault(activ => activ.Note == prioritizedActivity.Note);
                prioritizedActivity.Priority += 1;
                if (prioritizedActivity.Priority > 3)
                {
                    prioritizedActivity.Priority = 1;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("General error occured when prioritizing: " + e.Message);
            }
        }

        public void AddActivity(object note)
        {
            try
            {
                if (note == null)
                {
                    MessageBox.Show("Activity note field is empty...");
                    return;
                }

                if (this.Activities.Any(activ => activ.Note == note.ToString()))
                {
                    MessageBox.Show("Activity with exactly same note already exists...");
                    return;
                }
                this.Activities.Add(new ActivityViewModel(note.ToString(), 1));
            }
            catch (Exception e)
            {
                MessageBox.Show("General error occured when adding acivity: " + e.Message);
            }
        }

        public void DeleteActivity(object activity)
        {
            try
            {
                if (activity == null)
                {
                    MessageBox.Show("You need to specify activity for deletion...");
                    return;
                }
                ActivityViewModel activ = activity as ActivityViewModel;
                this.Activities.Remove(activ);
            }
            catch (Exception e)
            {
                MessageBox.Show("General error occured on activity deletion: " + e.Message);
            }
        }

        public void SaveActivities()
        {
            try
            {
                if (JsonParser.SaveToJson(SaveSerializer.Serialize(this.Activities), "activities.json"))
                {
                    MessageBox.Show("Activities saved successfuly");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Saving problem occured: " + e.Message);
            }
        }
    }
}
