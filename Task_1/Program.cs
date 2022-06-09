//Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.

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
    Console.WriteLine("Полученная матрица");
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
            Console.Write($"{matrix[i, j]} ");
        Console.WriteLine();
    }
}

//метод осуществления последовательной сортировки
void SortingMatrix(int[,] matr) 
{
    int max;
    int rowMax;
    int columnMax;
    for ( int i = 0 ; i < matr.GetLength(0) ; i++)
    {
        for ( int k = 0 ; k < matr.GetLength(1) ; k ++)
        {
            max = matr[i,k];
            rowMax = i;
            columnMax = k;
            for ( int j = k ; j < matr.GetLength(1) ; j ++)
            {
                if (max <= matr[i,j] )
                {
                        max = matr[i,j];
                        rowMax = i;
                        columnMax = j;
                }
            }
            matr[rowMax,columnMax] = matr[i,k];
            matr[i,k] = max;
        }
    }
}



//Ввод количества строк и столбцов для матрицы и инициализация ее создания
int firstDemension = GetDemension("Введите длину для первого разряда матрицы:");
int secondDemension = GetDemension("Введите длину для второго разряда матрицы:");
int [,] result = InitMatrix(firstDemension, secondDemension);

//Вывод получившейся матрицы
PrintMatrix(matrix: result);
Console.WriteLine();
//Вывод результата сортировки элементов каждой строки от большего к меньшму значению
SortingMatrix(result);
Console.WriteLine("Проводим сортировку от большего к меньшему элементу в каждой строке матрицы : ");
PrintMatrix(matrix: result);