using InputTweaker.Logic.Ui.Common;

namespace InputTweaker.Logic.Action
{
    public class LogMessageAction : ActionBase
    {
        private static readonly LogWriter LogWriter = new LogWriter("LogMessageAction");

        private readonly string _message;

        public LogMessageAction(string message, ActionBase nextAction = null) : base(nextAction)
        {
            _message = message;
        }
        
        public override void Execute(object input)
        {
            LogWriter.LogMessage(_message, false);

            base.Execute(input);
        }
    }
}