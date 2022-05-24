using System;

namespace Sudoku.Workers
{
    public class SudokuFileReader
    {
        public int[,] ReadFile(string filename)
        {
            int[,] sudokuBoard = new int[9,9];

            try
            {
                
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro durante a leitura do arquivo:" + ex.Message);
            }

            return sudokuBoard;
        }
    }
}