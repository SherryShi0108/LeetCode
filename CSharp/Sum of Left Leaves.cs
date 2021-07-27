//Source  : https://leetcode.com/problems/sum-of-left-leaves/
//Author  : Xinruo Shi
//Date    : 2020-11-29
//Language: C#

/*******************************************************************************************************************************
 * 
 * Find the sum of all left leaves in a given binary tree.
 *
 *              3
 *             / \
 *            9  20
 *              /  \
 *             15   7
 * There are two left leaves in the binary tree, with values 9 and 15 respectively. Return 24.
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

public class Solution404
{
    // --------------- O(n) 96ms --------------- O(n) 25MB --------------- (55% 57%) 
    /*
     *  Using Iterative : Queue
     */
    public int SumOfLeftLeaves_1(TreeNode root)
    {
        if (root == null) return 0;
        int sum = 0;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count!=0)
        {
            TreeNode node = queue.Dequeue();
            if (node.left != null)
            {
                if (node.left.left == null && node.left.right == null)
                {
                    sum += node.left.val;
                }
                else
                {
                    queue.Enqueue(node.left);
                }
            }

            if (node.right != null)
            {
                if (node.right.left != null || node.right.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
        }

        return sum;
    }

    // --------------- O(n) 88ms --------------- O(n) 25MB --------------- (91% 91%) ※
    /*
     *  Using Recursive 
     */
    public int SumOfLeftLeaves_2(TreeNode root)
    {
        if (root == null) return 0;
        int sum = 0;
        if (root.left != null && root.left.left == null && root.left.right == null)
        {
            sum += root.left.val;
        }
        else
        {
            sum += SumOfLeftLeaves_2(root.left);
        }

        sum += SumOfLeftLeaves_2(root.right);
        return sum;
    }
    
    // --------------- O(n) 88ms --------------- O(n) 25MB --------------- (91% 91%) ※
    /*
     *  Improve 2
     */
    public int SumOfLeftLeaves_2_2(TreeNode root)
    {
        if (root == null) return 0;
        int sum = 0;
        if (root.left != null && root.left.left == null && root.left.right == null)
        {
            sum += root.left.val;
        }
        sum += SumOfLeftLeaves_2(root.left);
        sum += SumOfLeftLeaves_2(root.right);
        
        return sum;
    }
}
/**************************************************************************************************************
 * SumOfLeftLeaves_1    SumOfLeftLeaves_2                                                                     *
 **************************************************************************************************************/
