using System.Collections.Generic;

namespace InputTweaker.Logic.Action
{
    public class BranchAction : ActionBase
    {
        private readonly List<ActionBase> _actions;
        
        public BranchAction(List<ActionBase> actions)
        {
            _actions = actions;
        }
        
        public override void Execute(object input)
        {
            foreach (ActionBase action in _actions)
            {
                action.Execute(input);
            }
        }
    }
}