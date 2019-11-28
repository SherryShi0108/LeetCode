//Source  : https://leetcode.com/problems/middle-of-the-linked-list/
//Author  : Xinruo Shi
//Date    : 2019-10-10
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a non-empty, singly linked list with head node head, return a middle node of linked list.
 * If there are two middle nodes, return the second middle node.
 *
 * Input: [1,2,3,4,5]
 * Output: Node 3 from this list (Serialization: [3,4,5])
 *         The returned node has value 3.  (The judge's serialization of this node is [3,4,5]).
 *         Note that we returned a ListNode object ans, such that:
 *         ans.val = 3, ans.next.val = 4, ans.next.next.val = 5, and ans.next.next.next = NULL.
 *
 * Input: [1,2,3,4,5,6]
 * Output: Node 4 from this list (Serialization: [4,5,6]) Since the list has two middle nodes with values 3 and 4, we return the second one.
 *
 * Note: The number of nodes in the given list will be between 1 and 100.
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
public class Solution876
{
    // --------------- O(n) 92ms --------------- O(1) 23MB --------------- (70% 100%) ※
    public ListNode MiddleNode_1(ListNode head)
    {
        ListNode slow = head;
        ListNode fast = head;

        while (fast!=null&&fast.next!=null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        return slow;
    }

    // --------------- O(n) 92ms --------------- O(n) 22.8MB --------------- (70% 100%)
    public ListNode MiddleNode_2(ListNode head)
    {
        ListNode[] A=new ListNode[100];
        int t = 0;
        while (head!=null)
        {
            A[t++] = head;
            head = head.next;
        }

        return A[t / 2];
    }
}
/**************************************************************************************************************
 * MiddleNode_1                                                                                               *
 **************************************************************************************************************/