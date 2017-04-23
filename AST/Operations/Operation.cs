using System;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace AST.Operations
{
    public class Operation
    {
        public Operation(OpCode opCode)
        {
            OpCode = opCode;
        }

        protected Operation()
        {
        }

        public OpCode OpCode { get; protected set; }

        public void Emit(ILGenerator generator)
        {
            generator.Emit(OpCode);
        }
    }
}