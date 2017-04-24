using System.Collections.Generic;
using System.Reflection.Emit;
using AST.Operations;

namespace AST.Nodes
{
    public class MultiplicationNode : IASTNodeInternal
    {
        private IASTNode _leftOperand;
        private IASTNode _rightOperand;
        private IASTNode _parent;
        private List<Operation> _operationListCache;

        public IASTNode LeftOperand
        {
            get => _leftOperand;
            set
            {
                _leftOperand = value;
                ((IASTNodeInternal)value).SetParent(this);
            }
        }

        public IASTNode RightOperand
        {
            get => _rightOperand;
            set
            {
                _rightOperand = value;
                ((IASTNodeInternal)value).SetParent(this);
            }
        }

        public MultiplicationNode (IASTNode leftOperand, IASTNode rightOperand)
        {
            LeftOperand = leftOperand;
            RightOperand = rightOperand;

            var oplist = new List<Operation>();
            oplist.AddRange(LeftOperand.GetOperationsList());
            oplist.AddRange(RightOperand.GetOperationsList());

            oplist.Add(new Operation(OpCodes.Mul));

            _operationListCache = oplist;
        }
        public IASTNode Parent => _parent;

        public List<Operation> GetOperationsList()
        {
            return _operationListCache;
        }

        public void Update()
        {

            var oplist = new List<Operation>();
            oplist.AddRange(LeftOperand.GetOperationsList());
            oplist.AddRange(RightOperand.GetOperationsList());

            oplist.Add(new Operation(OpCodes.Mul));

            _operationListCache = oplist;

            ((IASTNodeInternal)Parent)?.Update();
        }

        public void SetParent(IASTNode parent)
        {
            _parent = parent;
        }
    }
}