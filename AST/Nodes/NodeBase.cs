using System.Collections.Generic;
using AST.Operations;

namespace AST.Nodes
{
    public abstract class NodeBase
    {
        public NodeBase Parent { get; private set; }

        protected static void SetParent(NodeBase node, NodeBase parent) => node.Parent = parent;

        public List<Operation> OperationsList { get; protected set; }

        protected abstract void Update();

        protected static void UpdateParentOf(NodeBase node) => node.Parent?.Update();
    }
}