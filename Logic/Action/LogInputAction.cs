using System;
using InputTweaker.Logic.Ui.Common;

namespace InputTweaker.Logic.Action
{
    public class LogInputAction : ActionBase
    {
        private static readonly LogWriter _logWriter = new LogWriter("LogInputAction");

        public LogInputAction(ActionBase nextAction = null) : base(nextAction)
        {
        }

        public override void Execute(object input)
        {
            if (input is bool inputBool)
            {
                _logWriter.LogMessage(inputBool ? "Down" : "Up", false);
            }
            else
            {
                _logWriter.LogMessage(input.ToString(), false);
            }

            base.Execute(input);
        }
    }
}