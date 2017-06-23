using System.Collections.Generic;
using AST.Operations;

namespace AST.Nodes.AbstractNodes
{
    public interface ICodeNode : INode
    {
        List<Operation> OperationsСache { get; }
    }
}