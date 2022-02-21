namespace Sudoku.Notas
{
    public class JaggedArrayAndMatrices
    {
        static public void JaggedArrayAndMatricesLeasson()
        {
            //Jagged array - not homogeneous - more efficient
            int[][] jagged = new int[10][];
            jagged[0] = new int[90];
            jagged[1] = new int[9];

            //Matrix - homogeneous - less efficient 
            int[,] matrix = new int[10, 8];
        }
    }
}