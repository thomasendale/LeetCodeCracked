using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparationsApplications.LinkedList
{
    class LinkedListImplementation
    {

        public LinkedListImplementation() { }

        public int Size (LinkedList head)
        {
            if (head==null) return 0;
            int count=0;
            while (head!=null)
            {
                head = head.Next;
                count++;
            }
            return count;
        }
        public void Print (LinkedList head)
        {
            if (head==null) return;
            string temp = string.Empty;
            while (head!=null)
            {
                temp = string.Concat(temp,head.Data, ",");
                head = head.Next;
            }
            Console.Write(temp.TrimEnd(','));
            Console.WriteLine();
        }
        public LinkedList BuildSampleList()
        {
            LinkedList head = new LinkedList(1);
            head.Next = new LinkedList(2);
            head.Next.Next = new LinkedList(3);
            return head;
        }

        public void Push (ref LinkedList head, int newData)
        {
            LinkedList temp = new LinkedList(newData);
            if (head == null) head = temp;
            else
            {
                temp.Next = head;
                head = temp;
            }
        }
        public void PushAtTail(ref LinkedList head, int newData)
        {
            LinkedList temp=new LinkedList(newData);
            if (head == null) head = temp;
            else 
            {
                LinkedList current=head;
                while (current.Next!=null)
                {
                    current = current.Next;
                }
                current.Next = temp;
                temp.Next = null;
            }
        }
        //Question -1, write a function that counts the number of times a value is repeated in a given list
        public int CountNumberOfOccurance(LinkedList head, int ValueToCheck)
        {
            if (head == null) return 0;

            LinkedList current = head;
            int count = 0;
            while ( current!=null)
            {
                if (current.Data == ValueToCheck)
                    count++;
                current = current.Next;
            }
            return count;
        }
        //Question-2, write a funcation which returns the data from a linked list given the index.
        public int GetNth (LinkedList head, int index)
        {
            if (head == null) return -1; //invalid list

            LinkedList current = head;
            int count =0; 
            while (current !=null )
            {
                if (count == index) return current.Data;
                count++;
                current = current.Next;
            }
            return -1;
        }
        //Question-3 write a function which deletes the list and deallocates all of the memory.
        public void DeleteList (ref LinkedList head)
        {
            if (head == null) return;
            LinkedList current = head;
            LinkedList temp = head;

            while (current!=null)
            {
                temp = current.Next;
                current = null;
                current = temp; 
            }
            head = current;
        }
        //Question-4 write a function, given a non empty linked list, it will delte the head node and return the data value.
        public int Pop(ref LinkedList head)
        {
            if (head == null) return -1;
            LinkedList current = head;
            int headValue = current.Data;
            head = current.Next;
            current = null;
            return headValue;
        }
        //Question-5 given a list and index Nth, write a function to insert a data at the Nth location.
        public void InsertNth(ref LinkedList head, int index, int newData)
        {
            LinkedList current = head;
            LinkedList prev = head;
            LinkedList tempNode = new LinkedList(newData);
            if (index == 0)
            {
                    head = tempNode;
                    tempNode.Next = current;
                    return;
            }
            for (int i = 0; i < index;i++)
            {
                if(current!=null)
                {
                    prev = current;
                    current = current.Next;
                }
                if(i<index && current==null)
                {
                    Console.WriteLine("invalid Index or index is out of the boundary of the list");
                    return;
                }
             }
                prev.Next = tempNode;
                tempNode.Next = current;
         }
        //Question-6 Sorted insert - write a function given a sorted list and given node, inserted in list in the right place.

        public void SortedInsert (ref LinkedList head, int newData)
        {
            LinkedList tempNode = new LinkedList(newData);
            LinkedList  prev=head;
            LinkedList current = head;
            if (head == null)
            {
                head = tempNode;
                return;
            }
            if(head!=null && head.Data>newData)
            {
                head = tempNode;
                tempNode.Next = current;
                return;
            }
            while (current!=null && current.Data<=newData)
            {
                prev = current;
                current = current.Next;
            }
            prev.Next = tempNode;
            tempNode.Next = current;
        }
        //Question-7 Given a list use sortedInsert method to sort the list.
        public LinkedList InsertedSort (LinkedList head)
        {
            if (head == null) return null;
            LinkedList current = head; 
            LinkedList temp=null;
            while (current!=null)
            {
                SortedInsert (ref temp , current.Data);
                current = current.Next;
            }
            return temp;
        }
        //question -8 Given two lists, append one of them at the end of the other and destroy the second list

        public void Append (ref LinkedList headA, ref LinkedList headB)
        {
            if (headA == null)
                headA = headB;
            else
            {
                LinkedList current = headA;
                while (current.Next!=null)
                {
                    current = current.Next;
                }
                current.Next = headB;
                headB = null;
            }

        }
        //Question -9 Front Back split - given a list split it into two lists in the case of odd length list the first half of the list will have a bigger size than the send half.

        public void FrontBackSplit (LinkedList head, ref LinkedList headA, ref LinkedList headB)
        {
            if (head == null) return;
            int count = Size(head);

            int splitpoint = 0;
            if (count%2==1) splitpoint = (count / 2);
            else splitpoint =(count / 2)-1;
            
            LinkedList current = head; 
            for (int i=0; i<splitpoint; i++)
            {
                current = current.Next; 
            }
            headA = head;
            headB = current.Next;
            current.Next = null;
        }
        //Question-9 with slow/fast pointer implementation;
        public void FrontBackSplitVer2 (LinkedList head, ref LinkedList headA, ref LinkedList headB)
        {
            if (head == null) return;
            if (head.Next == null)
            {
                headA = head;
                headB = null;
                return;
            }
            LinkedList fast = head.Next;
            LinkedList slow = head; 

            while (fast!=null && fast.Next!=null )
            {
                fast = fast.Next;
                if (fast != null)
                {
                    fast = fast.Next;
                    slow = slow.Next;
                }
             }
            headA = head;
            headB = slow.Next;
            slow.Next = null;

        }

        //Question - 10 Remove Duplicates given a sorted list in increasing order/remove duplicates by traversing only ones.

        public void RemoveDuplicates ( ref LinkedList head)
        {
            if (head == null || head.Next == null)
                return; // there is no duplicates;

            LinkedList slow = head;
            LinkedList fast = head.Next; 
            while (fast!=null)
            {
                if ( slow.Data==fast.Data)
                {
                    
                    slow.Next  = fast.Next;
                    fast = null;
                    fast = slow.Next;
                }
                else
                {
                    slow = fast;
                    fast = fast.Next;
                }
            }
        }
        //Question-11 givent two lists, write a function which takes the second list elements and push it to the front of the first list 

        public void MoveNode (ref LinkedList headA, ref LinkedList headB)
        {
            if (headA == null)
            {
                headA = headB;
                return;
            }
            LinkedList currentA = headA;
            LinkedList currentB = headB;
            while (currentB!=null)
            {
                headA = headB;
                currentB = currentB.Next;
                headB.Next = currentA;
                currentA = headB;
                headB = currentB;
            }
        }
        //Question - 12 write a function, given a list, which will split the list in alternating manner.
        public void AlternateSplit(LinkedList head, ref LinkedList headA, ref LinkedList headB)
        {
            if (head == null) return;
            LinkedList current = head;
            LinkedList currentA = headA;
            LinkedList currentB = headB;

            while (current != null)
            {
                head = current.Next;
                headA = current;
                current.Next = currentA;
                currentA = headA;
                current = head;
                if (current != null)
                {
                    head = current.Next;
                    headB = current;
                    current.Next = currentB;
                    currentB = headB;
                    current = head;
                }
            }
        }
        //Question - 12 Shuffel merge, given two list, merge them to produce one list by taking one node at a time.

        public void ShuffelMerge (ref LinkedList head, LinkedList headA, LinkedList headB)
        {
            if (headA==null && headB==null) return;
            LinkedList current=head;
            LinkedList currentA=headA;
            LinkedList currentB=headB;

            while (currentA!=null || currentB!=null)
            {
                if (currentA!=null)
                {
                    headA=currentA.Next;
                    head=currentA;
                    currentA.Next=current;
                    current=head;
                    currentA=headA;
                }
                if (currentB!=null)
                {
                    headB=currentB.Next;
                    head=currentB;
                    currentB.Next = current;
                    current=head;
                    currentB=headB;
                }

            }
        }
        //Question-14 given two sorted list, write a function which will merge the two sorted list in to one
        public void SortedMerge ( ref LinkedList head, LinkedList headA, LinkedList headB)
        {
            if (headA == null && headB == null) return;
            LinkedList currentA = headA;
            LinkedList currentB = headB;
            LinkedList current = head;
            LinkedList tail = head;

            while (currentA!=null && currentB!=null)
            {
                 if (currentA.Data < currentB.Data)
                    {
                      if (head==null)
                      {
                        headA=currentA.Next;
                        head=currentA;
                        currentA.Next=tail;
                        tail=head; 
                        currentA=headA;
                      }
                      else 
                      {
                          headA=currentA.Next;
                          tail.Next=currentA;
                          tail=currentA;
                          currentA.Next=null;
                          currentA=headA;
                      }
                    }
                 else
                    {
                      if (head==null)
                      {
                        headB=currentB.Next;
                        head =currentB;
                        currentB.Next=tail;
                        tail=head;
                        currentB=headB;
                       }
                      else 
                      {
                          headB=currentB.Next;
                          tail.Next=currentB;
                          tail=currentB;
                          currentB.Next=null;
                          currentB=headB;
                      }
                    }
                }
                if (currentA!=null)
                {
                    tail.Next=headA;
                }
                else 
                {
                    tail.Next=headB;
                }

        }
        public LinkedList DeleteNthNodeFromLast (ref LinkedList head, int n)
       {
            if (head == null) return null;

        //    LinkedList slow = head;
        //    LinkedList fast = head;
        //    int gap=1;

        //    if (head.Next == null && n == 1) return null; 

        //    while (fast!=null && gap<n)
        //    {
        //        fast = fast.Next;
        //        gap++;
        //    }
        //    if (fast == null & gap < n)
        //        return head;

        //    while (fast.Next!=null)
        //    {
        //        fast = fast.Next;
        //        slow = slow.Next;
        //    }
        //    LinkedList temp = slow.Next;
        //    slow.Next = temp.Next;
        //    temp.Next = null;
        //    return head;
            return head;
        }

     }
}
