namespace AST.Nodes.AbstractNodes
{
    public abstract class BaseNode : INode
    {
        public IAdultNode Parent { get; private set; }

        protected static void SetParent(INode baseNode, IAdultNode parent)
        {
            ((BaseNode)baseNode).Parent = parent;
        }

        protected abstract void Update();

        protected static void UpdateParentOf(BaseNode baseNode)
        {
            if (baseNode.Parent != null)
            {
                (baseNode.Parent as BaseNode)?.Update();
            }
        }
    }

    

}