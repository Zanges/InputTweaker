using System;
using InputTweaker.Logic.Ui.Common;

namespace InputTweaker.Logic.Action
{
    public class LogInputAction : ActionBase
    {
        private static readonly LogWriter LogWriter = new LogWriter("LogInputAction");

        public LogInputAction(ActionBase nextAction = null) : base(nextAction)
        {
        }

        public override bool Execute(object input)
        {
            if (input is bool inputBool)
            {
                LogWriter.LogMessage(inputBool ? "Down" : "Up", false);
            }
            else
            {
                LogWriter.LogMessage(input.ToString(), false);
            }

            return base.Execute(input);
        }
    }
}