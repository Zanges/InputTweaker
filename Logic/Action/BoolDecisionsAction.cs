namespace InputTweaker.Logic.Action
{
    public class BoolDecisionsAction : ActionBase
    {
        private readonly ActionBase _actionTrue;
        private readonly ActionBase _actionFalse;
        private readonly bool _keepInput;

        public BoolDecisionsAction(ActionBase actionTrue, ActionBase actionFalse, bool keepInput = false)
        {
            _actionTrue = actionTrue;
            _actionFalse = actionFalse;
            _keepInput = keepInput;
        }

        public override void Execute(object input)
        {
            if (input is bool boolInput)
            {
                if (boolInput)
                {
                    _actionTrue.Execute(_keepInput ? input : true);
                }
                else
                {
                    _actionFalse.Execute(_keepInput ? input : true);
                }
            }
        }
    }
}