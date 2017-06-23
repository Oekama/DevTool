using System.Collections.Generic;

namespace AST.Nodes.AbstractNodes
{
    public interface IAdultNode : INode
    {
        INode GetChild(int childId);
    }
}