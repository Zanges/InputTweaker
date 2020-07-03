namespace InputTweaker.Logic.Action
{
    public class ActionBase
    {
        private readonly ActionBase _nextAction;

        public ActionBase(ActionBase nextAction = null)
        {
            _nextAction = nextAction;
        }

        public virtual bool Execute(object input)
        {
            return HasNextAction() && _nextAction.Execute(input);
        }

        public bool HasNextAction()
        {
            return _nextAction != null;
        }
    }
}