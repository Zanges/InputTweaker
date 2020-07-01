using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Windows.Data;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using InputTweaker.Logic.Ui.Window;

namespace InputTweaker.ViewModel
{
    public class MainViewModel : ViewModelBase, IDataErrorInfo
    {
        SynchronizationContext uiContext;
        /// <summary>
        /// Opens a new child window.
        /// </summary>
        public RelayCommand OpenChildCommand { get; private set; }
        public RelayCommand OpenProfileCommand { get; private set; }
        public RelayCommand TestCommand { get; private set; }

        private ObservableCollection<string> _logEntries;
        public ICollectionView LogEntriesView { get; }

        public string SelectedLogEntry
        {
            get => LogEntriesView.CurrentItem as string;
            set
            {
                LogEntriesView.MoveCurrentTo(value);
                RaisePropertyChanged();
            }
        }


        public MainViewModel()
        {
            uiContext = SynchronizationContext.Current;
            
            #region Common

            OpenChildCommand = new RelayCommand(() => MessengerInstance.Send(new OpenChildWindowMessage("Hello Child!")));
            OpenProfileCommand = new RelayCommand(() => MessengerInstance.Send(new OpenProfileWindowMessage()));
            
            TestCommand = new RelayCommand(() => MessengerInstance.Send(new OpenGenericMessageWindowMessage("134", "hello")));

            _logEntries = new ObservableCollection<string>();
            LogEntriesView = CollectionViewSource.GetDefaultView(_logEntries);
            LogEntriesView.CurrentChanged += (s, e) =>
            {
                RaisePropertyChanged(() => SelectedLogEntry);
            };

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

        public void AddLogEntry(string entry)
        {
            uiContext.Send(x =>
            {
                if (_logEntries.Count >= 100)
                {
                    _logEntries.RemoveAt(0);
                }

                _logEntries.Add(entry);
            }, null);
        }

        public void ClearLog()
        {
            _logEntries.Clear();
        }
        
        private Dictionary<string, string> Errors { get; } = new Dictionary<string, string>();

        private void CollectErrors()
        {
            Errors.Clear();
            
            // todo https://codingfreaks.de/wpf-mvvm-03/
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
