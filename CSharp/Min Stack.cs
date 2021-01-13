//Source  : https://leetcode.com/problems/min-stack/
//Author  : Xinruo Shi
//Date    : 2020-11-02
//Language: C#

/*******************************************************************************************************************************
 * 
 * Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.
 *      push(x) -- Push element x onto stack.
 *      pop() -- Removes the element on top of the stack.
 *      top() -- Get the top element.
 *      getMin() -- Retrieve the minimum element in the stack.
 *
 * Input: ["MinStack","push","push","push","getMin","pop","top","getMin"]
 *        [[],[-2],[0],[-3],[],[],[],[]]
 *
 * Output: [null,null,null,null,-3,null,0,-2]
 *
 * Explanation
 *      MinStack minStack = new MinStack();
 *      minStack.push(-2);
 *      minStack.push(0);
 *      minStack.push(-3);
 *      minStack.getMin(); // return -3
 *      minStack.pop();
 *      minStack.top();    // return 0
 *      minStack.getMin(); // return -2
 *
 * Constraints: Methods pop, top and getMin operations will always be called on non-empty stacks.
 * 
 *******************************************************************************************************************************/
// class 155

using System.Collections.Generic;

// --------------- O(n) 136ms --------------- 36MB --------------- (46% 77%) ※
/*
 *  This is what exactly the interviewer want, design a stack by yourself.
 */
public class MinStack1
{
    private NodeT head;

    /** initialize your data structure here. */
    public MinStack1()
    {
       
    }

    public void Push(int x)
    {
        if (head == null)
        {
            head = new NodeT(x, x, null);
        }
        else
        {
            int temp = x < head._min ? x : head._min;
            head = new NodeT(x, temp, head);
        }
    }

    public void Pop()
    {
        head = head._next;
    }

    public int Top()
    {
        return head._val;
    }

    public int GetMin()
    {
        return head._min;
    }
}

public class NodeT
{
    public int _val;
    public int _min;
    public NodeT _next;

    public NodeT(int val, int min, NodeT next)
    {
        _val = val;
        _min = min;
        _next = next;
    }
}

// --------------- O(n) 112ms --------------- 35MB --------------- (100% 92%) 
/*
 *  It is Not different from using two stack, takes almost as much space
 */
public class MinStack2
{
    private Stack<int> stack;
    private int min;

    /** initialize your data structure here. */
    public MinStack2()
    {
        stack = new Stack<int>();
        min = int.MaxValue;
    }

    public void Push(int x)
    {
        if (x <= min)
        {
            stack.Push(min);
            min = x;
        }

        stack.Push(x);
    }

    public void Pop()
    {
        int peek = stack.Pop();
        if (peek == min)
        {
            min = stack.Pop();
        }
    }

    public int Top()
    {
        return stack.Peek();
    }

    public int GetMin()
    {
        return min;
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(x);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */
/**************************************************************************************************************
* MinStack1                                                                                                   *
**************************************************************************************************************/