using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using InputTweaker.View.Generic;

namespace InputTweaker.ViewModel.Generic
{
    public class MessageViewModel : ViewModelBase
    {

        public RelayCommand<ICloseable> CloseWindowCommand { get; private set; }
        
        public string Title { get; set; }
        public string Text { get; set; }
        
        public MessageViewModel()
        {
            CloseWindowCommand = new RelayCommand<ICloseable>(CloseWindow);
        }
        
        private void CloseWindow(ICloseable window)
        {
            if (window != null)
            {
                window.Close();
            }
        }
    }
}