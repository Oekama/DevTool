using System.Collections.Generic;
using AST.Operations;

namespace AST.Nodes
{
    public sealed class IntConstNode : NodeBase
    {
        private int _value;

        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                Update();
            }
        }

        public IntConstNode(int value)
        {
            Value = value;
            Update();
        }

        protected override void Update()
        {
            OperationsList = new List<Operation>
            {
                new LoadIntConstOperation(Value)
            };

            UpdateParentOf(this);
        }
    }
}