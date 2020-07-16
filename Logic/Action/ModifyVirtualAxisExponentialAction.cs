using InputTweaker.Logic.Helper;
using InputTweaker.Logic.Variable;

namespace InputTweaker.Logic.Action
{
    public class ModifyVirtualAxisExponentialAction : ActionBase
    {
        private readonly string _axisId;
        private readonly float _sensitivity;
        private readonly bool _overwriteInput;
        
        public ModifyVirtualAxisExponentialAction(string axisId, float sensitivity, bool overwriteInput = false, ActionBase nextAction = null) : base(nextAction)
        {
            _axisId = axisId;
            _sensitivity = sensitivity;
            _overwriteInput = overwriteInput;
        }

        public override bool Execute(object input)
        {
            short newValue = (short) MathHelper.Clamp(
                AxisVariable.GetVariable(_axisId).value * _sensitivity, 
                short.MaxValue, 
                short.MinValue);
            
            AxisVariable.GetVariable(_axisId).value = newValue;
        
            return base.Execute(_overwriteInput ? newValue : input);
        }
    }
}