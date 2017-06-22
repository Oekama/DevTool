using System.Collections.Generic;
using System.Reflection.Emit;
using AST.Nodes.AbstractNodes;
using AST.Operations;

namespace AST.Nodes.CodeNodes
{
    public sealed class ReurnNode : AdultNode ,ICodeNode
    {
        public ReurnNode(BaseNode operrand)
        {
            Children = new[] {operrand};

            SetParent(operrand, this);
            
            Update();
        }

        protected override void Update()
        {
            var oplist = new List<Operation>();
            oplist.AddRange(((ICodeNode)Children[0]).OperationsСache);

            oplist.Add(new Operation(OpCodes.Ret));

            OperationsСache = oplist;

            UpdateParentOf(this);
        }

        public List<Operation> OperationsСache { get; private set; }
    }
}