using System;
using System.Reflection.Emit;
using AST.Nodes.AbstractNodes;

namespace AST.Nodes.StructureNodes
{
    public sealed class FunNode : AdultNode
    {

        public DynamicMethod Method { get; private set; }


        // todo args
        public FunNode(TypeNode returnType, NameNode name, ICodeNode code)
        {
            Children = new[] { returnType, name, (BaseNode)code };

            SetParent(returnType, this);
            SetParent(name, this);
            SetParent((BaseNode)code, this);
            
            Update();

        }


        protected override void Update()
        {
            Type[] methodArgs = { };

            var dm = new DynamicMethod(
                    ((NameNode)(Children[1])).Value,
                    ((TypeNode)Children[0]).Value,
                    methodArgs,
                    typeof(FunNode).Module // todo !!!
                    );
            
            var il = dm.GetILGenerator();

            foreach (var operation in ((ICodeNode)Children[2]).OperationsСache)
                operation.Emit(il);

            Method = dm;
        }
    }
}