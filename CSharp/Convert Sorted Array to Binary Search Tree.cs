//Source  : https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/
//Author  : Xinruo Shi
//Date    : 2020-11-25
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given an array where elements are sorted in ascending order, convert it to a height balanced BST.
 *
 * For this problem, a height-balanced binary tree is defined as a binary tree in which the depth of the two subtrees of every node never differ by more than 1.
 *
 * Given the sorted array: [-10,-3,0,5,9],
 * One possible answer is: [0,-3,9,-10,null,5], which represents the following height balanced BST:
 *
 *              0
 *             / \
 *           -3   9
 *           /   /
 *         -10  5
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;

public class TreeNode
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
}

public class Solution108
{
    // --------------- O(n) 108ms --------------- O(logn) 25MB --------------- (40% 77%) ※
    /*
     * using Recursive /DFS
     */
    public TreeNode SortedArrayToBST_1(int[] nums)
    {
        if (nums == null || nums.Length == 0) return null;
        return GetTreeNode(nums, 0, nums.Length - 1);
    }

    private TreeNode GetTreeNode(int[] nums, int start, int end)
    {
        if (start > end) return null;

        int mid = start + (end - start) / 2;
        TreeNode node = new TreeNode(nums[mid]);
        node.left = GetTreeNode(nums, start, mid - 1);
        node.right = GetTreeNode(nums, mid + 1, end);
        return node;
    }

    // --------------- O(n) 84ms --------------- O(n) 39MB --------------- (97% 5%) 
    /*
     * using Iteration /BFS
     */
    public TreeNode SortedArrayToBST_2(int[] nums)
    {
        if (nums == null || nums.Length == 0) return null;
        TreeNode root = new TreeNode();

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        Queue<int> leftIndexStack = new Queue<int>();
        Queue<int> rightIndexStack = new Queue<int>();
        leftIndexStack.Enqueue(0);
        rightIndexStack.Enqueue(nums.Length - 1);

        while (queue.Count > 0)
        {
            TreeNode node = queue.Dequeue();
            int left = leftIndexStack.Dequeue();
            int right = rightIndexStack.Dequeue();
            int mid = left + (right - left) / 2;
            node.val = nums[mid];

            if (left <= mid - 1)
            {
                node.left = new TreeNode();
                queue.Enqueue(node.left);
                leftIndexStack.Enqueue(left);
                rightIndexStack.Enqueue(mid - 1);
            }

            if (right >= mid + 1)
            {
                node.right = new TreeNode();
                queue.Enqueue(node.right);
                leftIndexStack.Enqueue(mid + 1);
                rightIndexStack.Enqueue(right);
            }
        }

        return root;
    }
}

/**************************************************************************************************************
 *   SortedArrayToBST_1    SortedArrayToBST_1                                                                 *
 **************************************************************************************************************/
