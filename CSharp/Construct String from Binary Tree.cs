//Source  : https://leetcode.com/problems/construct-string-from-binary-tree/
//Author  : Xinruo Shi
//Date    : 2020-11-22
//Language: C#

/*******************************************************************************************************************************
 * 
 * You need to construct a string consists of parenthesis and integers from a binary tree with the preorder traversing way.
 *
 * The null node needs to be represented by empty parenthesis pair "()". And you need to omit all the empty parenthesis pairs
 * that don't affect the one-to-one mapping relationship between the string and the original binary tree.
 *
 * Input: Binary tree: [1,2,3,4]
 *              1
 *            /   \
 *           2     3
 *          /
 *         4
 * Output: "1(2(4))(3)"
 * Explanation: Originallay it needs to be "1(2(4)())(3()())",
 *              but you need to omit all the unnecessary empty parenthesis pairs.
 *              And it will be "1(2(4))(3)".
 *
 * Input: Binary tree: [1,2,3,null,4]
 *              1
 *            /   \
 *           2     3
 *            \
 *             4
 * Output: "1(2()(4))(3)"
 * Explanation: Almost the same as the first example,
 *              except we can't omit the first parenthesis pair to break the one-to-one mapping relationship between the input and the output.
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

public class Solution606
{
    // --------------- O(n) 124ms --------------- O(n) 47MB --------------- (65% 46%) ※
    /*
     *  Using Recursion
     */
    public string Tree2str_1(TreeNode t)
    {
        if (t == null) return "";

        if (t.left == null && t.right == null)
        {
            return t.val.ToString();
        }

        if (t.right == null)
        {
            return $"{t.val}({Tree2str_1(t.left)})";
        }

        return $"{t.val}({Tree2str_1(t.left)})({Tree2str_1(t.right)})";
    }

    // --------------- O(n) 120ms --------------- O(n) 47MB --------------- (72% 37%)
    public string Tree2str_2(TreeNode t)
    {
        if (t == null) return "";
        
        string left = Tree2str_2(t.left);
        string right = Tree2str_2(t.right);

        if (left == "" && right == "")
        {
            return t.val.ToString();
        }

        if (left == "")
        {
            return $"{t.val}()({right})";
        }

        if (right == "")
        {
            return $"{t.val}({left})";
        }

        return $"{t.val}({left})({right})";
    }
}
/**************************************************************************************************************
 * Tree2str_1  Tree2str_2                                                                                     *
 **************************************************************************************************************/