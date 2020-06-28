using System;
using System.Collections.Generic;

namespace InputTweaker.Logic.Action
{
    public class ActionBase
    {
        public virtual void Execute(Queue<ActionBase> actionQueue, object input)
        {
            Console.WriteLine(actionQueue.Count);
            if (actionQueue.Count > 0)
            {
                ActionBase nextAction = actionQueue.Dequeue();
                nextAction.Execute(actionQueue, input);
            }

        }
    }
}