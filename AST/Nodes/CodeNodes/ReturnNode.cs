using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using AST.Nodes.AbstractNodes;
using AST.Operations;

namespace AST.Nodes.CodeNodes
{
    public sealed class ReturnNode : BaseNode ,ICodeNode, IAdultNode
    {
        private ICodeNode _operand;

        public ICodeNode Operand
        {
            get
            {
                return _operand;
            }
            set
            {
                _operand = value;
                SetParent(_operand, this);
                Update();
            }
        }

        public ReturnNode(ICodeNode operand)
        {
            _operand = operand;

            SetParent(operand, this);
            Update();

        }

        protected override void Update()
        {
            var oplist = new List<Operation>();
            oplist.AddRange(Operand.OperationsСache);

            oplist.Add(new Operation(OpCodes.Ret));

            OperationsСache = oplist;

            UpdateParentOf(this);
        }

        public INode GetChild(int childId)
        {
            if (childId==0)
                return Operand;
            else
                throw new IndexOutOfRangeException();
        }

        public List<Operation> OperationsСache { get; private set; }
    }
}