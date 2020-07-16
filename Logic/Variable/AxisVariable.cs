using System.Collections.Generic;

namespace InputTweaker.Logic.Variable
{
    public class AxisVariable
    {
        private static readonly Dictionary<string, AxisVariable> Variables = new Dictionary<string, AxisVariable>();
        
        public short value = 0;

        public static AxisVariable GetVariable(string id)
        {
            if (!Variables.ContainsKey(id))
            {
                Variables[id] = new AxisVariable();
            }

            return Variables[id];
        }
    }
}