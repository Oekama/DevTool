﻿using System;
using AST.Nodes.AbstractNodes;

namespace AST.Nodes.StructureNodes
{
    public class TypeNode : BaseNode
    {
        public TypeNode(Type value)
        {
            Value = value;
        }

        private Type _value;

        public Type Value
        {
            get => _value;
            set
            {
                _value = value;
                Update();
            }
        }
        protected override void Update()
        {
            UpdateParentOf(this);
        }
    }
}