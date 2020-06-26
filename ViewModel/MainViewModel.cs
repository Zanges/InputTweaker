using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using InputTweaker.Logic.Ui;

namespace InputTweaker.ViewModel
{
    public class MainViewModel : ViewModelBase, IDataErrorInfo
    {
        public string Firstname { get; set; }

        /// <summary>
        /// Opens a new child window.
        /// </summary>
        public RelayCommand OpenChildCommand { get; private set; }
        public RelayCommand OpenProfileCommand { get; private set; }

        public MainViewModel()
        {
            #region Common
            
            OpenChildCommand = new RelayCommand(() => MessengerInstance.Send(new OpenChildWindowMessage("Hello Child!")));
            OpenProfileCommand = new RelayCommand(() => MessengerInstance.Send(new OpenProfileWindowMessage()));
            
            #endregion
            
            #region DesignTime
            
            if (IsInDesignMode)
            {

            }
            
            #endregion
            
            #region RunTime
            
            else
            {

            }
            
            #endregion
        }
        
        private Dictionary<string, string> Errors { get; } = new Dictionary<string, string>();

        private void CollectErrors()
        {
            Errors.Clear();
            
            // todo https://codingfreaks.de/wpf-mvvm-03/
            if (string.IsNullOrEmpty(Firstname)) 
            {
                Errors.Add(nameof(Firstname), "Firstname must not be empty!");
            }  
        }

        public string this[string columnName] 
        {
            get
            {
                CollectErrors();
                return Errors.ContainsKey(columnName) ? Errors[columnName] : string.Empty;
            }
        }

        public string Error => throw new NotImplementedException();
    }
}
