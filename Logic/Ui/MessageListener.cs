using GalaSoft.MvvmLight.Messaging;
using InputTweaker.View;
using InputTweaker.ViewModel;

namespace InputTweaker.Logic.Ui
{
    public class MessageListener
    {
        #region constructors and destructors

        public MessageListener()
        {
            InitMessenger();
        }

        #endregion

        #region methods

        private void InitMessenger()
        {
            Messenger.Default.Register<OpenChildWindowMessage>(
                this,
                msg =>
                {
                    ChildWindow window = new ChildWindow();
                    if (window.DataContext is ChildViewModel model)
                    {
                        model.MessageFromParent = msg.SomeText;
                    }
                    window.ShowDialog();
                });
            
            Messenger.Default.Register<OpenProfileWindowMessage>(
                this,
                msg =>
                {
                    ProfileWindow window = new ProfileWindow();
                    window.ShowDialog();
                });
        }

        #endregion

        #region properties

        public bool BindableProperty => true;

        #endregion
    }
}