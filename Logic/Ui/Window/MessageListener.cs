using GalaSoft.MvvmLight.Messaging;
using InputTweaker.View;
using InputTweaker.View.Generic;
using InputTweaker.ViewModel;
using InputTweaker.ViewModel.Generic;

namespace InputTweaker.Logic.Ui.Window
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
            
            Messenger.Default.Register<OpenGenericMessageWindowMessage>(
                this,
                msg =>
                {
                    MessageWindow window = new MessageWindow();
                    
                    
                    if (window.DataContext is MessageViewModel model)
                    {
                        model.Title = msg.Title;
                        model.Text = msg.Text;
                    }
                    
                    window.ShowDialog();
                });
        }

        #endregion

        #region properties

        public bool BindableProperty => true;

        #endregion
    }
}