using System;
using System.Reflection.Emit;
using AST.Nodes;
using NUnit.Framework;

namespace UnitTestAST
{
    [TestFixture]
    public class NodesTests
    {
        [Test]
        public void AddTest()
        {
            var addCode = new AddNode(new IntConstNode(2), new IntConstNode(2));

            Type[] methodArgs = {};

            var add = new DynamicMethod(
                "Add",
                typeof(int),
                methodArgs,
                typeof(NodesTests).Module);

            var il = add.GetILGenerator();

            foreach (var operation in addCode.GetOperationsList())
                operation.Emit(il);

            il.Emit(OpCodes.Ret);

            var addAction = (Func<int>) add.CreateDelegate(typeof(Func<int>));

            Assert.AreEqual(4, addAction());
        }
    }
}