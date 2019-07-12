//Source  : https://leetcode.com/problems/available-captures-for-rook/
//Author  : Xinruo Shi
//Date    : 2019-07-28
//Language: C#

/*******************************************************************************************************************************
 * 
 * On an 8 x 8 chessboard, there is one white rook.  There also may be empty squares, white bishops, and black pawns. 
 * These are given as characters 'R', '.', 'B', and 'p' respectively. Uppercase characters represent white pieces, and lowercase characters represent black pieces.
 * The rook moves as in the rules of Chess: it chooses one of four cardinal directions (north, east, west, and south), 
 * then moves in that direction until it chooses to stop, reaches the edge of the board, or captures an opposite colored pawn by moving to the same square it occupies.  
 * Also, rooks cannot move into the same square as other friendly bishops.
 * Return the number of pawns the rook can capture in one move.
 * 
 * Note:
 * board.length == board[i].length == 8
 * board[i][j] is either 'R', '.', 'B', or 'p'
 * There is exactly one cell with board[i][j] == 'R'
 * 
 * Input: [[".",".",".",".",".",".",".","."],[".",".",".","p",".",".",".","."],
 *         [".",".",".","R",".",".",".","p"],[".",".",".",".",".",".",".","."],
 *         [".",".",".",".",".",".",".","."],[".",".",".","p",".",".",".","."],
 *         [".",".",".",".",".",".",".","."],[".",".",".",".",".",".",".","."]]
 * Output: 3
 * Explanation: 
 * In this example the rook is able to capture all the pawns.
 * 
 *******************************************************************************************************************************/

public class Solution999
{
    // --------------- O(n) 100ms --------------- 21.9MB --------------- (26% 6%) 
    public int NumRookCaptures_1(char[][] board)
    {
        int x = -1;
        int y = -1;

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                if (board[i][j] == 'R')
                {
                    x = i;
                    y = j;
                    break;
                }
            }
        }

        int count = 0;
        // west
        for (int i = x - 1; i >= 0; i--)
        {
            if (board[i][y] == '.')
            {
                continue;
            }
            else if (board[i][y] == 'B')
            {
                break;
            }
            else if (board[i][y] == 'p')
            {
                count++;
                break;
            }
        }
        // east
        for (int i = x + 1; i < board[0].Length; i++)
        {
            if (board[i][y] == '.')
            {
                continue;
            }
            else if (board[i][y] == 'B')
            {
                break;
            }
            else if (board[i][y] == 'p')
            {
                count++;
                break;
            }
        }
        // south
        for (int i = y + 1; i < board[0].Length; i++)
        {
            if (board[x][i] == '.')
            {
                continue;
            }
            else if (board[x][i] == 'B')
            {
                break;
            }
            else if (board[x][i] == 'p')
            {
                count++;
                break;
            }
        }
        // north
        for (int i = y - 1; i >= 0; i--)
        {
            if (board[x][i] == '.')
            {
                continue;
            }
            else if (board[x][i] == 'B')
            {
                break;
            }
            else if (board[x][i] == 'p')
            {
                count++;
                break;
            }
        }

        return count;
    }

    // --------------- O(n) 96ms --------------- 21.9MB --------------- (49% 6%) ※
    public int NumRookCaptures_2(char[][] board)
    {
        int x = -1;
        int y = -1;

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                if (board[i][j] == 'R')
                {
                    x = i;
                    y = j;
                    break;
                }
            }
        }

        int count = 0;

        int[,] d = new int[,] { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
        for (int i = 0; i < 4; i++)
        {
            for (int x0 = x + d[i, 0], y0 = y + d[i, 1]; x0 < board[0].Length && y0 < board[0].Length && x0 >= 0 && y0 >= 0; x0 += d[i, 0], y0 += d[i, 1])
            {
                if (board[x0][y0] == 'p') count++;
                if (board[x0][y0] != '.') break;
            }
        }

        return count;
    }
}