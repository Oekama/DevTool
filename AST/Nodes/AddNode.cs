using System.Collections.Generic;
using System.Reflection.Emit;
using AST.Operations;

namespace AST.Nodes
{
    public class AddNode : IASTNode
    {
        public IASTNode LeftOperand { get; set; }
        public IASTNode RightOperand { get; set; }

        public AddNode(IASTNode leftOperand, IASTNode rightOperand)
        {
            LeftOperand = leftOperand;
            RightOperand = rightOperand;
        }

        public List<Operation> GetOperationsList()
        {
            var res = new List<Operation>();
            res.AddRange(LeftOperand.GetOperationsList());
            res.AddRange(RightOperand.GetOperationsList());

            res.Add(new Operation(OpCodes.Add));

            return res;
        }
    }
}