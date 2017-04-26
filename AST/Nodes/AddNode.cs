using System.Collections.Generic;
using System.Reflection.Emit;
using AST.Operations;

namespace AST.Nodes
{
    public sealed class AddNode : BinaryOperationNodeBase
    {
        public AddNode(NodeBase leftOperand, NodeBase rightOperand)
        {
            RightOperand = rightOperand;
            LeftOperand = leftOperand;
            Update();
        }

        protected override void Update()
        {
            var oplist = new List<Operation>();
            oplist.AddRange(LeftOperand.OperationsList);
            oplist.AddRange(RightOperand.OperationsList);

            oplist.Add(new Operation(OpCodes.Add));

            OperationsList = oplist;

            UpdateParentOf(this);
        }

    }
}