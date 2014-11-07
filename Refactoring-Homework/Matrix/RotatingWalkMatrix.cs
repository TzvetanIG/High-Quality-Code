using System;

public static class RotatingWalkMatrix
{
    static void Main()
    {
        var n = ReadMatrixSize();
        var matrix = BuildMatrix(n);
        PrintMatrix(matrix);
    }

    static void ChangeDirection(ref int directionX, ref int directionY)
    {
        int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };
        int currentDirection = 0;

        for (int count = 0; count < directionsX.Length; count++)
        {
            if (directionsX[count] == directionX && directionsY[count] == directionY)
            {
                currentDirection = count; break;
            }
        }

        if (currentDirection == (directionsX.Length - 1))
        {
            directionX = directionsX[0]; directionY = directionsY[0]; 
            return;
        }

        directionX = directionsX[currentDirection + 1];
        directionY = directionsY[currentDirection + 1];
    }

    static bool CheckNextMove(int[,] matrix, int row, int col)
    {
        int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };
        int matrixSize = matrix.GetLength(0);

        for (int i = 0; i < directionsX.Length; i++)
        {
            if (row + directionsX[i] >= matrixSize || row + directionsX[i] < 0)
            {
                directionsX[i] = 0;
            }

            if (col + directionsY[i] >= matrixSize || col + directionsY[i] < 0)
            {
                directionsY[i] = 0;
            }
        }

        for (int i = 0; i < directionsX.Length; i++)
        {
            if (matrix[row + directionsX[i], col + directionsY[i]] == 0)
            {
                return true;
            }
        }

        return false;
    }

    static void FindStartCell(int[,] matrix, out int row, out int col)
    {
        int matrixSize = matrix.GetLength(0);
        row = 0;
        col = 0;
        
        for (int i = 0; i < matrixSize; i++)
        {
            for (int j = 0; j < matrixSize; j++)
            {
                if (matrix[i, j] == 0)
                {
                    row = i;
                    col = j;
                    return;
                }
            }
        }
    }

    public static int[,] BuildMatrix(int matrixSize)
    {
        int[,] matrix = new int[matrixSize, matrixSize];
        int currentValue = 1;
        int i = 0;
        int j = 0;

        FillHalfMatrix(matrix, ref i, ref j, ref currentValue);

        currentValue++;

        FindStartCell(matrix, out i, out j);

        if (i != 0 && j != 0)
        {
            FillHalfMatrix(matrix, ref i, ref j, ref currentValue);
        }

        return matrix;
    }

    private static void FillHalfMatrix(int[,] matrix, ref int i, ref int j, ref int currentValue)
    {
        int directionX = 1;
        int directionY = 1;
        int matrixSize = matrix.GetLength(0);
        while (true)
        {
            matrix[i, j] = currentValue;

            if (!CheckNextMove(matrix, i, j))
            {
                break;
            }

            while ((i + directionX >= matrixSize || i + directionX < 0 ||
                    j + directionY >= matrixSize || j + directionY < 0 ||
                    matrix[i + directionX, j + directionY] != 0))
            {
                ChangeDirection(ref directionX, ref directionY);
            }

            i += directionX;
            j += directionY;
            currentValue++;
        }
    }

    public static void PrintMatrix(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0,4}", matrix[i, j]);
            }

            Console.WriteLine();
        }
    }

    public static int ReadMatrixSize()
    {
        const int MaxSize = 100;
        const int MinSize = 0;

        Console.WriteLine("Enter a positive number ");
        string input = Console.ReadLine();

        int n = 0;
        while (!int.TryParse(input, out n) || n < MinSize || n > MaxSize)
        {
            Console.WriteLine("You haven't entered a correct positive number");
            input = Console.ReadLine();
        }

        return n;
    }
}

