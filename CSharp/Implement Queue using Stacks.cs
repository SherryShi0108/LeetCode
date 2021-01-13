//Source  : https://leetcode.com/problems/implement-queue-using-stacks/
//Author  : Xinruo Shi
//Date    : 2020-11-04
//Language: C#

/*******************************************************************************************************************************
 * 
 * Implement a first in first out (FIFO) queue using only two stacks. The implemented queue should support all the functions of a normal queue (push, peek, pop, and empty).
 *
 * Implement the MyQueue class:
 *      void push(int x) Pushes element x to the back of the queue.
 *      int pop() Removes the element from the front of the queue and returns it.
 *      int peek() Returns the element at the front of the queue.
 *      boolean empty() Returns true if the queue is empty, false otherwise.
 *
 * Notes:
 *      You must use only standard operations of a stack, which means only push to top, peek/pop from top, size, and is empty operations are valid.
 *      Depending on your language, the stack may not be supported natively. You may simulate a stack using a list or deque (double-ended queue) as long as you use only a stack's standard operations.
 *
 * Follow-up: Can you implement the queue such that each operation is amortized O(1) time complexity? In other words,
 *            performing n operations will take overall O(n) time even if one of those operations may take longer.
 *
 * Input: ["MyQueue", "push", "push", "peek", "pop", "empty"]
 *        [[], [1], [2], [], [], []]
 * Output: [null, null, null, 1, 1, false]
 * Explanation:
 *      MyQueue myQueue = new MyQueue();
 *      myQueue.push(1); // queue is: [1]
 *      myQueue.push(2); // queue is: [1, 2] (leftmost is front of the queue)
 *      myQueue.peek(); // return 1
 *      myQueue.pop(); // return 1, queue is [2]
 *      myQueue.empty(); // return false
 *
 * Constraints:
 *      1 <= x <= 9
 *      At most 100 calls will be made to push, pop, peek, and empty.
 *      All the calls to pop and peek are valid.
 * 
 *******************************************************************************************************************************/
// class 232

using System.Collections.Generic;

// --------------- O(n) 92ms --------------- 25MB --------------- (99% 37%) 
/*
 *  using two stack : input is final stack(queue) , output is a helper , but it's a bad answer
 */
public class MyQueue1
{
    private Stack<int> input;
    private Stack<int> output;

    /** Initialize your data structure here. */
    public MyQueue1()
    {
        input = new Stack<int>();
        output = new Stack<int>();
    }

    /** Push element x to the back of queue. */
    public void Push(int x)
    {
        if (input.Count == 0)
        {
            input.Push(x);
        }
        else
        {
            while (input.Count!=0)
            {
                output.Push(input.Pop());
            }

            input.Push(x);
            while (output.Count!=0)
            {
                input.Push(output.Pop());
            }
        }
    }

    /** Removes the element from in front of queue and returns that element. */
    public int Pop()
    {
        return input.Pop();
    }

    /** Get the front element. */
    public int Peek()
    {
        return input.Peek();
    }

    /** Returns whether the queue is empty. */
    public bool Empty()
    {
        return input.Count == 0;
    }
}

// --------------- O(n) 104ms --------------- 25MB --------------- (66% 67%) ※
/*
 *  it's most votes
 */
public class MyQueue2
{
    private Stack<int> input;
    private Stack<int> output;

    /** Initialize your data structure here. */
    public MyQueue2()
    {
        input = new Stack<int>();
        output = new Stack<int>();
    }

    /** Push element x to the back of queue. */
    public void Push(int x)
    {
        input.Push(x);
    }

    /** Removes the element from in front of queue and returns that element. */
    public int Pop()
    {
        Peek();
        return output.Pop();
    }

    /** Get the front element. */
    public int Peek()
    {
        if (output.Count == 0)
        {
            while (input.Count!=0)
            {
                output.Push(input.Pop());
            }
        }

        return output.Peek();
    }

    /** Returns whether the queue is empty. */
    public bool Empty()
    {
        return input.Count == 0 && output.Count == 0;
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */
/**************************************************************************************************************
 * MyQueue2                                                                                                   *
 **************************************************************************************************************/