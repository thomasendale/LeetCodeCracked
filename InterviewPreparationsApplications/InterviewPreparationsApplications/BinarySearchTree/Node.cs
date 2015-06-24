using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparationsApplications.BinarySearchTree
{
    public class Node
    {
      
        public Node (int data)
       {
          this.Data = data;
       }
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }
}
