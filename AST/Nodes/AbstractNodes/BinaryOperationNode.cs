using System;
using System.Collections.Generic;
using AST.Operations;

namespace AST.Nodes.AbstractNodes
{
    public abstract class BinaryOperationNode : AdultNode, ICodeNode
    {
        
        public BinaryOperationNode(BaseNode leftOperand, BaseNode rightOperand)
        {
            Children = new[] {leftOperand, rightOperand};
            SetParent(leftOperand,this);
            SetParent(rightOperand,this);
            
            Update();
        }

        protected sealed override void Update()
        {

            var oplist = new List<Operation>();
            oplist.AddRange(((ICodeNode)Children[0]).OperationsСache);
            oplist.AddRange(((ICodeNode)Children[1]).OperationsСache);

            PushOperations(oplist);
            //oplist.Add(new Operation(OpCodes.Mul));

            OperationsСache = oplist;

            UpdateParentOf(this);
        }

        protected abstract void PushOperations(List<Operation> opList);
        
        public List<Operation> OperationsСache { get; private set; }
        
    }
}