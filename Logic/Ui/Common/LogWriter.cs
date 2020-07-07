using System;
using CommonServiceLocator;
using InputTweaker.ViewModel;

namespace InputTweaker.Logic.Ui.Common
{
    public class LogWriter
    {
        private readonly string _identifier;

        public LogWriter(string identifier)
        {
            _identifier = identifier;
        }

        public void LogMessage(string message, bool containsIdentifier = true)
        {
            if (containsIdentifier)
            {
                message = $"{_identifier}: {message}";
            }
            
            Console.WriteLine(message);
            try
            {
                ServiceLocator.Current.GetInstance<MainViewModel>().AddLogEntry(message);
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}