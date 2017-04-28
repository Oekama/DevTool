using System;
using System.Reflection.Emit;
using AST.Nodes;
using NUnit.Framework;

namespace UnitTestAST.Nodes
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

            foreach (var operation in addCode.OperationsList)
                operation.Emit(il);

            il.Emit(OpCodes.Ret);

            var addAction = (Func<int>) add.CreateDelegate(typeof(Func<int>));

            Assert.AreEqual(4, addAction());

        }

        [Test]
        public void MultiplicationTest()
        {
            var mulCode = new MultiplicationNode(new IntConstNode(2), new IntConstNode(2));

            Type[] methodArgs = {};

            var mul = new DynamicMethod(
                "Multiplication",
                typeof(int),
                methodArgs,
                typeof(NodesTests).Module);

            var il = mul.GetILGenerator();

            foreach (var operation in mulCode.OperationsList)
                operation.Emit(il);

            il.Emit(OpCodes.Ret);

            var mulAction = (Func<int>) mul.CreateDelegate(typeof(Func<int>));

            Assert.AreEqual(4, mulAction());

        }

        [Test]
        public void AddMultiplicationTest()
        {
            var code = new MultiplicationNode(new AddNode(new IntConstNode(2),new IntConstNode(2) ), new IntConstNode(2));

            Type[] methodArgs = {};

            var met = new DynamicMethod(
                "Multiplication",
                typeof(int),
                methodArgs,
                typeof(NodesTests).Module);

            var il = met.GetILGenerator();

            foreach (var operation in code.OperationsList)
                operation.Emit(il);

            il.Emit(OpCodes.Ret);

            var act = (Func<int>) met.CreateDelegate(typeof(Func<int>));

            Assert.AreEqual(8, act());

        }

        [Test]
        public void MultiplicationAddTest()
        {
            var code = new AddNode(new MultiplicationNode(new IntConstNode(2),new IntConstNode(2) ), new IntConstNode(2));

            Type[] methodArgs = {};

            var met = new DynamicMethod(
                "Multiplication",
                typeof(int),
                methodArgs,
                typeof(NodesTests).Module);

            var il = met.GetILGenerator();

            foreach (var operation in code.OperationsList)
                operation.Emit(il);

            il.Emit(OpCodes.Ret);

            var act = (Func<int>) met.CreateDelegate(typeof(Func<int>));

            Assert.AreEqual(6, act());

        }



    }
}