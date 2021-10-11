//Source  : https://leetcode.com/problems/symmetric-tree/
//Author  : Xinruo Shi
//Date    : 2020-11-21
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).
 *
 * For example, this binary tree [1,2,2,3,4,4,3] is symmetric:
 *              1
 *             / \
 *            2   2
 *           / \ / \
 *          3  4 4  3
 *
 * But the following [1,2,2,null,3,null,3] is not:
 *
 *              1
 *             / \
 *            2   2
 *             \   \
 *             3    3
 *
 * Follow up: Solve it both recursively and iteratively.
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


using System;
using System.Collections.Generic;

public class Solution101
{
    // --------------- O(n) 100ms --------------- O(n) 26MB --------------- (38% 41%) 
    /*
     *  Using Iteration：Queue
     */
    public bool IsSymmetric_1(TreeNode root)
    {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        queue.Enqueue(root);

        while (queue.Count!=0)
        {
            TreeNode node1 = queue.Dequeue();
            TreeNode node2 = queue.Dequeue();

            if (node1 == null && node2 == null) continue;
            if (node1 == null || node2 == null || node1.val!=node2.val) return false;

            queue.Enqueue(node1.left);
            queue.Enqueue(node2.right);
            queue.Enqueue(node1.right);
            queue.Enqueue(node2.left);
        }

        return true;
    }

    // --------------- O(n) 92ms --------------- O(n) 26MB --------------- (82% 25%) ※
    /*
     *  Using Recursive
     */
    public bool IsSymmetric_2(TreeNode root)
    {
        return IsMirror(root, root);
        
        // if (root == null) return true;
        // return IsMirror(root.left, root.right);
    }

    private bool IsMirror(TreeNode node1, TreeNode node2)
    {
        if (node1 == null && node2 == null) return true;
        if (node1 == null || node2 == null ) return false;

        return node1.val == node2.val && IsMirror(node1.left, node2.right) && IsMirror(node1.right, node2.left);
    }

    // Improve2
    private bool IsMirror2(TreeNode node1, TreeNode node2)
    {
        if (node1 == null || node2 == null)
        {
            return node1 == node2;
        }

        if (node1.val != node2.val)
        {
            return false;
        }

        return IsMirror2(node1.left, node2.right) && IsMirror2(node1.right, node2.left);
    }
}
/**************************************************************************************************************
 * IsSymmetric_1  IsSymmetric_2                                                                               *
 **************************************************************************************************************/
