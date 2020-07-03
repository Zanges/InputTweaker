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
        
        public override bool Execute(object input)
        {
            bool block = false;
            foreach (ActionBase action in _actions)
            {
                if (action.Execute(input))
                {
                    block = true;
                }
            }

            return block;
        }
    }
}