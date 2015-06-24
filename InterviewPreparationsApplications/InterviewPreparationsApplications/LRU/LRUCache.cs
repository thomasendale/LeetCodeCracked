using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparationsApplications.LRU
{   
    public class ListNode
    {
        public int PageNumber {get;set;}
        public ListNode Prev{get; set;}
        public ListNode Next { get; set;}
    }
    public class QueueNode
    {
        public int Count { get; set; }
        public int FrameSize { get; set; }
        public ListNode Rear{get;set;}
        public ListNode Front{get;set;}
    }
    public class Hash
    {
        public int Capacity {get; set;}
        public ListNode[] Array {get; set;}
    }
    public  class LRUCache
    {
        public ListNode NewNode(int pageNumber)
        {
            ListNode ln=new ListNode();
            ln.PageNumber=pageNumber;
            ln.Left=ln.Right=null;
           return ln;
        }
        public QueueNode CreateQueue(int frameSize)
        {
            QueueNode Q=new QueueNode();
            Q.FrameSize=frameSize;
            Q.Count=0;
            Q.Rear=Q.Front=null;
            return Q;
        }
        public Hash CreateHash(int Capacity)
        {
            Hash H=new Hash();
            H.Capacity=Capacity;
            H.Array=new ListNode[Capacity];
            //initialize the entries of the hashtabel
            for (int i = 0; i < Capacity;i++ )
            {
                H.Array[i] = null;
            }
           return H;
        }
        public bool isQueueFull(QueueNode Q)
        {
            return Q.Count == Q.FrameSize;
        }
        public bool isQueueEmpty(QueueNode Q)
        {
            return Q.Count == 0;
        }
        public void DeQueue(ref QueueNode Q)
        {
            if (isQueueEmpty(Q)) return;
            if( Q.Front==Q.Rear)
                Q.Front =  null;
                QueueNode temp = Q.Rear;
                Q.Rear = Q.Rear.Prev;
                if (Q.Rear == null)
                    Q.Rear.Next = null;
                temp = null;
                Q.Count--;
        }
    }
}
