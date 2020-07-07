using System;
using InputTweaker.Logic.Ui.Common;

namespace InputTweaker.Logic.Action
{
    public class LogMessageAction : ActionBase
    {
        private static readonly LogWriter LogWriter = new LogWriter("LogMessageAction");
        private readonly double _messageInterval;
        private DateTime _dateTimeLastMessage;

        private readonly string _message;

        public LogMessageAction(string message, double messageInterval = 100, ActionBase nextAction = null) : base(nextAction)
        {
            _message = message;
            _messageInterval = messageInterval;
            _dateTimeLastMessage = DateTime.Now;
        }
        
        public override bool Execute(object input)
        {
            if (_dateTimeLastMessage.AddMilliseconds(_messageInterval) <= DateTime.Now)
            {
                LogWriter.LogMessage(_message, false);
                _dateTimeLastMessage = DateTime.Now;
            }

            return base.Execute(input);
        }
    }
}