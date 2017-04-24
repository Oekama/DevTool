using System.Collections.Generic;
using AST.Operations;

namespace AST.Nodes
{
    public interface IASTNode
    {
        IASTNode Parent { get;  }

        List<Operation> GetOperationsList();
        //void Update();
    }

    internal interface IASTNodeInternal : IASTNode
    {
        void Update();
        void SetParent(IASTNode parent);
    }


}