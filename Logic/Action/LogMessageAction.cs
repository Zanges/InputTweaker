using InputTweaker.Logic.Ui.Common;

namespace InputTweaker.Logic.Action
{
    public class LogMessageAction : ActionBase
    {
        private static readonly LogWriter _logWriter = new LogWriter("LogMessageAction");

        private readonly string _message;

        public LogMessageAction(string message, ActionBase nextAction = null) : base(nextAction)
        {
            _message = message;
        }
        
        public override void Execute(object input)
        {
            _logWriter.LogMessage(_message, false);

            base.Execute(input);
        }
    }
}