using System;
using System.Collections.Generic;
using AST.Operations;

namespace AST.Nodes.AbstractNodes
{
    public abstract class BinaryOperationNode : BaseNode, ICodeNode, IAdultNode
    {

        ICodeNode _leftOperand;
        ICodeNode _rightOperand;

        public ICodeNode LeftOperand
        {
            get
            {
                return _leftOperand;
            }
            set
            {
                _leftOperand = value;
                SetParent(_leftOperand, this);
                Update();
            }
        }

        public ICodeNode RightOperand
        {
            get
            {
                return _rightOperand;
            }
            set
            {
                _rightOperand = value;
                SetParent(_rightOperand, this);
                Update();
            }
        }

        public BinaryOperationNode(ICodeNode leftOperand, ICodeNode rightOperand)
        {
            _leftOperand = leftOperand;
            _rightOperand = rightOperand;

            SetParent(leftOperand, this);
            SetParent(rightOperand, this);

            Update();
        }

        protected sealed override void Update()
        {

            var oplist = new List<Operation>();
            oplist.AddRange(LeftOperand.OperationsСache);
            oplist.AddRange(RightOperand.OperationsСache);

            PushOperations(oplist);

            OperationsСache = oplist;

            UpdateParentOf(this);
        }

        protected abstract void PushOperations(List<Operation> opList);

        public INode GetChild(int childId)
        {
            if (childId == 0)
                return LeftOperand;
            else if (childId == 1)
                return RightOperand;
            else
                throw new IndexOutOfRangeException();
        }

        public List<Operation> OperationsСache { get; private set; }

    }
}