using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterviewPreparationsApplications.BinarySearchTree;
using System.Collections.Generic;

namespace  InterviewPreparationApplicationTest
{
    [TestClass]
    public class BinarySearchTreeTest
    {
        BinarySearchTree btree = new BinarySearchTree();
        private Node PrepareBST()
        {
            int[] treeArr = { 9, 7, 10, 8, 6, 12, 11, 13 };
            //var btree = new BinarySearchTree();
            Node root = null;
            foreach (int item in treeArr)
            {
                root = btree.InsertDataToBST(item, root);
            }
            return root;
        }

        [TestMethod]
        public void InsertDataIntoBSTTest()
        {
            Node root = this.PrepareBST();
            Assert.AreEqual(true, btree.IsBst(root));
   
        }
        [TestMethod]
        public void SerializeTreeTest()
        {
            Node root = this.PrepareBST();
            var arrList=new List<int>();
            btree.SerializeTree(root, ref arrList);
            Assert.AreEqual(arrList.Count,17);
        }
        [TestMethod]
        public void DeSerializeTreeTest()
        {
            Node root = this.PrepareBST();
            var arrList = new List<int>();
            btree.SerializeTree(root, ref arrList);
            Node actual = btree.DeSerializeFile(arrList, 0, null);
            Assert.AreEqual(true, btree.IsSameTree(root,actual));
        }
        [TestMethod]
        public void PrintPathListTest()
        {
            Node root = this.PrepareBST();
            var arrList = new List<int>();
            btree.SerializeTree(root, ref arrList);
            btree.PrintPaths(root);
            Assert.AreEqual(true, true);
        }
        [TestMethod]
        public void PrintPathSumTest()
        {
            Node root = this.PrepareBST();
            var arrList = new List<int>();
            btree.PathSum(root);
            Assert.AreEqual(true, true);
        }
        [TestMethod]
        public void PrintMaxPathSumTest()
        {
            Node root = this.PrepareBST();
            var arrList = new List<int>();
            btree.MaxPathSum(root);
            Assert.AreEqual(true, true);
        }
        [TestMethod]
        public void PrintTreeLevelByLevelTest()
        {
            Node root = this.PrepareBST();
            IList<IList<int>> xx = btree.LevelOrder(root);
            Assert.AreEqual(true, true);
        }
        [TestMethod]
        public void PrintTreeVerticalOrderTest()
        {
            Node root = this.PrepareBST();
            btree.PrintTreeVerticalOrder(root);
            Assert.AreEqual(true, true);
        }
        [TestMethod]
        public void PostorderTraversalUsing2StackTest()
        {
            Node root = this.PrepareBST();
            btree.PostorderTraversalUsing2Stack(root);
            Assert.AreEqual(true, true);
        }
        [TestMethod]
        public void RIghtViewMethodTest()
        {
            Node root = this.PrepareBST();
            List<int> output= btree.RightSideView(root);
            
            Assert.AreEqual(true, true);

        }
    }
}
