namespace InputTweaker.Logic.Action
{
    public class DecisionBoolAction : ActionBase
    {
        private readonly ActionBase _actionTrue;
        private readonly ActionBase _actionFalse;
        private readonly bool _keepInput;

        public DecisionBoolAction(ActionBase actionTrue, ActionBase actionFalse, bool keepInput = false)
        {
            _actionTrue = actionTrue;
            _actionFalse = actionFalse;
            _keepInput = keepInput;
        }

        public override bool Execute(object input)
        {
            if (input is bool boolInput)
            {
                return boolInput ? _actionTrue.Execute(_keepInput ? input : true) : _actionFalse.Execute(_keepInput ? input : true);
            }

            return false;
        }
    }
}