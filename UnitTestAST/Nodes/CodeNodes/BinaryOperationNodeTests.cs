﻿using System;
using System.Reflection.Emit;
using AST.Nodes.AbstractNodes;
using AST.Nodes.CodeNodes;
using NUnit.Framework;

namespace UnitTestAST.Nodes
{
    [TestFixture]
    public class BinaryOperationNodeTests
    {

        private void TestBaseExecuteCodeIntReturn(BaseNode code, int expected)
        {
            Type[] args = {};

            var dm = new DynamicMethod(
                "Test",
                typeof(int),
                args,
                typeof(BinaryOperationNodeTests).Module);

            var il = dm.GetILGenerator();

            foreach (var op in (code as ICodeNode).OperationsСache)
                op.Emit(il);

            il.Emit(OpCodes.Ret);

            var act = (Func<int>) dm.CreateDelegate(typeof(Func<int>));

            Assert.AreEqual(expected, act());
        }
        
        
        [Test]
        public void AddTest()
        {
            var addCode = new AddNode(
                new IntConstNode(1000), 
                new IntConstNode(2));

            TestBaseExecuteCodeIntReturn(addCode, 1002);
        }

        [Test]
        public void MultiplicationTest()
        {
            var mulCode = new MultiplicationNode(
                new IntConstNode(5), 
                new IntConstNode(2));

            TestBaseExecuteCodeIntReturn(mulCode, 10);
        }

        [Test]
        public void AddMultiplicationTest()
        {
            var code = new MultiplicationNode(
                new AddNode(
                    new IntConstNode(2),
                    new IntConstNode(2)), 
                new IntConstNode(2));

            TestBaseExecuteCodeIntReturn(code, 8);
        }

        [Test]
        public void MultiplicationAddTest()
        {
            var code = new AddNode(
                new MultiplicationNode(
                    new IntConstNode(2),
                    new IntConstNode(2)), 
                new IntConstNode(2));

            TestBaseExecuteCodeIntReturn(code, 6);
        }
    }
}