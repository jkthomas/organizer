using Organizer.Helpers.Templates.ViewModelTemplates;
using Organizer.ViewModel.AppViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.ViewModel.Deserializers
{
    public class InitialDeserializer
    {
        public static ObservableCollection<ActivityViewModel> Deserialize(OrganizerTemplate organizerTemplate)
        {
            ObservableCollection<ActivityViewModel> activityViewModels = new ObservableCollection<ActivityViewModel>();
            foreach(var activity in organizerTemplate.Activities)
            {
                activityViewModels.Add(new ActivityViewModel(activity.Note, activity.Priority));
            }
            return activityViewModels;
        }
    }
}
