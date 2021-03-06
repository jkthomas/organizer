﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.ViewModel.AppViewModel
{
    public class ActivityViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        private string _note;
        private int _priority;
        public string Note
        {
            get { return this._note; }
            set
            {
                if (this._note == value)
                    return;

                this._note = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Note)));
            }
        }
        public int Priority {
            get { return this._priority; }
            set
            {
                if (this._priority == value)
                    return;

                this._priority = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Priority)));
            }
        }
        public ActivityViewModel(string note, int priority)
        {
            this.Note = note;
            this.Priority = priority;
        }


        public override string ToString()
        {
            return this.Note;
        }
    }
}
