using System.Reflection.Emit;

namespace AST.Operations
{
    public class LoadIntConstOperation : Operation
    {
        public int Value { get; }

        public LoadIntConstOperation(int value)
        {
            Value = value;
            switch (value)
            {
                case -1:
                    OpCode = OpCodes.Ldc_I4_M1;
                    break;
                case 0:
                    OpCode = OpCodes.Ldc_I4_0;
                    break;
                case 1:
                    OpCode = OpCodes.Ldc_I4_1;
                    break;
                case 2:
                    OpCode = OpCodes.Ldc_I4_2;
                    break;
                case 3:
                    OpCode = OpCodes.Ldc_I4_3;
                    break;
                case 4:
                    OpCode = OpCodes.Ldc_I4_4;
                    break;
                case 5:
                    OpCode = OpCodes.Ldc_I4_5;
                    break;
                case 6:
                    OpCode = OpCodes.Ldc_I4_6;
                    break;
                case 7:
                    OpCode = OpCodes.Ldc_I4_7;
                    break;
                case 8:
                    OpCode = OpCodes.Ldc_I4_8;
                    break;
                //ToDo add short
                default:
                    OpCode = OpCodes.Ldc_I4;
                    break;
            }
        }

        public new void Emit(ILGenerator generator)
        {
            generator.Emit(OpCode, Value);
        }

    }
}