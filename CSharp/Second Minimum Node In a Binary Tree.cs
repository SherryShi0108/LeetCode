//Source  : https://leetcode.com/problems/second-minimum-node-in-a-binary-tree/
//Author  : Xinruo Shi
//Date    : 2020-11-29
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a non-empty special binary tree consisting of nodes with the non-negative value, where each node in this tree has exactly
 * two or zero sub-node. If the node has two sub-nodes, then this node's value is the smaller value among its two sub-nodes.
 * More formally, the property root.val = min(root.left.val, root.right.val) always holds.
 *
 * Given such a binary tree, you need to output the second minimum value in the set made of all the nodes' value in the whole tree.
 *
 * If no such second minimum value exists, output -1 instead.
 *
 * Input:             2
 *                   / \
 *                  2    5
 *                      / \
 *                     5   7
 * root = [2,2,5,null,null,5,7]
 * Output: 5
 * Explanation: The smallest value is 2, the second smallest value is 5.
 *
 * Input:             2
 *                   / \
 *                  2    2                     
 * root = [2,2,2]
 * Output: -1
 * Explanation: The smallest value is 2, but there isn't any second smallest value.
 *
 * Constraints:
 *      The number of nodes in the tree is in the range [1, 25].
 *      1 <= Node.val <= 231 - 1
 *      root.val == min(root.left.val, root.right.val) for each internal node of the tree.
 *
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

public class Solution671
{
    public int FindSecondMinimumValue(TreeNode root)
    {
        if (root == null || root.left == null) return -1;

        if (root.right.val == root.left.val)
        {
            return -1;
        }
        else
        {
            return root.left.val > root.right.val ? root.left.val : root.right.val;
        }
    }

    // [3,3,1,6,2,1]
}