using System.Collections;
using System.Collections.Generic;
using InputTweaker.Logic.Ui.Common;

namespace InputTweaker.Logic.Action
{
    public class LogMessageAction : ActionBase
    {
        private static LogWriter _logWriter = new LogWriter("LogMessageAction");

        private string _message;

        public LogMessageAction(ActionBase nextAction, string message) : base(nextAction)
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