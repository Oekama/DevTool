using System.Collections.Generic;
using AST.Operations;

namespace AST.Nodes
{
    public class IntConstNode : IASTNodeInternal
    {
        private int _value;

        public int Value
        {
            get { return _value; }
            set
            {
                _value = value;
                ((IASTNodeInternal) this).Update();
            }
        }

        private List<Operation> _operationListCache;
        private IASTNode _parent;


        public IntConstNode(int value)
        {
            Value = value;
            _operationListCache = new List<Operation>
            {
                new LoadIntConstOperation(Value)
            };
        }

        public IASTNode Parent => _parent;

        public List<Operation> GetOperationsList() => _operationListCache;

        void IASTNodeInternal.Update()
        {

            _operationListCache = new List<Operation>
            {
                new LoadIntConstOperation(Value)
            };

            ((IASTNodeInternal)Parent)?.Update();
        }

        public void SetParent(IASTNode parent)
        {
            _parent = parent;
        }
    }
}