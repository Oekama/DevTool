namespace AST.Nodes.AbstractNodes
{
    public abstract class BaseNode
    {
        public AdultNode Parent { get; private set; }

        protected static void SetParent(BaseNode baseNode, AdultNode parent) => baseNode.Parent = parent;
        
        protected abstract void Update();

        protected static void UpdateParentOf(BaseNode baseNode) => baseNode.Parent?.Update();

/*
        public BaseNode GetNodeOfPrevusOperation()
        {
            var baseNode = this;

            if (baseNode is AdultNode adult)
                return adult.GetLastChild();

            while (baseNode.Parent != null
                && baseNode.Parent.IsFirstChild(baseNode))
                baseNode = baseNode.Parent;

            if (baseNode.Parent == null)
                return null;

            //ToDo get left subling
            baseNode = baseNode.Parent.GetPreviousChild(baseNode);

            return baseNode;

        }
*/


    }
}