using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparationsApplications.LinkedList
{
    public class LinkedList
    {
        private int data;
        private LinkedList next;

        public LinkedList (int data)
        {
            this.data = data;
            this.next = null;
        }
        public LinkedList Next { get { return next; } set { next = value; } }
        public int Data { get { return data; } set { data = value; } }

    }
}
