//Source  : https://leetcode.com/problems/merge-k-sorted-lists/
//Author  : Xinruo Shi
//Date    : 2022-05-01
//Language: C#

/*******************************************************************************************************************************
    You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.
    Merge all the linked-lists into one sorted linked-list and return it.
   
    Input: lists = [[1,4,5],[1,3,4],[2,6]]
    Output: [1,1,2,3,4,4,5,6]
    Explanation: The linked-lists are:
        [
             1->4->5,
             1->3->4,
             2->6
         ]
        merging them into one sorted list:   1->1->2->3->4->4->5->6
     
    Input: lists = []
    Output: []
   
    Input: lists = [[]]
    Output: []
   
    Constraints:
        k == lists.length
        0 <= k <= 104
        0 <= lists[i].length <= 500
        -10^4 <= lists[i][j] <= 10^4
        lists[i] is sorted in ascending order.
        The sum of lists[i].length will not exceed 104.

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

public class Solution23
{
    public ListNode MergeKLists(ListNode[] lists)
    {

    }

}

/**************************************************************************************************************
 *                                                                                      *
 **************************************************************************************************************/