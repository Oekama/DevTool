using System.Collections.Generic;
using AST.Operations;

namespace AST.Nodes
{
    public abstract class NodeBase
    {
        public AdultNode Parent { get; private set; }

        protected static void SetParent(NodeBase node, AdultNode parent) => node.Parent = parent;

        public List<Operation> OperationsList { get; protected set; }

        protected abstract void Update();

        protected static void UpdateParentOf(NodeBase node) => node.Parent?.Update();

        public NodeBase GetNodeOfPrevusOperation()
        {
            var node = this;

            if (node is AdultNode adult)
                return adult.GetLastChild();

            while (node.Parent != null
                && node.Parent.IsFirstChild(node))
                node = node.Parent;

            if (node.Parent == null)
                return null;

            //ToDo get left subling
            node = node.Parent.GetPreviousChild(node);

            return node;

        }


    }
}