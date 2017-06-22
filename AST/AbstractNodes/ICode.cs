using System.Collections.Generic;
using AST.Operations;

namespace AST.Abstract
{
    public interface ICode
    {
        List<Operation> OperationsList { get; }
    }
}