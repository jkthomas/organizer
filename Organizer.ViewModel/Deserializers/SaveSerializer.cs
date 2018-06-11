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
    public class SaveSerializer
    {
        public static OrganizerTemplate Serialize(ObservableCollection<ActivityViewModel> activities)
        {
            OrganizerTemplate template = new OrganizerTemplate();
            template.Activities = new List<Activity>();
            foreach (var activity in activities)
            {
                template.Activities.Add(new Activity()
                {
                    Note = activity.Note,
                    Priority = activity.Priority
                });
            }
            return template;
        }
    }
}
