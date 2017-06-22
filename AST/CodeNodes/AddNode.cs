using System.Collections.Generic;
using System.Reflection.Emit;
using AST.AbstractNodes;
using AST.Operations;

namespace AST.CodeNodes
{
    public sealed class AddNode : AdultBaseNode , ICode
    {
        public AddNode(BaseNode leftOperand, BaseNode rightOperand)
        {
            Children = new[] {leftOperand, rightOperand};

            SetParent(leftOperand,this);
            SetParent(rightOperand,this);

            Update();
        }

        protected override void Update()
        {
            var oplist = new List<Operation>();
            oplist.AddRange(((ICode)Children[0]).OperationsList);
            oplist.AddRange(((ICode)Children[1]).OperationsList);

            oplist.Add(new Operation(OpCodes.Add));

            OperationsList = oplist;

            UpdateParentOf(this);
        }

        public List<Operation> OperationsList { get; private set; }
    }
}