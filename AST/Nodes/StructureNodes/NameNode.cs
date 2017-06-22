using AST.Nodes.AbstractNodes;

namespace AST.Nodes.StructureNodes
{
    public class NameNode : BaseNode
    {
        public NameNode(string value)
        {
            Value = value;
        }

        private string _value;

        public string Value
        {
            get => _value;
            set
            {
                _value = value; 
                Update();
            }
        }

        protected override void Update()
        {
            UpdateParentOf(this);
        }
    }
}