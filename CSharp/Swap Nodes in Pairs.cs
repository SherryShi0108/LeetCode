//Source  : https://leetcode.com/problems/swap-nodes-in-pairs/
//Author  : Xinruo Shi
//Date    : 2022-05-01
//Language: C#

/*******************************************************************************************************************************
    Given a linked list, swap every two adjacent nodes and return its head. You must solve the problem without 
    modifying the values in the list's nodes (i.e., only nodes themselves may be changed.)

    Input: head = [1,2,3,4]
    Output: [2,1,4,3]

    Input: head = []
    Output: []

    Input: head = [1]
    Output: [1]

    Constraints:
        The number of nodes in the list is in the range [0, 100].
        0 <= Node.val <= 100
 ※
 *******************************************************************************************************************************/

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution24
{
    public ListNode SwapPairs(ListNode head)
    {

    }

}

/**************************************************************************************************************
 *                                                                                      *
 **************************************************************************************************************/