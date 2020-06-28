namespace InputTweaker.Logic.Ui.Window
{
    public class OpenChildWindowMessage
    {
        #region constructors and destructors

        public OpenChildWindowMessage(string someText)
        {
            SomeText = someText;
        }

        #endregion

        #region properties

        public string SomeText { get; private set; }

        #endregion
    }
}