using System;
using System.Linq;
using System.Collections.Generic;
using Helpers;

namespace Problems
{
    class Problem43
    {
        const string PROMPT = @"This problem was asked by Amazon.

                                Implement a stack that has the following methods:

                                push(val), which pushes an element onto the stack
                                pop(), which pops off and returns the topmost element of the stack. If there are no elements in the stack, then it should throw an error or return null.
                                max(), which returns the maximum value in the stack currently. If there are no elements in the stack, then it should throw an error or return null.
                                Each method should run in constant time.";

        public void Main()
        {
            Stack stack = new Stack();
            stack.push(5);
            stack.push(7);
            stack.push(3);
            stack.push(9);
            stack.push(3);
            stack.push(1);
            stack.push(2);
            Console.WriteLine(stack.max());
            Console.WriteLine(stack.pop());
            Console.WriteLine(stack.max());
            Console.WriteLine(stack.pop());
            Console.WriteLine(stack.max());
            Console.WriteLine(stack.pop());
            Console.WriteLine(stack.max());
            Console.WriteLine(stack.pop());
            Console.WriteLine(stack.max());
            Console.WriteLine(stack.pop());
            Console.WriteLine(stack.max());
            Console.WriteLine(stack.pop());
            Console.WriteLine(stack.max());
            Console.WriteLine(stack.pop());
            Console.WriteLine(stack.max());
            Console.WriteLine(stack.pop());
            Console.WriteLine(stack.max());
            Console.WriteLine(stack.pop());
            Console.WriteLine(stack.max());
            Console.WriteLine(stack.pop());
            Console.WriteLine(stack.max());
            Console.WriteLine(stack.pop());
            Console.ReadLine();
        } 
    }

    class Stack 
    {
        public Stack() {
            LastItem = null;
            MaxValue = 0;
        }

        public int MaxValue;
        public StackItem LastItem;
        
        public void push(int val) {
            if (val > MaxValue) MaxValue = val;
            LastItem = new StackItem(val, LastItem, MaxValue);
        }

        public bool pop() {
            if (LastItem == null) return false;
            LastItem = LastItem.PrevItem;
            MaxValue = LastItem.MaxVal;
            return true;
        }

        public int max() {
            return MaxValue;
        }
    }

    class StackItem
    {
        public int Val;
        public StackItem PrevItem;
        public int MaxVal;

        public StackItem(int input, StackItem prevItemInput, int maxVal) {
            Val = input;
            PrevItem = prevItemInput;
            MaxVal = maxVal;
        }
    }
}
