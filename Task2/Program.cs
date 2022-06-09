//Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.


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
    Console.WriteLine("Заполненная матрица");
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
            Console.Write($"{matrix[i, j]} ");
        Console.WriteLine();
    }
}


void PrintMatrixWithSum(int[,] array,int[] sumInRow,int rowIndex)
{
    Console.Write("\n");
    Console.WriteLine($"Наименьшая сумма элементов матрицы ({sumInRow[rowIndex]})находится в строке № {rowIndex+1}");
    for ( int i = 0 ; i < array.GetLength(0) ; i ++)
    {
        Console.Write($"Номер строки: ({i+1})");
        for ( int j = 0 ; j < array.GetLength(1) ; j ++)
            Console.Write($"\t{array[i,j],3}"); 
        Console.Write($"\t Сумма эллементов : {sumInRow[i]}");
        Console.Write("\n");
    }
}

(int[],int) LookUpLaneWithMinSum(int[,] matr)
{
    int[] sumRowMatrix = new int[matr.GetLength(0)];
    for ( int i = 0 ; i < matr.GetLength(0) ; i++)
        for ( int j = 0 ; j < matr.GetLength(1) ; j++)
            sumRowMatrix[i] += matr[i,j];
    int min = sumRowMatrix[0];
    int rowMinIndex = 0;
    for (int i = 0 ; i < sumRowMatrix.Length ; i ++)
        if (sumRowMatrix[i] < min )
        {
            min = sumRowMatrix[i];
            rowMinIndex = i;
        }
    return (sumRowMatrix,rowMinIndex);
}

//Ввод количества строк и столбцов для матрицы и инициализация ее создания
int firstDemension = GetDemension("Введите длину для первого разряда матрицы:");
int secondDemension = GetDemension("Введите длину для второго разряда матрицы:");
int [,] result = InitMatrix(firstDemension, secondDemension);

//Вывод получившейся матрицы
PrintMatrix(matrix: result);
Console.WriteLine();
( int[] rowSum, int minLaneSumIndex ) = LookUpLaneWithMinSum(result);
Console.WriteLine("По результатам вычислений: ");
//Вывод результата вычислений 
PrintMatrixWithSum(result,rowSum,minLaneSumIndex);