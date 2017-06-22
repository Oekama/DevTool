using  AST.AbstractNodes;

namespace AST.StructureNodes
{
    public class NameBaseNode : BaseNode
    {
        public NameBaseNode(string value)
        {
            Value = value
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