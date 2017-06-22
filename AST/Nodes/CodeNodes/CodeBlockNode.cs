using System.Collections.Generic;
using System.Linq;
using AST.Nodes.AbstractNodes;
using AST.Operations;

namespace AST.Nodes.CodeNodes
{
    public sealed class CodeBlockNode : AdultNode, ICodeNode
    {
        public CodeBlockNode(ICodeNode[] lines)
        {
            Children =  (BaseNode[]) lines.Select(line => (BaseNode)line);

            foreach (var line in lines)
                SetParent((BaseNode) line, this);
            
            Update();
            
        }

        protected override void Update()
        {
            var oplist = new List<Operation>();

            foreach (var line in Children)
                oplist.AddRange(((ICodeNode) line).OperationsСache);

            OperationsСache = oplist;
            
            UpdateParentOf(this);

        }

        public List<Operation> OperationsСache { get; private set; }
    }
}