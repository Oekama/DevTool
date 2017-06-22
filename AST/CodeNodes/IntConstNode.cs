using System.Collections.Generic;
using AST.AbstractNodes;
using AST.Operations;

namespace AST.CodeNodes
{
    public sealed class IntConstBaseNode : BaseNode , ICode
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

        public IntConstBaseNode(int value)
        {

            // todo  updates automaticly --- ? 
            // then we create object parent is not set 
            // is this realy nesesry ?
            Value = value;
        }

        protected override void Update()
        {
            OperationsList = new List<Operation>
            {
                new LoadIntConstOperation(Value)
            };

            UpdateParentOf(this);
        }

        public List<Operation> OperationsList { get; private set; }
    }
}