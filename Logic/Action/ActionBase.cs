namespace InputTweaker.Logic.Action
{
    public class ActionBase
    {
        private ActionBase _nextAction;

        public ActionBase(ActionBase nextAction)
        {
            _nextAction = nextAction;
        }

        public virtual void Execute(object input)
        {
            _nextAction?.Execute(input);

        }

        public bool HasNextAction()
        {
            return _nextAction != null;
        }
    }
}