using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewPrepCSharp
{
    internal class SudukoSolution
    {

        //private static int[][] resultArray = new int[9][];

        public SudukoSolution()
        {
            char[,] board = new char[,]{ { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
                                         { '6','.','.','1','9','5','.','.','.'},
                                         {'.','9','8','.','.','.','.','6','.' },
                                         {'8','.','.','.','6','.','.','.','3' },
                                         {'4','.','.','8','.','3','.','.','1' },
                                         {'7','.','.','.','2','.','.','.','6' },
                                         {'.','6','.','.','.','.','2','8','.' },
                                         {'.','.','.','4','1','9','.','.','5' },
                                         {'.','.','.','.','8','.','.','7','9' } };

            SolveSudoku(board);
        }

        public void SolveSudoku(char[,] board)
        {
            if (board == null || board.Length == 0)
                return;
            //Just to print the matrix
            PrintBoardMatrix(board);

            //Suduko has to 9*9 as assumption. 
            SolveSudokuHelper(board, 0, 0);

            PrintBoardMatrix(board);


            //var originalMatrix = ConvertToBoardMatrix(board);
            //var resultMatrix = GetSudukoSolution(originalMatrix);

        }

        private bool SolveSudokuHelper(char[,] board, int row, int col)
        {
            if (row > 8)
                return true;
            var visit = board[row, col];
            var isDot = visit == '.';

            var nextRow = col == 8 ? row + 1 : row;
            var nextCol = col == 8 ? 0 : col + 1;

            if (!isDot)
            {
                return SolveSudokuHelper(board, nextRow, nextCol);
            }


            //Assumption it is a digit
            var availableNumbers = GetAvailableNumbers(board, row, col);

            foreach (var option in availableNumbers)
            {
                board[row, col] = option;
                var result = SolveSudokuHelper(board, nextRow, nextCol);
                if (result)
                    return true;
                
                board[row, col] = '.';
            }

            //PrintBoardMatrix(board);

            return false;
        }

        private HashSet<char> GetAvailableNumbers(char[,] board, int row, int col)
        {
            var numbers = new char[]{ '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            var available = new HashSet<char>(numbers);

            //check by row
            for (int i = 0; i < 9; i++)
            {
                var visit = board[row, i];
                var isDigit = visit != '.';
                if (isDigit)
                    available.Remove(visit);
            }

            //check by col
            for (int i = 0; i < 9; i++)
            {

                var visit = board[i, col];
                var isDigit = visit != '.';
                if (isDigit)
                    available.Remove(visit);
            }

            //Check 3 X 3 Matrix
            var startRow = row / 3 * 3;
            var startCol = col / 3 * 3;

            for (int currentRow = startRow; currentRow < startRow + 3; currentRow++)
            {
                for (int currentCol = startCol; currentCol < startCol + 3; currentCol++)
                {
                    var visit = board[currentRow, currentCol];
                    var isDigit = visit != '.';
                    if (isDigit)
                        available.Remove(visit);
                }
            }
            return available;
        }


        private void PrintBoardMatrix(char[,] board)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var CellValue = board[i, j];
                    if (j == 0)
                        Console.Write(" | " + CellValue + " |");
                    else
                        Console.Write(" " + CellValue + " |");
                }
                Console.WriteLine(" ");
            }
            Console.WriteLine(" ");
        }


        private static void PrintBoardMatrix(char[][] board, int row, int col)
        {
            //int CellValue = board[row][col] != '.' ? Convert.ToInt32(board[row][col].ToString()) : 0;
            var CellValue = board[row][col];
            //This is to Print the Matrix
            if (col == 0)
                Console.Write(" | " + CellValue + " |");
            else
                Console.Write(" " + CellValue + " |");
        }

        #region "Partial Working"



        //private static int[][] ConvertToBoardMatrix(char[][] board)
        //{
        //    int[][] inputValues = new int[9][];
        //    for (int i = 0; i < 9; i++)
        //    {
        //        inputValues[i] = new int[board[i].Length];
        //        for (int j = 0; j < board[i].Length; j++)
        //        {
        //            if (board[i][j].ToString() != ".")
        //                inputValues[i][j] = Convert.ToInt32(board[i][j].ToString());
        //            else
        //                inputValues[i][j] = 0;
        //            Console.Write(" " + inputValues[i][j]);
        //        }
        //        Console.WriteLine();
        //    }
        //    return inputValues;
        //}

        //private static void RecursiveBoardMatrixBuilder(char[][] board)
        //{
        //    for (int i = 0; i < board.Length; i++)
        //    {
        //        for (int j = 0; j < board[i].Length; j++)
        //        {
        //            PrintBoardMatrix(board, i, j);
        //            //SetOtherCells(board, i, j);
        //        }
        //        Console.WriteLine(" ");
        //    }
        //    Console.WriteLine(" ");

        //    //ToSet the values
        //    for (int i = 0; i < board.Length; i++)
        //    {
        //        for (int j = 0; j < board[i].Length; j++)
        //        {
        //            SetOtherCells(ref board, i, j);
        //        }
        //    }

        //    for (int i = 0; i < board.Length; i++)
        //    {
        //        for (int j = 0; j < board[i].Length; j++)
        //        {
        //            PrintBoardMatrix(board, i, j);
        //        }
        //        Console.WriteLine(" ");
        //    }
        //}

        //private static void SetOtherCells(ref char[][] board, int row, int col)
        //{
        //    List<char> numbers = new List<char>();

        //    var rowArray = SetOtherRowCells(ref board, row, ref numbers);
        //    var colArray = SetOtherColCells(ref board, col, ref numbers);

        //    if (board[row][col] == '.')
        //    {
        //        var value = ValidValue(ref numbers);
        //        board[row][col] = value;
        //    }
        //}

        //private static char ValidValue(ref List<char> numbers)
        //{
        //    char value = '.';
        //    List<char> chars = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        //    var values = chars.Except(numbers);

        //    //if (values.Count() == 0)
        //    //    value = 'X';
        //    //else
        //    //    value = values.FirstOrDefault();
        //    return value;
        //}

        //private static char[] SetOtherColCells(ref char[][] board, int col, ref List<char> numbers)
        //{
        //    char[] colArray = new char[9];
        //    for (int i = 0; i < 9; i++)
        //    {
        //        if (board[i][col] != '.')
        //        {
        //            colArray[i] = board[i][col];
        //            if (!numbers.Contains(colArray[i]))
        //                numbers.Add(colArray[i]);
        //        }
        //    }
        //    return colArray;
        //}

        //private static char[] SetOtherRowCells(ref char[][] board, int row, ref List<char> numbers)
        //{
        //    char[] rowArray = new char[9];
        //    for (int i = 0; i < 9; i++)
        //    {
        //        if (board[row][i] != '.')
        //        {
        //            rowArray[i] = board[row][i];
        //            if (!numbers.Contains(rowArray[i]))
        //                numbers.Add(rowArray[i]);
        //        }
        //    }
        //    return rowArray;
        //}

        //private static void PrintBoardMatrix(char[][] board, int row, int col)
        //{
        //    //int CellValue = board[row][col] != '.' ? Convert.ToInt32(board[row][col].ToString()) : 0;
        //    var CellValue = board[row][col];
        //    //This is to Print the Matrix
        //    if (col == 0)
        //        Console.Write(" | " + CellValue + " |");
        //    else
        //        Console.Write(" " + CellValue + " |");
        //}

        #endregion "Partial Working"


        #region Not in USE

        //private bool Solve(char[][] board)
        //{
        //    for (int i = 0; i < board.Length; i++)
        //    {
        //        for (int j = 0; j < board[i].Length; j++)
        //        {
        //            if(board[i][j] == '.')
        //            {
        //                for (char c = '1'; c < '9'; c++)
        //                {
        //                    if(isValid(board,i,j,c))
        //                    {
        //                        board[i][j] = c;
        //                        if (Solve(board))
        //                            return true;
        //                        else
        //                            board[i][j] = '.';
        //                    }
        //                }
        //                return false;
        //            }
        //        }
        //    }
        //    return true;
        //}

        //private bool isValid(char[][] board, int row, int col, char c)
        //{
        //    for (int i = 0; i < 9; i++)
        //    {
        //        //Check row
        //        if (board[i][col] != '.' && board[i][col] == c)
        //            return false;
        //        //check Col
        //        if (board[row][i] != '.' && board[row][i] == c)
        //            return false;
        //        //Check 3*3
        //        if (board[3 * (row / 3) + i / 3][(col / 3) + i % 3] != '.' && board[3 * (row / 3) + i / 3][(col / 3) + i % 3] == c)
        //            return false;
        //    }
        //    return true;
        //}


        #endregion Not in USE
    }
}