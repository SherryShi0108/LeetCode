//Source  : https://leetcode.com/problems/maximum-depth-of-binary-tree/
//Author  : Xinruo Shi
//Date    : 2020-11-22
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a binary tree, find its maximum depth.
 * The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
 *
 * Note: A leaf is a node with no children.
 *
 * Given binary tree [3,9,20,null,null,15,7],
 *              3
 *             / \
 *            9  20
 *              /  \
 *             15   7
 *
 * return its depth = 3.
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

public class Solution104
{
    // --------------- O(n) 131ms --------------- O(logn) 26MB --------------- (30% 72%) 
    /*
     * using Recursive /DFS
     */
    public int MaxDepth_1(TreeNode root)
    {
        if (root == null) return 0;
        return 1 + Math.Max(MaxDepth_1(root.left), MaxDepth_1(root.right));
    }

    // --------------- O(n) 164ms --------------- O(n) 26MB --------------- (13% 72%) ※
    /*
     * using Iteration /BFS
     */
    public int MaxDepth_2(TreeNode root)
    {
        if (root == null) return 0;

        int result = 0;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int n = queue.Count;
            while (n-- > 0)
            {
                TreeNode node = queue.Dequeue();

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }

            result++;
        }

        return result;
    }
}
/**************************************************************************************************************
 *   MaxDepth_1  MaxDepth_2                                                                                   *
 **************************************************************************************************************/
