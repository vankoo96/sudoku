using System;

namespace SudokuGame
{
    public partial class Sudoku
    {
        private int size;

        public enum Dificulty
        {
            EASY, HARD
        }

        public int[,] table;


        public Sudoku(Dificulty dificulty)
        {
            if (dificulty == Dificulty.EASY)
                size = 4;
            else if (dificulty == Dificulty.HARD)
                size = 9;
            table = new int[size, size];
        }


        public Boolean startSolving()
        {
            int nextRow = 0;
            int nextCol = 0;
            int tempRow = 0;
            while (!checkNextStep(nextRow, nextCol))
            {
                nextRow = getNextRow(nextRow, nextCol);
                nextCol = getNextColumn(tempRow, nextCol);
                tempRow = nextRow;
            }
            return solve(nextRow, nextCol);
        }

        private Boolean solve(int row, int col)
        {
            if (row == size - 1 && col == size)
                return true;

            bool solved = false;
            int number = 0;

            while (number < size + 1)
            {
                if (checkBox(row, col, number) && checkRow(row, number) && checkColumn(col, number))
                {
                    table[row, col] = number;
                    break;
                }
                number++;
            }

            if (number == size + 1)
                return false;

            int nextRow = getNextRow(row, col);
            int nextCol = getNextColumn(row, col);
            int tempRow = row;

            while (!checkNextStep(nextRow, nextCol))
            {
                nextRow = getNextRow(nextRow, nextCol);
                nextCol = getNextColumn(tempRow, nextCol);
                tempRow = nextRow;
            }

            while (!(solved = solve(nextRow, nextCol)))
            {
                number++;
                if (number == size + 1)
                {
                    table[row, col] = 0;
                    break;
                }

                if (checkBox(row, col, number) && checkColumn(col, number) && checkRow(row, number))
                    table[row, col] = number;

            }

            return solved;    
        }

        private Boolean checkNextStep(int row, int col)
        {
            if (col == size)
                return true;
            return table[row, col] == 0;
        }

        private Boolean checkRow(int row, int number)
        {
            for (int col = 0; col < size; col++)
            {
                if (table[row, col] == number)
                    return false;
            }
            return true;
        }

        private Boolean checkColumn(int col, int number)
        {
            for (int row = 0; row < size; row++)
            {
                if (table[row, col] == number)
                    return false;
            }
            return true;
        }

        private Boolean checkBox(int row, int col, int number)
        {
            int border = Convert.ToInt32(Math.Log(size, 2));
            int startRow = border*(row/border);
            int endRow = startRow+border;
            int startCol = border*(col/border);
            int endCol = startCol+border;
            for (row = startRow; row < endRow; row++)
            {
                for (col = startCol; col < endCol; col++)
                {
                    if (table[row, col] == number)
                        return false;
                }
            }

            return true;
        }

        private int getNextRow(int row, int col)
        {
            if ( row!=size-1 && col == size - 1)
                return row + 1;
            return row;
        }

        private int getNextColumn(int row, int col)
        {
            if (row!=size-1 && col == size - 1)
                return 0;
            return col + 1;
        }

        public int getSize()
        {
            return size;
        }

    }
}
