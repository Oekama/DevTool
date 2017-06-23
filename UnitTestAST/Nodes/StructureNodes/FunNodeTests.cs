using AST.Nodes.CodeNodes;
using AST.Nodes.StructureNodes;
using NUnit.Framework;
using System;

namespace UnitTestAST.Nodes.StructureNodes
{
    [TestFixture]
    public class FunNodeTests
    {
        [Test]
        public void FunNodeAddTest()
        {
           var code = new FunNode(
           new TypeNode(typeof(int)),
           new NameNode("add"),
           new ReturnNode(
               new AddNode(
                   new IntConstNode(100),
                   new IntConstNode(3))));

            var act = (Func<int>)code.Method.CreateDelegate(typeof(Func<int>));

            Assert.AreEqual(103, act());
        }
    }
}
