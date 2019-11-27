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
     * improve 1 , using Linq
     */
    public bool IsPalindrome_2(ListNode head)
    {
        if (head == null || head.next == null) return true;

        List<int> L = new List<int>();
        while (head != null)
        {
            L.Add(head.val);
            head = head.next;
        }
        if(L.Take(L.Count / 2).SequenceEqual(L.Skip(L.Count / 2 + L.Count % 2).Reverse()))
        {
            return true;
        }

        return false;
    }

    // --------------- O(n) 100ms --------------- O(1) 31.3MB --------------- (86% 10%) ※
    /*
     * using recursive , but cannot understand
     */
    public bool IsPalindrome_3(ListNode head)
    {
        ListNode temp = head;

        return IsPali(head, ref temp);
    }

    private bool IsPali(ListNode head, ref ListNode compare)
    {
        if (head == null)
        {
            return true;
        }
        else if (!IsPali(head.next,ref compare))
        {
            return false;
        }

        if (head.val != compare.val)
        {
            return false;
        }

        compare = compare.next;
        return true;
    }

    
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
 * IsPalindrome_1 IsPalindrome_3/4                                                                            *
 **************************************************************************************************************/