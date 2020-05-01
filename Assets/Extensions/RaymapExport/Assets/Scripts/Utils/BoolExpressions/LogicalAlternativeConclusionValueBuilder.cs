using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.Utils.BoolExpressions
{
    public class LogicalAlternativeConclusionValueBuilder
    {
        private List<Func<object[], bool>> logicalAlternativeExpressionParts = new List<Func<object[], bool>>();
        public LogicalAlternativeConclusionValueBuilder Or(Func<object[], bool> logicalAlternativeExpressionPart)
        {
            logicalAlternativeExpressionParts.Add(logicalAlternativeExpressionPart);
            return this;
        }

        public bool ConcludeFor(object[] logicalExpressionInputArguments)
        {
            foreach (var logicalAlternativeExpressionPart in logicalAlternativeExpressionParts)
            {
                if (logicalAlternativeExpressionPart.Invoke(logicalExpressionInputArguments))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
