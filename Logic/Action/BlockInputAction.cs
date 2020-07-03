namespace InputTweaker.Logic.Action
{
    public class BlockInputAction : ActionBase
    {
        public BlockInputAction(ActionBase nextAction = null) : base(nextAction)
        {
        }
        
        public override bool Execute(object input)
        {
            base.Execute(input);
            return true;
        }
    }
}