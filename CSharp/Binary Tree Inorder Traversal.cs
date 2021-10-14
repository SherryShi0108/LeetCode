//Source  : https://leetcode.com/problems/binary-tree-inorder-traversal/
//Author  : Xinruo Shi
//Date    : 2021-10-01
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given the root of a binary tree, return the inorder traversal of its nodes' values.
 *
 * Input: root = [1,null,2,3]
 * Output: [1,3,2]
 *
 * Input: root = []
 * Output: []
 *
 * Input: root = [1]
 * Output: [1]
 *
 * Input: root = [1,2]
 * Output: [2,1]
 *
 * Input: root = [1,null,2]
 * Output: [1,2]
 *
 * Constraints:
 *      The number of nodes in the tree is in the range [0, 100].
 *      -100 <= Node.val <= 100
 *
 * Follow up: Recursive solution is trivial, could you do it iteratively?
 * 
 *******************************************************************************************************************************/

/* public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}*/

using System.Collections.Generic;

public class Solution94
{
    // --------------- O(n) 112ms --------------- O(logn) 41MB --------------- (100% 5%) 
    /*
     * using Recursive
     */
    public IList<int> InorderTraversal_1(TreeNode root)
    {
        List<int> result = new List<int>();
        Helper(root, result);
        return result;
    }

    private void Helper(TreeNode node, List<int> result)
    {
        if (node != null)
        {
            if (node.left != null)
            {
                Helper(node.left, result);
            }

            result.Add(node.val);

            if (node.right != null)
            {
                Helper(node.right, result);
            }
        }
    }

    // --------------- O(n) 120ms --------------- O(n) 41MB --------------- (99% 5%) ※
    /*
     * Iterating method using Stack
     */
    public IList<int> InorderTraversal_2(TreeNode root)
    {
        List<int> result = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode temp = root;
        while (temp != null || stack.Count > 0)
        {
            while (temp != null)
            {
                stack.Push(temp);
                temp = temp.left;
            }

            temp = stack.Pop();
            result.Add(temp.val);
            temp = temp.right;
        }

        return result;
    }

    // --------------- O(n) 112ms --------------- O(n) 40MB --------------- (100% 5%) 
    /*
     * Morris Traversal
     */
    public IList<int> InorderTraversal_3(TreeNode root)
    {
        List<int> result = new List<int>();
        TreeNode curr = root;
        TreeNode pre;
        while (curr != null)
        {
            if (curr.left == null)
            {
                result.Add(curr.val);
                curr = curr.right;
            }
            else
            {
                pre = curr.left;
                while (pre.right!=null)
                {
                    pre = pre.right;
                }

                pre.right = curr;
                TreeNode temp = curr;
                curr = curr.left;
                temp.left = null;
            }
        }

        return result;
    }
}

/**************************************************************************************************************
 *   InorderTraversal_1 / 2 / 3                                                                               *
 **************************************************************************************************************/
