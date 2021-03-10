//Source  : https://leetcode.com/problems/binary-tree-tilt/
//Author  : Xinruo Shi
//Date    : 2020-11-27
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given the root of a binary tree, return the sum of every tree node's tilt.
 * The tilt of a tree node is the absolute difference between the sum of all left subtree node values and all right subtree
 * node values. If a node does not have a left child, then the sum of the left subtree node values is treated as 0.
 * The rule is similar if there the node does not have a right child.
 *
 * Input: root = [1,2,3]
 * Output: 1 ([1,0,0])
 * Explanation:
 *      Tilt of node 2 : |0-0| = 0 (no children)
 *      Tilt of node 3 : |0-0| = 0 (no children)
 *      Tile of node 1 : |2-3| = 1 (left subtree is just left child, so sum is 2; right subtree is just right child, so sum is 3)
 *      Sum of every tilt : 0 + 0 + 1 = 1
 *
 * Input: root = [4,2,9,3,5,null,7]
 * Output: 15 ([6,2,7,0,0,null,0])
 * Explanation:
 *      Tilt of node 3 : |0-0| = 0 (no children)
 *      Tilt of node 5 : |0-0| = 0 (no children)
 *      Tilt of node 7 : |0-0| = 0 (no children)
 *      Tilt of node 2 : |3-5| = 2 (left subtree is just left child, so sum is 3; right subtree is just right child, so sum is 5)
 *      Tilt of node 9 : |0-7| = 7 (no left child, so sum is 0; right subtree is just right child, so sum is 7)
 *      Tilt of node 4 : |(3+5+2)-(9+7)| = |10-16| = 6 (left subtree values are 3, 5, and 2, which sums to 10; right subtree values are 9 and 7, which sums to 16)
 *      Sum of every tilt : 0 + 0 + 0 + 2 + 7 + 6 = 15
 *
 * Input: root = [21,7,14,1,1,2,2,3,3]
 * Output: 9 ([3,6,0,0,0,0,0,0,0])
 *
 * Constraints:
 *      The number of nodes in the tree is in the range [0, 104].
 *      -1000 <= Node.val <= 1000
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

public class Solution563
{
    // --------------- O(n) 104ms --------------- O(n) 29MB --------------- (66% 16%) ※
    /*
     *  Using DFS
     */
    public int FindTilt_1(TreeNode root)
    {
        totalTilt = 0;
        ValueSum(root);
        return totalTilt;
    }

    private int totalTilt = 0;

    private int ValueSum(TreeNode node)
    {
        if (node == null)
        {
            return 0;
        }

        int leftSum = ValueSum(node.left);
        int rightSum = ValueSum(node.right);

        int tilt = leftSum - rightSum > 0 ? leftSum - rightSum : rightSum - leftSum;
        totalTilt += tilt;

        return node.val + leftSum + rightSum;
    }
}
/**************************************************************************************************************
 * FindTilt_1                                                                                                 *
 **************************************************************************************************************/