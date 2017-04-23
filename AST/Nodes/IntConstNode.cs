using System.Collections.Generic;
using AST.Operations;

namespace AST.Nodes
{
    public class IntConstNode : IASTNode
    {
        public int Value { get; set; }

        public IntConstNode(int value)
        {
            Value = value;
        }

        public List<Operation> GetOperationsList()
        {
            return new List<Operation>
            {
                new LoadIntConstOperation(Value)
            };
        }
    }
}