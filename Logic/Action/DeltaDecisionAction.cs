namespace InputTweaker.Logic.Action
{
    public class DeltaDecisionAction : ActionBase
    {
        private readonly ActionBase _actionPositive;
        private readonly ActionBase _actionNegative;

        public DeltaDecisionAction(ActionBase actionPositive, ActionBase actionNegative)
        {
            _actionPositive = actionPositive;
            _actionNegative = actionNegative;
        }

        public override bool Execute(object input)
        {
            int inputDelta;
            switch (input)
            {
                case int i:
                    inputDelta = i;
                    break;
                case short s:
                    inputDelta = s;
                    break;
                default:
                    return false;
            }

            if (inputDelta > 0)
            {
                return _actionPositive.Execute(true);
            }

            return inputDelta < 0 && _actionNegative.Execute(true);
        }
    }
}