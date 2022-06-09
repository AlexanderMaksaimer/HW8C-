//Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

int GetDemension(string message)
{
    Console.WriteLine(message);
    int demension = int.Parse(Console.ReadLine());
    return demension;
}

//Инициализация заполнения матрицы рандомными числами
int[,] InitMatrix(int firstDemension, int secondDemension)
{
    int[,] matrix = new int[firstDemension, secondDemension];
    Random rnd = new Random();
    for (int i = 0; i < firstDemension; i++)
    {
        for (int j = 0; j < secondDemension; j++)
            matrix[i, j] = rnd.Next(1, 100);
    }
    return matrix;
}

//Вывод заполненной матрицы
void PrintMatrix(int[,] matrix)
{
    //Console.WriteLine("Заполненная матрица");
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
            Console.Write($"{matrix[i, j]} ");
        Console.WriteLine();
    }
}

//метод перемножения матриц № 1 и № 2
int[,] MultiplicationMatrix(int[,] matrixA, int[,] matrixB)
{
    int rowsMatrixA = matrixA.GetLength(0);
    int colMatrixA = matrixA.GetLength(1);
    int rowsMatrixB = colMatrixA;
    int colMatrixB = matrixB.GetLength(1);
    int[,] resultMultiMatrix = new int[rowsMatrixA,colMatrixB];
    for ( int i = 0 ; i < rowsMatrixA ; i++)
        for ( int j = 0 ; j < colMatrixB ; j++)
            for ( int n = 0 ; n < colMatrixA ; n++)
                resultMultiMatrix[i,j] += matrixA[i,n]*matrixB[n,j];
    return resultMultiMatrix;
}

//Ввод количества строк и столбцов для матриц и инициализация их создания
int firstDemensionA = GetDemension("Введите количество строк для матрицы № 1:");
int secondDemensionA = GetDemension("Введите количество столбцов для матрицы № 1:");
Console.WriteLine($"Количество строк матрицы № 2 равняется количеству столбцов матрицы № 1 ({secondDemensionA})");
int firstDemensionB = secondDemensionA;
int secondDemensionB = GetDemension("Введите количество столбцов для матрицы № 2: ");
Console.WriteLine("Полученная матрица № 1");
int [,] resultA = InitMatrix(firstDemensionA, secondDemensionA);
//Вывод получившейся матрицы #1
PrintMatrix(resultA);
Console.WriteLine();
Console.WriteLine("Полученная матрица № 2");
int [,] resultB = InitMatrix(firstDemensionB, secondDemensionB);
//Вывод получившейся матрицы #2
PrintMatrix(resultB);
int [,] multiMatrix = MultiplicationMatrix(resultA,resultB);
Console.WriteLine("Результат перемножения матриц:");
Console.WriteLine();
PrintMatrix(multiMatrix);
