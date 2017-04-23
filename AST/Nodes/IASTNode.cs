using System.Collections.Generic;
using AST.Operations;

namespace AST.Nodes
{
    public interface IASTNode
    {
        List<Operation> GetOperationsList();
    }
}