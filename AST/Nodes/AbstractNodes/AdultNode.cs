namespace AST.Nodes.AbstractNodes
{
    public abstract class AdultNode : BaseNode
    {
  //      //ToDo : Set child problem
  //      // I think this can be maid into interface,
  //      // and aeth baseNode store children hover it neads.
       protected BaseNode[] Children;
//
  //    //  public int CountChildren => Children.Length;
//
  //   //   public int GetChildNumber(BaseNode child) => Array.FindIndex(Children,baseNode => ReferenceEquals(baseNode, child));
//
  //   //   public bool IsFirstChild(BaseNode child) => ReferenceEquals(child, Children[0]);
//
  //      // req: 0 < @number < _children.Count
  //     // public BaseNode GetChild(int number) => Children[number];
//
  //     // public BaseNode GetLastChild() => GetChild(CountChildren - 1);
//
  //      // req: @child in _children
  //     // public BaseNode GetPreviousChild(BaseNode child) => Parent.GetChild(Parent.GetChildNumber(child) - 1);
 }
}