using InputTweaker.Logic.Helper;
using InputTweaker.Logic.Variable;

namespace InputTweaker.Logic.Action
{
    public class TransformDeltaToVirtualAxis : ActionBase
    {
        private readonly string _axisId;
        private readonly float _sensitivity;
        private readonly bool _overwriteInput;
        
        public TransformDeltaToVirtualAxis(string axisId, float sensitivity = 1, bool overwriteInput = false, ActionBase nextAction = null) : base(nextAction)
        {
            _axisId = axisId;
            _sensitivity = sensitivity;
            _overwriteInput = overwriteInput;
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

            short newValue = (short) MathHelper.Clamp(
                AxisVariable.GetVariable(_axisId).value + (inputDelta * _sensitivity), 
                short.MaxValue, 
                short.MinValue);

            AxisVariable.GetVariable(_axisId).value = newValue;
            
            return base.Execute(_overwriteInput ? newValue : input);
        }
    }
}