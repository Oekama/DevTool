using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AST.Nodes;

namespace AST
{
    public abstract class BinaryOperationNodeBase : NodeBase
    {
        private NodeBase _leftOperand;
        private NodeBase _rightOperand;

        public NodeBase LeftOperand
        {
            get => _leftOperand;
            set
            {
                _leftOperand = value;
                SetParent(value, this);
            }
        }

        public NodeBase RightOperand
        {
            get => _rightOperand;
            set
            {
                _rightOperand = value;
                SetParent(value, this);
            }
        }
    }
}