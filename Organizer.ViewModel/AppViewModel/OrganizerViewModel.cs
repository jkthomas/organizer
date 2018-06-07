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
        private ObservableCollection<Activity> _activities;
        public ICommand PrioritizeCommand { get; set; }
        public ICommand AddActivityCommand { get; set; }

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
        }

        public void Prioritize(object activity)
        {

        }

        public void AddActivity(object activity)
        {

        }
    }
}
