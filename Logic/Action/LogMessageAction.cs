using System.Collections.Generic;
using InputTweaker.Logic.Ui.Common;

namespace InputTweaker.Logic.Action
{
    public class LogMessageAction : ActionBase
    {
        private static LogWriter _logWriter = new LogWriter("LogMessageAction");
        
        public override void Execute(Queue<ActionBase> actionQueue, object input)
        {
            _logWriter.LogMessage("test", false);

            base.Execute(actionQueue, input);
        }
    }
}