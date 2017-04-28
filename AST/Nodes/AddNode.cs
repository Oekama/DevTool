using System.Collections.Generic;
using System.Reflection.Emit;
using AST.Operations;

namespace AST.Nodes
{
    public sealed class AddNode : AdultNode
    {
        public AddNode(NodeBase leftOperand, NodeBase rightOperand)
        {
            Children = new[] {leftOperand, rightOperand};
            Update();
        }

        protected override void Update()
        {
            var oplist = new List<Operation>();
            oplist.AddRange(Children[0].OperationsList);
            oplist.AddRange(Children[1].OperationsList);

            oplist.Add(new Operation(OpCodes.Add));

            OperationsList = oplist;

            UpdateParentOf(this);
        }

    }
}