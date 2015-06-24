using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparationsApplications.Generic
{
    class StackImplementation
    {
        List<int> Stack = new List<int>();
        List<int> minStack = new List<int>();
        /*Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.
        push(x) -- Push element x onto stack.
        pop() -- Removes the element on top of the stack.
        top() -- Get the top element.
        getMin() -- Retrieve the minimum element in the stack.*/


        public void Push(int x)
        {
            if (Stack.Count == 0)
                minStack.Add(0);
            else
            {
                int size = minStack.Count;
                if (x < Stack[minStack[size - 1]])
                    minStack.Add(Stack.Count);
                else
                    minStack.Add(minStack[size - 1]);
            }
            Stack.Add(x);
        }
        public void Pop()
        {
            minStack.RemoveAt(minStack.Count - 1);
            Stack.RemoveAt(Stack.Count - 1);
        }

        public int Top()
        {
            return Stack[Stack.Count - 1];
        }

        public int GetMin()
        {
            return Stack[minStack[minStack.Count - 1]];
        }


    }
}
