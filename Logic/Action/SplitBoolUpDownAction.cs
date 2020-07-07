namespace InputTweaker.Logic.Action
{
    public class SplitBoolUpDownAction : ActionBase
    {
        private readonly ActionBase _actionDown;
        private readonly ActionBase _actionUp;

        public SplitBoolUpDownAction(ActionBase actionDown, ActionBase actionUp)
        {
            _actionDown = actionDown;
            _actionUp = actionUp;
        }

        public override bool Execute(object input)
        {
            if (input is bool boolInput)
            {
                return boolInput ? _actionDown.Execute(true) : _actionUp.Execute(true);
            }

            return false;
        }
    }
}