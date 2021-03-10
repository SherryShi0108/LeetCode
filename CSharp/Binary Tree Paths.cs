//Source  : https://leetcode.com/problems/binary-tree-paths/
//Author  : Xinruo Shi
//Date    : 2020-11-25
//Language: C#

/*******************************************************************************************************************************
 * 
 * Given a binary tree, return all root-to-leaf paths.
 *
 * Note: A leaf is a node with no children.
 *
 * Input:
 *              1
 *            /   \
 *           2     3
 *            \
 *             5
 *
 * Output: ["1->2->5", "1->3"]
 * Explanation: All root-to-leaf paths are: 1->2->5, 1->3
 * 
 *******************************************************************************************************************************/

using System.Collections.Generic;
using System.Linq;

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

public class Solution257
{
    // --------------- O(n) 248ms --------------- O(n) 32MB --------------- (67% 35%) 
    public IList<string> BinaryTreePaths_1(TreeNode root)
    {
        List<string> result = new List<string>();
        if (root != null)
        {
            SearchBT(root, "", result);
        }

        return result;
    }

    public void SearchBT(TreeNode node, string path, List<string> result)
    {
        if (node.left == null && node.right == null)
        {
            result.Add(path + node.val);
        }

        if (node.left != null)
        {
            SearchBT(node.left, $"{path}{node.val}->", result);
        }

        if (node.right != null)
        {
            SearchBT(node.right, $"{path}{node.val}->", result);
        }
    }

    // --------------- O(n) 348ms --------------- O(n) 32MB --------------- (7% 35%) 
    public IList<string> BinaryTreePaths_1_2(TreeNode root)
    {
        List<string> result = new List<string>();
        BuildPath(root, "", result);
        return result;
    }

    private void BuildPath(TreeNode node, string path, List<string> result)
    {
        if (node == null) return;

        path += node.val;
        if (node.left == null && node.right == null)
        {
            result.Add(path);
        }
        else
        {
            path += "->";
            BuildPath(node.left, path, result);
            BuildPath(node.right, path, result);
        }
    }

    // --------------- O(n) 300ms --------------- O(n) 33MB --------------- (11% 8%)
    public IList<string> BinaryTreePaths_1_3(TreeNode root)
    {
        List<string> result = new List<string>();
        BinaryTreeHelper(root);
        return result;

        void BinaryTreeHelper(TreeNode node, string path = "")
        {
            if (node == null)
            {
                return;
            }

            if (node.left == null && node.right == null)
            {
                result.Add($"{path}{node.val}");
            }
            else
            {
                BinaryTreeHelper(node.left, $"{path}{node.val}->");
                BinaryTreeHelper(node.right, $"{path}{node.val}->");
            }
        }
    }

    // --------------- O(n) 456ms --------------- O(n) 33MB --------------- (5% 8%)
    /*
     *  Using Linq
     */
    public IList<string> BinaryTreePaths_1_4(TreeNode root)
    {
        return result(root).ToList();
    }

    private IEnumerable<string> result(TreeNode node, string path = "")
    {
        if (node == null) return Enumerable.Empty<string>();
        if (node.left == null && node.right == null)
        {
            return new[] { $"{path}{node.val}" };
        }

        return result(node.left, $"{path}{node.val}->").Concat(result(node.right, $"{path}{node.val}->"));
    }

    // --------------- O(n) 368ms --------------- O(n) 33MB --------------- (5% 19%)
    public IList<string> BinaryTreePaths_2(TreeNode root)
    {
        List<string> result = new List<string>();

        if (root == null) return result;
        if (root.left == null && root.right == null)
        {
            result.Add(root.val + "");
            return result;
        }

        foreach (string path in BinaryTreePaths_2(root.left))
        {
            result.Add($"{root.val}->{path}");
        }

        foreach (string path in BinaryTreePaths_2(root.right))
        {
            result.Add($"{root.val}->{path}");
        }

        return result;
    }

    // --------------- O(n) 248ms --------------- O(n) 32MB --------------- (67% 54%) ※
    /*
     * using Queue grammar
     */
    public IList<string> BinaryTreePaths_3(TreeNode root)
    {
        List<string> result = new List<string>();
        if (root == null)
        {
            return result;
        }

        Queue<(TreeNode, string)> queue = new Queue<(TreeNode,string)>();
        queue.Enqueue((root, ""));
        while (queue.Count>0)
        {
            var curr = queue.Dequeue();
            string updatePath = string.IsNullOrEmpty(curr.Item2) ? curr.Item1.val.ToString() : $"{curr.Item2}->{curr.Item1.val}";
            if (curr.Item1.left == null && curr.Item1.right == null)
            {
                result.Add(updatePath);
            }
            else
            {
                if (curr.Item1.left != null) queue.Enqueue((curr.Item1.left, updatePath));
                if (curr.Item1.right != null) queue.Enqueue((curr.Item1.right, updatePath));
            }
        }

        return result;
    }
}

/**************************************************************************************************************
 * BinaryTreePaths_1 BinaryTreePaths_2 BinaryTreePaths_3                                                      *
 **************************************************************************************************************/