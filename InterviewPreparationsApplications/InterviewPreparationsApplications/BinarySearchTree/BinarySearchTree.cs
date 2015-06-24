using System;
using System.Collections.Generic;
using System.Collections;

namespace InterviewPreparationsApplications.BinarySearchTree
{
    public class BinarySearchTree
    {

        public void SerializeTree(Node root, ref List<int> array)
        {
            if (root == null)
            {
                array.Add(-1);
                return;
            }
            array.Add(root.Data);
            SerializeTree(root.Left, ref array);
            SerializeTree(root.Right, ref array);
        }
        public Node DeSerializeFile(List<int> array, int index, Node root)
        {
            if (array == null || array.Count <= 0) return null;
            int val = 0;
            if (index < array.Count && array[index] != -1)
                val = array[index];
            else
                return null;

            root = new Node(array[index]);
            root.Left= DeSerializeFile(array, ++index,root.Left);
            root.Right = DeSerializeFile(array, ++index,root.Right);
            return root;
        }

        public void PreOrderTraversal(Node root)
        {
            if (root == null) return;
            Console.Write("{0},", root.Data);
            PreOrderTraversal(root.Left);
            PreOrderTraversal(root.Right);
        }
        public void PostOrderTraversal(Node root)
        {
            if (root == null) return;
            PostOrderTraversal(root.Left);
            PostOrderTraversal(root.Right);
            Console.Write("{0},", root.Data);
        }
        public void InOrderTraversal(Node root)
        {
            if (root == null) return;
            InOrderTraversal(root.Left);
            Console.Write("{0},", root.Data);
            InOrderTraversal(root.Right);
        }
        public Node InsertDataToBST(int Newdata, Node root)
        {
            if (root == null)
                root = new Node(Newdata);
            else
            {
                if (root.Data > Newdata)
                    root.Left = InsertDataToBST(Newdata, root.Left);
                else
                    root.Right = InsertDataToBST(Newdata, root.Right);
            }
            return root;
        }
        public int FindMax(Node root)
        {
            if (root == null) return -1;
            while (root.Right != null)
            {
                root = root.Right;

            }
            return root.Data;
        }
        public void PrintPaths(Node root)
        {
            int[] Path = new int[100];
            int pathLen = 0;
            PrintPaths(root, Path, pathLen);

        }
        List<int> _path = new List<int>();
        List<List<int>> pathlist = new List<List<int>>();
        public void PrintPaths(Node root, int[] Path, int pathlen)
        {
            if (root == null) return;
            else if (root.Left == null && root.Right == null)
            {
                _path.Add(root.Data);
                Path[pathlen++] = root.Data;
                for (int i = 0; i < pathlen; i++)
                {
                    Console.Write("{0},", Path[i]);
                }
                pathlist.Add(_path);
                Console.WriteLine();
                Path = new int[100];
                _path = new List<int>();
                pathlen = 0;
                //time to print the list.
            }
            else
            {
                _path.Add(root.Data);
                Path[pathlen++] = root.Data;
                PrintPaths(root.Left, Path, pathlen);
                PrintPaths(root.Right, Path, pathlen);
            }
        }
        public void PathSum(Node root)
        {
            int sum = 0;
            List<int> output = new List<int>();
            PathSum(root, sum,ref output);
        }
        public void PathSum(Node root, int sum, ref List<int> output)
        {
            if (root == null) return;
            else if (root.Left == null && root.Right == null)
            {
                sum += root.Data;
                output.Add(sum);
                //Console.WriteLine("Path Sum {0}", sum);
                sum = 0; //reset the value once a path is printed.
            }
            else
            {
                sum += root.Data;
                PathSum(root.Left, sum,ref output);
                PathSum(root.Right, sum, ref output);
            }
        }

        public int MaxPathSum(Node root)
        {
            int sum = 0;
            int maxSum = int.MinValue;
            MaxSum(root, sum, ref maxSum);
            return maxSum;
        }
        public void MaxSum(Node root, int sum, ref int maxSum)
        {

            if (root == null) return;
            else if (root.Left == null && root.Right == null)
            {
                sum += root.Data;
                if (sum > maxSum) maxSum = sum;
                sum = 0;
            }
            else
            {
                sum += root.Data;
                MaxSum(root.Left, sum,ref maxSum);
                MaxSum(root.Right, sum,ref maxSum);
            }
        }
        public Node Mirror(Node root)
        {
            if (root == null) return root;
            else
            {
                Node temp = root.Left;
                root.Left = root.Right;
                root.Right = temp;
                root.Left = Mirror(root.Left);
                root.Right = Mirror(root.Right);
            }
            return root;
        }
        public Node DoubleTree(Node root)
        {
            if (root == null) return null;
            else
            {
                root.Left = new Node(root.Data);
                root.Left = Mirror(root.Left);
                root.Right = Mirror(root.Right);
                return root;
            }
        }
        public bool SameTree(Node rootA, Node rootB)
        {
            if (rootA == rootB == null) return true;
            else
            {
                return ((rootA.Data == rootB.Data) && SameTree(rootA.Left, rootB.Left) && SameTree(rootA.Right, rootB.Right));
            }
        }

        public bool IsBst(Node root)
        {
            int max = int.MaxValue;
            int min = int.MinValue;
            return IsBst(root, min, max);
        }
        public bool IsBst(Node root, int min, int max)
        {
            if (root == null) return true;
            else
            {
                return (root.Data > min && root.Data < max && IsBst(root.Left, min, root.Data) && IsBst(root.Right, root.Data, max));
            }
        }
        public IList<IList<int>> LevelOrder(Node root)
        {
            var output = new List<IList<int>>();
            if (root == null) return output;

            Queue<Node> Q1 = new Queue<Node>();
            Queue<Node> Q2 = new Queue<Node>();
            List<int> templist = new List<int>();
            Q1.Enqueue(root);
            while (Q1.Count > 0)
            {
                Node temp = Q1.Dequeue();
                templist.Add(temp.Data);
                if (temp.Left != null)
                    Q2.Enqueue(temp.Left);
                if (temp.Right != null)
                    Q2.Enqueue(temp.Right);
                if (Q1.Count == 0 && Q2.Count > 0)
                {
                    output.Add(templist);
                    templist = new List<int>();
                    Queue<Node> tempQ = Q1;
                    Q1 = Q2;
                    Q2 = tempQ;
                }
            }
            output.Add(templist);
            return output;
        }
        public void PrintTreeVerticalOrder(Node root)
        {
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
            int hd = 0;
            GetVerticalOrder(root, hd, ref map);

            foreach (int key in map.Keys)
            {
                foreach (int j in map[key])
                {
                    Console.Write("{0},", j);
                }
                Console.WriteLine();
            }
        }
        private void GetVerticalOrder(Node root, int hd, ref Dictionary<int, List<int>> map)
        {
            if (root == null) return;
            AddValuetoHash(root.Data, hd, ref map);
            GetVerticalOrder(root.Left, hd - 1, ref map);
            GetVerticalOrder(root.Right, hd + 1, ref map);
        }
        private void AddValuetoHash(int data, int hd, ref Dictionary<int, List<int>> map)
        {
            var templist = new List<int>();
            if (map.ContainsKey(hd))
            {
                templist = map[hd];
                templist.Add(data);
                map[hd] = templist;
            }
            else
            {
                templist = new List<int>();
                templist.Add(data);
                map.Add(hd, templist);
            }

        }

        public void PostOrderTraversalNoRecursion(Node root)
        {
            if (root == null) return;
            List<int> arrList = new List<int>();
            Stack<Node> s1 = new Stack<Node>();
            Stack<Node> s2 = new Stack<Node>();
            s1.Push(root);
            while (s1.Count > 0)
            {
                Node temp = s1.Pop();
                s2.Push(temp);
                if (temp.Right != null)
                {
                    s1.Push(temp.Right);
                }
                if (temp.Left != null)
                {
                    s1.Push(temp.Left);
                }
            }

            while (s2.Count > 0)
                arrList.Add(s2.Pop().Data);
        }
        //Given a complete binary tree, count the number of nodes.
        public int CountNodes(Node root)
        {
            if (root == null) return 0;
            int r = 0; int l = 0;
            Node temp = root;
            while (temp != null)
            {
                l++;
                temp = temp.Left;
            }
            temp = root;
            while (temp != null)
            {
                r++;
                temp = temp.Right;
            }
            if (l == r) return (int)Math.Pow(2, l) - 1;
            return CountNodes(root.Left) + CountNodes(root.Right) + 1;
        }
        //Given a binary tree, return the postorder traversal of its nodes' values.
        public IList<int> PostorderTraversalUsing2Stack(Node root)
        {
            List<int> arrList = new List<int>();
            if (root == null) return arrList;
            Stack<Node> s1 = new Stack<Node>();
            Stack<Node> s2 = new Stack<Node>();
            s1.Push(root);
            while (s1.Count > 0)
            {
                Node temp = s1.Pop();
                s2.Push(temp);
                if (temp.Left != null)
                {
                    s1.Push(temp.Left);
                }
                if (temp.Right != null)
                {
                    s1.Push(temp.Right);
                }
            }

            while (s2.Count > 0)
                arrList.Add(s2.Pop().Data);
            return arrList;
        }
        public List<int> RightSideView(Node root)
        {
            List<int> res=new List<int>();
            if (root==null)
                return res;
            Queue<Node> q=new Queue<Node>();
            q.Enqueue(root);
            int len;
            Node t=null;
            while (q.Count>0)
            {
                len = q.Count;
                for (int i = 0; i < len; ++i)
                {
                    t = q.Dequeue();
                    if (t.Left!=null)
                        q.Enqueue(t.Left);
                    if (t.Right != null)
                        q.Enqueue(t.Right);
                }
                res.Add(t.Data);
            }
            return res;
        }
        public IList<int> PreorderTraversalUsingStack(Node root)
        {
            List<int> arrList = new List<int>();
            if (root == null) return arrList;
            Stack<Node> S = new Stack<Node>();
            S.Push(root);
            while (S.Count > 0)
            {
                Node temp = S.Pop();
                arrList.Add(temp.Data);
                if (temp.Right != null)
                    S.Push(temp.Right);
                if (temp.Left != null)
                    S.Push(temp.Left);
            }
            return arrList;
        }
        //minimum depth of a binary search tree
        //The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.
        public int MinDepth(Node root)
        {
            if (root == null) return 0;
            else if (root.Left == null && root.Right == null) return 1;
            else if (root.Left == null && root.Right != null) return MinDepth(root.Right) + 1;
            else if (root.Right == null && root.Left != null) return MinDepth(root.Left) + 1;
            else
            {
                int ldepth = MinDepth(root.Left) + 1;
                int rdepth = MinDepth(root.Right) + 1;
                return Math.Min(ldepth, rdepth);
            }
        }
        /*
     *Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).
    For example, this binary tree is symmetric:

        1
       / \
      2   2
     / \ / \
    3  4 4  3
    But the following is not:
        1
       / \
      2   2
       \   \
       3    3
    Note:
    Bonus points if you could solve it both recursively and iteratively.
         */
        public bool IsSymmetric(Node root)
        {
            Queue<Node> QTree = new Queue<Node>();
            if (root == null) return true;
            QTree.Enqueue(root.Left);
            QTree.Enqueue(root.Right);
            while (QTree.Count > 0)
            {
                Node l = QTree.Dequeue();
                Node r = QTree.Dequeue();

                if (l == null && r == null) continue;
                if ((l == null && r != null) || (l != null && r == null) || (r.Data != l.Data)) return false;

                QTree.Enqueue(l.Left);
                QTree.Enqueue(r.Right);
                QTree.Enqueue(l.Right);
                QTree.Enqueue(r.Left);
            }
            return true;
        }
        //Given two binary trees, write a function to check if they are equal or not.
        //Two binary trees are considered equal if they are structurally identical and the nodes have the same value.
        public bool IsSameTree(Node p, Node q)
        {
            if (p == null && q == null) return true;
            else if ((p == null && q != null) || (p != null && q == null))
                return false;
            else
                return (p.Data == q.Data) && IsSameTree(p.Left, q.Left) && IsSameTree(p.Right, q.Right);

        }
        /*
         Given n, how many structurally unique BST's (binary search trees) that store values 1...n?

For example,
Given n = 3, there are a total of 5 unique BST's.

   1         3     3      2      1
    \       /     /      / \      \
     3     2     1      1   3      2
    /     /       \                 \
   2     1         2                 3*/

        public int NumTrees(int n)
        {
            long ans = 1, i;
            for (i = 1; i <= n; i++)
                ans = ans * (i + (long)n) / i;
            return (int)(ans / i);

        }
        /*Given a binary tree, return the inorder traversal of its nodes' values.

For example:
Given binary tree {1,#,2,3},
   1
    \
     2
    /
   3
return [1,3,2].

Note: Recursive solution is trivial, could you do it iteratively?*/

        public IList<int> InorderTraversal(Node root)
        {
            List<int> arrList = new List<int>();
            if (root == null) return arrList;
            Stack<Node> S1 = new Stack<Node>();
            bool done = false;
            Node current = root;
            while (!done)
            {
                if (current != null)
                {
                    S1.Push(current);
                    current = current.Left;
                }
                else
                {
                    if (current == null && S1.Count > 0)
                    {
                        Node temp = S1.Pop();
                        arrList.Add(temp.Data);
                        current = temp.Right;
                    }
                    else
                        done = true;
                }
            }
            return arrList;
        }
    }
}
