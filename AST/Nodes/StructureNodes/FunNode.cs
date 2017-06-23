using System;
using System.Reflection.Emit;
using AST.Nodes.AbstractNodes;

namespace AST.Nodes.StructureNodes
{
    public sealed class FunNode : BaseNode, IAdultNode
    {

        private ICodeNode _code;

        public ICodeNode Code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
                SetParent(_code, this);
                Update();
            }
        }

        private TypeNode _returnType;

        public TypeNode ReturnType
        {
            get
            {
                return _returnType;
            }
            set
            {
                _returnType = value;
                SetParent(_returnType, this);
                Update();
            }
        }

        private NameNode _name;

        public NameNode Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                SetParent(_name, this);
                Update();
            }
        }

        public DynamicMethod Method { get; private set; }


        // todo args
        public FunNode(TypeNode returnType, NameNode name, ICodeNode code)
        {
            _returnType = returnType;
            _name = name;
            _code = code;

            SetParent(returnType, this);
            SetParent(name, this);
            SetParent(code, this);
            
            Update();

        }


        protected override void Update()
        {
            Type[] methodArgs = { };

            var dm = new DynamicMethod(
                    Name.Value,
                    ReturnType.Value,
                    methodArgs,
                    typeof(FunNode).Module // todo !!!
                    );
            
            var il = dm.GetILGenerator();

            foreach (var operation in Code.OperationsСache)
                operation.Emit(il);

            Method = dm;
        }

        public INode GetChild(int childId)
        {
            switch (childId)
            {
                case 0:
                    return ReturnType;
                case 1:
                    return Name;
                case 2:
                    return Code;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
}