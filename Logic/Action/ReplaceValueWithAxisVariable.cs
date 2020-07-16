using InputTweaker.Logic.Variable;

namespace InputTweaker.Logic.Action
{
    public class ReplaceValueWithAxisVariable : ActionBase
    {
        private readonly string _axisId;
        
        public ReplaceValueWithAxisVariable(string axisId, ActionBase nextAction) : base(nextAction)
        {
            _axisId = axisId;
        }

        public override bool Execute(object input)
        {
            return base.Execute(AxisVariable.GetVariable(_axisId).value);
        }
    }
}