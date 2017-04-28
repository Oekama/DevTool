using AST.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AST
{
    public abstract class AdultNode : NodeBase
    {
        //ToDo set child

        protected NodeBase[] Children;

        public int CountChildren => Children.Length;

        public int GetChildNumber(NodeBase child) => Array.FindIndex(Children,node => ReferenceEquals(node, child));

        public bool IsFirstChild(NodeBase child) => ReferenceEquals(child, Children[0]);

        // req: 0 < @number < _children.Count
        public NodeBase GetChild(int number) => Children[number];

        public NodeBase GetLastChild() => GetChild(CountChildren - 1);

        // req: @child in _children
        public NodeBase GetPreviousChild(NodeBase child) => Parent.GetChild(Parent.GetChildNumber(child) - 1);
    }
}