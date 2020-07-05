using System;

namespace InputTweaker.Logic.Enum
{
    [Flags]
    public enum ActionType
    {
        None=0,
        Independent=1,
        Boolean=2,
        Delta=4,
        Analog=8,
        SingleTrigger=16,
    }
}