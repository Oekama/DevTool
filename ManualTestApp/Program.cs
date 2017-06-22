using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using AST;
using AST.Nodes.CodeNodes;
using AST.Nodes.StructureNodes;

namespace ManualTestApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var code = new FunNode(
                new TypeNode(typeof(int)),
                new NameNode("add"),
                new ReurnNode(
                    new AddNode(
                        new IntConstNode(100),
                        new IntConstNode(3))));

            var act = (Func<int>)code.Method.CreateDelegate(typeof(Func<int>));

            Console.WriteLine(act());
            Console.ReadLine();
        }
    }
}