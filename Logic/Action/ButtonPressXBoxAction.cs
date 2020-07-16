using System;
using InputTweaker.Logic.Initialisation;
using Nefarius.ViGEm.Client.Targets;
using Nefarius.ViGEm.Client.Targets.Xbox360;

namespace InputTweaker.Logic.Action
{
    public class ButtonPressXBoxAction : ActionBase
    {
        private readonly Xbox360Button _button;
        
        public ButtonPressXBoxAction(Xbox360Button button, ActionBase nextAction = null) : base(nextAction)
        {
            _button = button;
        }

        public override bool Execute(object input)
        {
            if (input is bool boolInput)
            {

                IXbox360Controller controller = ViGEmWrapper.Instance.GetController();
                controller.SetButtonState(_button, boolInput);
                controller.SubmitReport();
            }
            
            return base.Execute(input);
        }
    }
}