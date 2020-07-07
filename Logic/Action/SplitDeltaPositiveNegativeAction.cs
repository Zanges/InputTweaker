using System;

namespace InputTweaker.Logic.Action
{
    public class SplitDeltaPositiveNegativeAction : ActionBase
    {
        private readonly ActionBase _actionPositive;
        private readonly ActionBase _actionNegative;
        private readonly bool _absoluteOutput;
        private readonly int _outputOffset;

        public SplitDeltaPositiveNegativeAction(ActionBase actionPositive, ActionBase actionNegative, bool absoluteOutput = false, int outputOffset = 0)
        {
            _actionPositive = actionPositive;
            _actionNegative = actionNegative;
            _absoluteOutput = absoluteOutput;
            _outputOffset = outputOffset;
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
                return _actionPositive.Execute(_absoluteOutput ? Math.Abs(inputDelta + _outputOffset) : Math.Max(0, inputDelta + _outputOffset));
            }

            return inputDelta < 0 && _actionNegative.Execute(_absoluteOutput ? Math.Abs(inputDelta + _outputOffset) : Math.Min(0, inputDelta - _outputOffset));
        }
    }
}