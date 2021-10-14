//Source  : https://leetcode.com/problems/same-tree/
//Author  : Xinruo Shi
//Date    : 2020-11-20
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given two binary trees, write a function to check if they are the same or not.
 *
 * Two binary trees are considered the same if they are structurally identical and the nodes have the same value.
 *
 * Input:     1         1
 *           / \       / \
 *          2   3     2   3
 *         [1,2,3],   [1,2,3]
 *
 * Output: true
 *
 * Input:     1         1
 *           /           \
 *          2             2
 *        [1,2],     [1,null,2]
 *
 * Output: false
 *
 * Input:     1         1
 *           / \       / \
 *          2   1     1   2
 *         [1,2,1],   [1,1,2]
 *
 * Output: false
 * 
 *******************************************************************************************************************************/

//public class TreeNode
//{
//    public int val;
//    public TreeNode left;
//    public TreeNode right;

//    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
//    {
//        this.val = val;
//        this.left = left;
//        this.right = right;
//    }
//}

using System.Collections.Generic;

public class Solution100
{
    // --------------- O(n) 212ms --------------- O(logn) 25MB --------------- (5% 31%) ※ 
    /*
     * Recursive
     */
    public bool IsSameTree_1(TreeNode p, TreeNode q)
    {
        if (p == null && q == null) return true;
        if (p == null || q == null) return false;  // if (p == null || q == null) return p == q;
        if (p.val != q.val) return false;

        return IsSameTree_1(p.left, q.left) && IsSameTree_1(p.right, q.right);
    }

    // --------------- O(n) 139ms --------------- O(logn) 25MB --------------- (23% 96%) 
    /*
     * Iteration: using one queue
     */
    public bool IsSameTree_2(TreeNode p, TreeNode q)
    {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(p);
        queue.Enqueue(q);

        while (queue.Count > 0)
        {
            p = queue.Dequeue();
            q = queue.Dequeue();

            if (p == null && q == null) continue;
            if (p == null || q == null || p.val != q.val) return false;

            queue.Enqueue(p.left);
            queue.Enqueue(q.left);
            queue.Enqueue(p.right);
            queue.Enqueue(q.right);
        }

        return true;
    }

    // --------------- O(n) 121ms --------------- O(logn) 25MB --------------- (31% 96%) 
    /*
     * using string to compare
     */
    public bool IsSameTree_3(TreeNode p, TreeNode q)
    {
        return recurse(p) == recurse(q);
    }

    private string recurse(TreeNode node)
    {
        if (node == null) return "null";
        string s = "";
        s += node.val + ";";
        s += recurse(node.left);
        s += recurse(node.right);
        return s;
    }
}

/**************************************************************************************************************
 *   IsSameTree_1  IsSameTree_2                                                                                *
 **************************************************************************************************************/
