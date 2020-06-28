using System;

namespace InputTweaker.Logic.Ui.Window
{
    public class OpenGenericMessageWindowMessage
    {
        #region constructors and destructors

        public OpenGenericMessageWindowMessage(string title, string text)
        {
            Title = title;
            Text = text;
        }

        #endregion

        #region properties

        public string Text { get; private set; }
        public string Title { get; private set; }

        #endregion
    }
}