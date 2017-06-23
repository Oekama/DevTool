using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using AST.Nodes.AbstractNodes;
using AST.Operations;

namespace AST.Nodes.CodeNodes
{
    public sealed class AddNode : BinaryOperationNode
    {

        public AddNode(ICodeNode leftOperand, ICodeNode rightOperand) : base(leftOperand, rightOperand)
        {
        }

        protected override void PushOperations(List<Operation> opList)
        {
            opList.Add(new Operation(OpCodes.Add));
        }
    }
}