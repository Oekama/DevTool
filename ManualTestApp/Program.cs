using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using AST;
using AST.Nodes;

namespace ManualTestApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var addCode = new AddNode(new IntConstNode(2), new IntConstNode(5));


            Type[] methodArgs = {};


            var add = new DynamicMethod(
                "Add",
                typeof(int),
                methodArgs,
                typeof(Program).Module);


            var il = add.GetILGenerator();
            foreach (var operation in addCode.GetOperationsList())
                operation.Emit(il);

            il.Emit(OpCodes.Ret);


            var addAction = (Func<int>) add.CreateDelegate(typeof(Func<int>));

            Console.WriteLine(addAction());



        }
    }
}