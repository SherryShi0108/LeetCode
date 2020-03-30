//Source  : https://leetcode.com/problems/palindrome-linked-list/
//Author  : Xinruo Shi
//Date    : 2019-09-23
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a singly linked list, determine if it is a palindrome.
 *
 * Input: 1->2
 * Output: false
 *
 * Input: 1->2->2->1
 * Output: true
 *
 * Follow up: Could you do it in O(n) time and O(1) space?
 * 
 *******************************************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */

public class Solution234
{
    // --------------- O(n) 96ms --------------- O(n) 27.8MB --------------- (96% 30%) 
    /*
     * easy-understanding , but space = O(n)
     */
    public bool IsPalindrome_1(ListNode head)
    {
        if (head == null || head.next == null) return true;

        List<int> L = new List<int>();
        while (head!=null)
        {
            L.Add(head.val);
            head = head.next;
        }

        int[] temp = L.ToArray();
        for (int i = 0; i < temp.Length/2; i++)
        {
            if (temp[i] != temp[temp.Length - 1 - i])
            {
                return false;
            }
        }

        return true;
    }

    // --------------- O(n) 96ms --------------- O(n) 27.8MB --------------- (96% 30%) 
    /*
     * improve 1 , using stack
     */
    public bool IsPalindrome_2(ListNode head)
    {
        Stack<int> s=new Stack<int>();
        ListNode temp = head;

        while (temp != null)
        {
            s.Push(temp.val);
            temp = temp.next;
        }

        temp = head;
        while (temp!=null)
        {
            if (temp.val != s.Pop()) return false;
            temp = temp.next;
        }

        return true;
    }
    
    

    // --------------- O(n) 100ms --------------- O(1) 31.3MB --------------- (80% 10%) ※
    /*
     * using fase/slow , find middle , then reverse slow 
     */
    public bool IsPalindrome_3(ListNode head)
    {
         ListNode fast = head;
         ListNode slow = head;
         while (fast!=null && fast.next!=null)
         {
             slow = slow.next;
             fast = fast.next.next;
         }

         ListNode newhead= ReverseListNode(slow);
         ListNode temp = head;
         while (newhead!=null)
         {
             if (newhead.val != temp.val)
             {
                 return false;
             }

             newhead = newhead.next;
             temp = temp.next;
         }

         return true;
    }

    ListNode ReverseListNode(ListNode head)
    {
        if (head == null) return head;

        ListNode temp = head;
        ListNode pre = null;
        ListNode newHead = head;
        while (temp!=null)
        {
            temp = temp.next;
            newHead.next = pre;
            pre = newHead;
            newHead = temp;
        }

        return pre;
    }
    
    // --------------- O(n) ms --------------- O(1) MB --------------- (% %)
    /*
     * using recursive , but cannot understand
     */
    public bool IsPalindrome_4(ListNode head)
    {
        if (head == null || head.next == null)
        {
            return true;
        }

        int length = GetLinkedListLength(head);
        ListNode front = GetNodeGivenK(head, length / 2);
        if (length % 2 != 0)
        {
            front = front.next;
        }

        ListNode reversed = ReverseLinkList(front);
        int index = 0;
        ListNode back = head;
        while (index<length/2)
        {
            if (back.val != reversed.val)
            {
                return false;
            }

            back = back.next;
            reversed = reversed.next;
            index++;
        }

        return true;
    }

    private ListNode ReverseLinkList(ListNode head)
    {
        if (head == null || head.next == null)
        {
            return head;
        }

        ListNode next = head.next;
        ListNode reserved = ReverseLinkList(next);

        head.next = null;
        next.next = head;

        return reserved;
    }

    private ListNode GetNodeGivenK(ListNode head, int k)
    {
        int index = 0;
        ListNode temp = head;
        while (index<k)
        {
            index++;
            temp = temp.next;
        }

        return temp;
    }

    private int GetLinkedListLength(ListNode head)
    {
        int index = 0;
        ListNode temp = head;
        while (temp!=null)
        {
            index++;
            temp = temp.next;
        }

        return index;
    }
}
/**************************************************************************************************************
 * IsPalindrome_2 IsPalindrome_3                                                                              *
 **************************************************************************************************************/
