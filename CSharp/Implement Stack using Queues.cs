//Source  : https://leetcode.com/problems/implement-stack-using-queues/
//Author  : Xinruo Shi
//Date    : 2020-11-03
//Language: C#

/*******************************************************************************************************************************
 * 
 * Implement a last in first out (LIFO) stack using only two queues. The implemented stack should support all the functions of a normal queue (push, top, pop, and empty).
 *
 * Implement the MyStack class:
 *      void push(int x) Pushes element x to the top of the stack.
 *      int pop() Removes the element on the top of the stack and returns it.
 *      int top() Returns the element on the top of the stack.
 *      boolean empty() Returns true if the stack is empty, false otherwise.
 *
 * Notes:
 *      You must use only standard operations of a queue, which means only push to back, peek/pop from front, size, and is empty operations are valid.
 *      Depending on your language, the queue may not be supported natively. You may simulate a queue using a list or deque (double-ended queue), as long as you use only a queue's standard operations.
 *
 * Follow-up: Can you implement the stack such that each operation is amortized O(1) time complexity? In other words,
 *            performing n operations will take overall O(n) time even if one of those operations may take longer.
 *
 * Input: ["MyStack", "push", "push", "top", "pop", "empty"]
 *        [[], [1], [2], [], [], []]
 * Output: [null, null, null, 2, 2, false]
 * Explanation:
 *      MyStack myStack = new MyStack();
 *      myStack.push(1);
 *      myStack.push(2);
 *      myStack.top(); // return 2
 *      myStack.pop(); // return 2
 *      myStack.empty(); // return False
 *
 * Constraints:
 *      1 <= x <= 9
 *      At most 100 calls will be made to push, pop, top, and empty.
 *      All the calls to pop and top are valid.
 * ※
 *******************************************************************************************************************************/

// class 225

using System.Collections.Generic;

// --------------- O(n) 104ms --------------- 24MB --------------- (58% 96%) ※
/*
 *  use One Queue
 */
public class MyStack1
{
    private Queue<int> queue;
 
    /** Initialize your data structure here. */
    public MyStack1()
    {
        queue = new Queue<int>();
    }

    /** Push element x onto stack. */
    public void Push(int x)
    {
        queue.Enqueue(x);
        for (int i = 0; i < queue.Count-1; i++)
        {
            queue.Enqueue(queue.Dequeue());
        }
    }

    /** Removes the element on top of the stack and returns that element. */
    public int Pop()
    {
        return queue.Dequeue();
    }

    /** Get the top element. */
    public int Top()
    {
        return queue.Peek();
    }

    /** Returns whether the stack is empty. */
    public bool Empty()
    {
        return queue.Count == 0;
    }
}

// --------------- O(n) 104ms --------------- 25MB --------------- (58% 81%) 
/*
 *  use Two Queue
 */
public class MyStack2
{
    private Queue<int> queue1;
    private Queue<int> queue2;

    /** Initialize your data structure here. */
    public MyStack2()
    {
        queue1 = new Queue<int>();
        queue2 = new Queue<int>();
    }

    /** Push element x onto stack. */
    public void Push(int x)
    {
        if (queue1.Count == 0)
        {
            queue2.Enqueue(x);
        }
        else
        {
            queue1.Enqueue(x);
        }
    }

    /** Removes the element on top of the stack and returns that element. */
    public int Pop()
    {
        if (queue1.Count == 0)
        {
            while (queue2.Count>1)
            {
                queue1.Enqueue(queue2.Dequeue());
            }

            return queue2.Dequeue();
        }
        else
        {
            while (queue1.Count>1)
            {
                queue2.Enqueue(queue1.Dequeue());
            }

            return queue1.Dequeue();
        }
    }

    /** Get the top element. */
    public int Top()
    {
        int peek = Pop();
        if (queue1.Count == 0)
        {
            queue2.Enqueue(peek);
        }
        else
        {
            queue1.Enqueue(peek);
        }

        return peek;
    }

    /** Returns whether the stack is empty. */
    public bool Empty()
    {
        return queue1.Count == 0 && queue2.Count == 0;
    }
}

/**
 * Your MyStack object will be instantiated and called as such:
 * MyStack obj = new MyStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * bool param_4 = obj.Empty();
 */
/**************************************************************************************************************
 * MyStack1                                                                                                   *
 **************************************************************************************************************/