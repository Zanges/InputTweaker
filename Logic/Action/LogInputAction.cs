using System;
using InputTweaker.Logic.Ui.Common;

namespace InputTweaker.Logic.Action
{
    public class LogInputAction : ActionBase
    {
        private static readonly LogWriter LogWriter = new LogWriter("LogInputAction");
        private readonly double _messageInterval;
        private DateTime _dateTimeLastMessage;
        
        public LogInputAction(double messageInterval = 100, ActionBase nextAction = null) : base(nextAction)
        {
            _messageInterval = messageInterval;
            _dateTimeLastMessage = DateTime.Now;
        }

        public override bool Execute(object input)
        {
            if (_dateTimeLastMessage.AddMilliseconds(_messageInterval) <= DateTime.Now)
            {
                string message;
                if (input is bool inputBool)
                {
                    message = inputBool ? "Down" : "Up";
                }
                else
                {
                    message = input.ToString();
                }
                LogWriter.LogMessage(message, false);
                _dateTimeLastMessage = DateTime.Now;
            }

            return base.Execute(input);
        }
    }
}