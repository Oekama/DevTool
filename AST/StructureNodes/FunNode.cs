using System;
using System.Dynamic;
using System.Reflection.Emit;
using AST.AbstractNodes;

namespace AST.StructureNodes
{
    public class FunBaseNode : AdultBaseNode
    {
            
            
            
        public FunBaseNode(TypeBaseNode returnTypeBase, )
        {
            SetParent(returnTypeBase,this);
                
        }


        protected override void Update()
        {
        //    var addCode = new AddBaseNode(new IntConstBaseNode(2), new IntConstBaseNode(2));
//
        //    Type[] methodArgs = {};
//
        //    var add = new DynamicMethod(
        //        "Add",
        //        typeof(int),
        //        methodArgs,
        //        typeof(NodesTests).Module);
//
        //    var il = add.GetILGenerator();
//
        //    foreach (var operation in addCode.OperationsList)
        //        operation.Emit(il);
//
        //    il.Emit(OpCodes.Ret);
//
        //    var addAction = (Func<int>) add.CreateDelegate(typeof(Func<int>));
//
        //    Assert.AreEqual(4, addAction());
        }
    }
}