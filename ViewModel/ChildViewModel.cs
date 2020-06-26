using GalaSoft.MvvmLight;

namespace InputTweaker.ViewModel
{
    public class ChildViewModel : ViewModelBase
    {
        public string MessageFromParent { get; set; }
        
        
        public ChildViewModel()
        {
            if (IsInDesignMode)
            {
                MessageFromParent = "msg";
            }
            else
            {

            }
        }
    }
}