using AST.Nodes.AbstractNodes;
using NUnit.Framework;

namespace UnitTestAST.Nodes
{
    [TestFixture]
    public class NodeBaseTests
    {
        //class TestBaseNode : BaseNode
        //{
            //protected override void Update()
            //{
                ////throw new System.NotImplementedException();
            //}

            //public void NewEvent() =>
                //UpdateParentOf(this);

        //}

        //class TestAdultNode : AdultNode
        //{
            //public bool Updated { get; private set; } // = false;

            //public TestAdultNode(BaseNode child)
            //{
                //Children = new[] {child};
                //SetParent(child,this);
            //}

            //protected override void Update() =>
                //Updated = true;
        //}


        //[Test]
        //public void GetSetParentTest()
        //{
            //var subTree = new TestBaseNode();
            //var tree  = new TestAdultNode(subTree);

            //Assert.AreSame(tree,subTree.Parent);
        //}

        //[Test]
        //public void UpdateParentOfTest()
        //{
            //var subTree = new TestBaseNode();
            //var tree  = new TestAdultNode(subTree);

            //subTree.NewEvent();

            //Assert.AreEqual(true,tree.Updated);
        //}

        // Todo GetNodeOfPrevusOperationTest

    }
}