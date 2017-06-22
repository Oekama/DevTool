using System.Collections.Generic;
using AST.Operations;

namespace AST.Nodes.AbstractNodes
{
    public interface ICodeNode
    {
        List<Operation> OperationsСache { get; }
    }
}