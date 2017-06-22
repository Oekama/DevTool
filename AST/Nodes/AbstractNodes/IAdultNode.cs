using System.Collections.Generic;

namespace AST.Nodes.AbstractNodes
{
    public interface IAdultNode
    {
        List<BaseNode> GetChildren();
    }
}