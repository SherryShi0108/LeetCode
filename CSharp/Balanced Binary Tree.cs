//Source  : https://leetcode.com/problems/balanced-binary-tree/
//Author  : Xinruo Shi
//Date    : 2021-10-11
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a binary tree, determine if it is height-balanced.
 * For this problem, a height-balanced binary tree is defined as:
 *      a binary tree in which the left and right subtrees of every node differ in height by no more than 1.
 *
 * Input: root = [3,9,20,null,null,15,7]
 * Output: true
 *
 * Input: root = [1,2,2,3,3,null,null,4,4]
 * Output: false
 *
 * Input: root = []
 * Output: true
 *
 * Constraints:
 *      The number of nodes in the tree is in the range [0, 5000].
 *      -10^4 <= Node.val <= 10^4
 * ※
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

public class Solution110
{
    // --------------- O(n) 160ms --------------- O(n) 28MB --------------- (18% 89%) 
    /*
     * using Recursive
     */
    public bool IsBalanced_1(TreeNode root)
    {
        if (root == null) return true;

        return Math.Abs(TreeDepth(root.left) - TreeDepth(root.right)) <= 1
               && IsBalanced_1(root.left) && IsBalanced_1(root.right);
    }

    private int TreeDepth(TreeNode root)
    {
        if (root == null) return 0;
        return 1 + Math.Max(TreeDepth(root.left), TreeDepth(root.right));
    }

    // --------------- O(n) 125ms --------------- O(n) 28MB --------------- (30% 42%) 
    /*
     * using Recursive
     */
    public bool IsBalanced_2(TreeNode root)
    {
        if (root == null) return true;
        return Diff(root) != -1;
    }

    private int Diff(TreeNode root)
    {
        if (root == null) return 0;
        int left = Diff(root.left);
        int right = Diff(root.right);
        int bf = Math.Abs(left - right);
        if (bf > 1 || left == -1 || right == -1) return -1;

        return Math.Max(left, right) + 1;
    }
}

/**************************************************************************************************************
 *  IsBalanced_1  IsBalanced_2                                                                                *
 **************************************************************************************************************/
