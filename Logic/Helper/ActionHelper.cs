using System;
using InputTweaker.Logic.Enum;

namespace InputTweaker.Logic.Helper
{
    public static class ActionHelper
    {
        public static ActionType GetPossibleActions(TriggerType triggerType)
        {
            switch (triggerType)
            {
                case TriggerType.None:
                    return ActionType.None;
                
                case TriggerType.HardwareKeyboard:
                    return ActionType.Independent | ActionType.Boolean;
                case TriggerType.VirtualKeyboard:
                    return ActionType.Independent | ActionType.Boolean;
                
                case TriggerType.MouseButton:
                    return ActionType.Independent | ActionType.Boolean;
                case TriggerType.MouseScroll:
                    return ActionType.Independent | ActionType.Delta;
                case TriggerType.MouseMove:
                    return ActionType.Independent | ActionType.Delta;
                
                case TriggerType.Timer:
                    return ActionType.Independent | ActionType.SingleTrigger;
                
                case TriggerType.Serial:
                    throw new NotImplementedException();
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(triggerType), triggerType, null);
            }
        }
    }
}