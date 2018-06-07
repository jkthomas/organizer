﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.ViewModel.AppViewModel
{
    public class OrganizerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Activity> _activities;

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

    }
}
