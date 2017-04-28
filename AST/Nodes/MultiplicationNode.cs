using System.Collections.Generic;
using System.Reflection.Emit;
using AST.Operations;

namespace AST.Nodes
{
    public sealed class MultiplicationNode : AdultNode
    {

        public MultiplicationNode(NodeBase leftOperand, NodeBase rightOperand)
        {
            Children = new[] {leftOperand, rightOperand};
            SetParent(leftOperand,this);
            SetParent(rightOperand,this);

            Update();
        }

        protected override void Update()
        {

            var oplist = new List<Operation>();
            oplist.AddRange(Children[0].OperationsList);
            oplist.AddRange(Children[1].OperationsList);

            oplist.Add(new Operation(OpCodes.Mul));

            OperationsList = oplist;

            UpdateParentOf(this);
        }

    }
}