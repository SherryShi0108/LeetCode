//Source  : https://leetcode.com/problems/univalued-binary-tree/
//Author  : Xinruo Shi
//Date    : 2020-11-22
//Language: C#

/*******************************************************************************************************************************
 * 
 * A binary tree is univalued if every node in the tree has the same value.
 * Return true if and only if the given tree is univalued.
 *
 * Input: [1,1,1,1,1,null,1]
 *              1
 *             / \
 *            1   1
 *           / \   \
 *          1  1    1
 * Output: true
 *
 * Input: [2,2,2,5,2]
 *              2
 *             / \
 *            2   2
 *           / \  
 *          5  2 
 * Output: false
 *
 * Note:
 *      The number of nodes in the given tree will be in the range [1, 100].
 *      Each node's value will be an integer in the range [0, 99].
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;

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

public class Solution965
{
    // --------------- O(n) 92ms --------------- O(n) 25MB --------------- (71% 31%) 
    /*
     *  Using Recursion
     */
    public bool IsUnivalTree_1(TreeNode root)
    {
        if (root == null || root.left == null && root.right == null)
        {
            return true;
        }

        if (root.left != null && root.left.val != root.val
            || root.right != null && root.right.val != root.val)
        {
            return false;
        }

        return IsUnivalTree_1(root.left) && IsUnivalTree_1(root.right);
    }

    // --------------- O(n) 84ms --------------- O(n) 25MB --------------- (98% 89%) ※ 
    /*
     * Improve 1
     */
    public bool IsUnivalTree_1_2(TreeNode root)
    {
        return (root.left == null || root.left.val == root.val && IsUnivalTree_1_2(root.left))
               && (root.right == null || root.right.val == root.val && IsUnivalTree_1_2(root.right));
    }

    // --------------- O(n) 96ms --------------- O(n) 25MB --------------- (47% 50%) 
    /*
     *  Straight Forward: Using Global Variable
     */
    public bool IsUnivalTree_2(TreeNode root)
    {
        if (root == null)
        {
            return true;
        }

        if (val < 0)
        {
            val = root.val;
        }

        return root.val == val && IsUnivalTree_2(root.left) && IsUnivalTree_2(root.right);
    }
    private int val = -1;

    // --------------- O(n) 88ms --------------- O(n) 25MB --------------- (92% 31%) 
    /*
     *  Using DFS
     */
    public bool IsUnivalTree_3(TreeNode root)
    {
        DFS(root);
        HashSet<int> h=new HashSet<int>(_vals);
        return h.Count == 1 || h.Count==0;
    }

    private List<int> _vals = new List<int>();

    private void DFS(TreeNode node)
    {
        if (node != null)
        {
            _vals.Add(node.val);
            DFS(node.left);
            DFS(node.right);
        }
    }
}
/**************************************************************************************************************
 * IsUnivalTree_1_2  IsUnivalTree_2  IsUnivalTree_3                                                           *
 **************************************************************************************************************/