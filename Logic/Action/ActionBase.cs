using System;
using System.Collections;
using System.Collections.Generic;

namespace InputTweaker.Logic.Action
{
    public class ActionBase
    {
        public virtual void Execute(Queue actionQueue, object input)
        {
            Console.WriteLine(actionQueue.Count);
            if (actionQueue.Count > 0)
            {
                ActionBase nextAction = (ActionBase) actionQueue.Dequeue();
                nextAction.Execute(actionQueue, input);
            }

        }
    }
}