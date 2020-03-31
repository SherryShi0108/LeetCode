//Source  : https://leetcode.com/problems/intersection-of-two-linked-lists/
//Author  : Xinruo Shi
//Date    : 2019-10-05
//Language: C#

/*******************************************************************************************************************************
 * 
 * Write a program to find the node at which the intersection of two singly linked lists begins.
 * For example, the following two linked lists: begin to intersect at node c1.
 *
 * Input: intersectVal = 8, listA = [4,1,8,4,5], listB = [5,0,1,8,4,5], skipA = 2, skipB = 3
 * Output: Reference of the node with value = 8
 * Input Explanation: The intersected node's value is 8 (note that this must not be 0 if the two lists intersect).
 *                    From the head of A, it reads as [4,1,8,4,5]. From the head of B, it reads as [5,0,1,8,4,5].
 *                    There are 2 nodes before the intersected node in A; There are 3 nodes before the intersected node in B.
 *
 * Input: intersectVal = 2, listA = [0,9,1,2,4], listB = [3,2,4], skipA = 3, skipB = 1
 * Output: Reference of the node with value = 2
 * Input Explanation: The intersected node's value is 2 (note that this must not be 0 if the two lists intersect).
 *                    From the head of A, it reads as [0,9,1,2,4]. From the head of B, it reads as [3,2,4]. There are 3 nodes before the intersected node in A;
 *                    There are 1 node before the intersected node in B.
 *
 * Input: intersectVal = 0, listA = [2,6,4], listB = [1,5], skipA = 3, skipB = 2
 * Output: null
 * Input Explanation: From the head of A, it reads as [2,6,4]. From the head of B, it reads as [1,5].
 *                    Since the two lists do not intersect, intersectVal must be 0, while skipA and skipB can be arbitrary values.
 * Explanation: The two lists do not intersect, so return null.
 *
 * Notes:
 *      If the two linked lists have no intersection at all, return null.
 *      The linked lists must retain their original structure after the function returns.
 *      You may assume there are no cycles anywhere in the entire linked structure.
 *      Your code should preferably run in O(n) time and use only O(1) memory.
 * 
 *******************************************************************************************************************************/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */

using System.Collections.Generic;

public class Solution160
{
    // --------------- O(n) 140ms --------------- O(n) 37.9MB --------------- (42% 11%)
    /*
     *  use hashmap , so O(Space)!= O(1) 
     */
    public ListNode GetIntersectionNode_1(ListNode headA, ListNode headB)
    {
        HashSet<ListNode> H=new HashSet<ListNode>();
        ListNode temp1 = headA;
        ListNode temp2 = headB;

        while (temp1!=null)
        {
            H.Add(temp1);
            temp1 = temp1.next;
        }

        while (temp2!=null)
        {
            if (H.Contains(temp2))
            {
                return temp2;
            }
            else
            {
                temp2 = temp2.next;
            }
        }

        return null;
    }

    // --------------- O(n) 132ms --------------- O(1) 35.2MB --------------- (81% 44%)
    /*
     * reduce the linklist length , make these two in same length 
     */
    public ListNode GetIntersectionNode_2(ListNode headA, ListNode headB)
    {
        if (headA == null || headB == null)
        {
            return null;
        }

        ListNode temp1 = headA;
        ListNode temp2 = headB;
        int len1 = 0;
        int len2 = 0;
        while (temp1!=null)
        {
            len1++;
            temp1 = temp1.next;
        }

        while (temp2!=null)
        {
            len2++;
            temp2 = temp2.next;
        }

        temp1 = headA;
        temp2 = headB;
        if (len1 >= len2)
        {
            for (int i = 0; i < len1-len2; i++)
            {
                temp1 = temp1.next;
            }
        }
        else
        {
            for (int i = 0; i < len2-len1; i++)
            {
                temp2 = temp2.next;
            }
        }

        while (temp1!=null)
        {
            if (temp1 == temp2)
            {
                return temp1;
            }

            temp1 = temp1.next;
            temp2 = temp2.next;
        }

        return null;
    }

    // --------------- O(n) 136ms --------------- O(1) 35.3MB --------------- (64% 44%) ※
    /*
     * amazing solution ! this always meet because they all cross len1+len2 length
     */
    public ListNode GetIntersectionNode_3(ListNode headA, ListNode headB)
    {
        if (headA == null || headB == null) return null; // could delete
        
        ListNode temp1 = headA;
        ListNode temp2 = headB;
        while (temp1!=temp2)
        {
            temp1 = temp1 == null ? headB : temp1.next;
            temp2 = temp2 == null ? headA : temp2.next;
        }

        return temp1;
    }
}
/**************************************************************************************************************
 * GetIntersectionNode_2 GetIntersectionNode_3                                                                *
 **************************************************************************************************************/
