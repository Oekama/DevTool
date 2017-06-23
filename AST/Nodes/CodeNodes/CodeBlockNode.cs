using System;
using System.Collections.Generic;
using System.Linq;
using AST.Nodes.AbstractNodes;
using AST.Operations;

namespace AST.Nodes.CodeNodes
{
    public sealed class CodeBlockNode : BaseNode,  ICodeNode, IAdultNode
    {
        private ICodeNode[] _children;

        public CodeBlockNode(ICodeNode[] lines)
        {
            _children =  lines;

            foreach (var line in lines)
                SetParent(line, this);
            
            Update();
            
        }

        protected override void Update()
        {
            var oplist = new List<Operation>();

            foreach (var line in _children)
                oplist.AddRange(line.OperationsСache);

            OperationsСache = oplist;
            
            UpdateParentOf(this);

        }

        public INode GetChild(int childId)
        {
            return _children[childId];
        }

        public void SetChild(int childId, ICodeNode child)
        {
            _children[childId] = child;
            SetParent(child, this);
            Update();
        }


        public List<Operation> OperationsСache { get; private set; }
    }
}