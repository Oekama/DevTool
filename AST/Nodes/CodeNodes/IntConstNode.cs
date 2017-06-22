using System.Collections.Generic;
using AST.Nodes.AbstractNodes;
using AST.Operations;

namespace AST.Nodes.CodeNodes
{
    public sealed class IntConstNode : BaseNode , ICodeNode
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

            // todo  updates automaticly --- ? 
            // then we create object parent is not set 
            // is this realy nesesry ?
            Value = value;
        }

        protected override void Update()
        {
            OperationsСache = new List<Operation>
            {
                new LoadIntConstOperation(Value)
            };

            UpdateParentOf(this);
        }

        public List<Operation> OperationsСache { get; private set; }
    }
}