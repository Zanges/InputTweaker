using InputTweaker.Logic.Initialisation;
using Nefarius.ViGEm.Client.Targets;
using Nefarius.ViGEm.Client.Targets.Xbox360;

namespace InputTweaker.Logic.Action
{
    public class AxisMoveXBoxAction : ActionBase
    {
        private readonly Xbox360Axis _axis;
        
        public AxisMoveXBoxAction(Xbox360Axis axis, ActionBase nextAction = null) : base(nextAction)
        {
            _axis = axis;
        }

        public override bool Execute(object input)
        {
            if (input is short axisInput)
            {

                IXbox360Controller controller = ViGEmWrapper.Instance.GetController();
                controller.SetAxisValue(_axis, axisInput);
                controller.SubmitReport();
            }
            
            return base.Execute(input);
        }
    }
}