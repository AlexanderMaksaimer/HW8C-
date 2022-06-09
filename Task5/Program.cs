//Заполните спирально массив 4 на 4.

int GetDemension(string message)
{
    Console.WriteLine(message);
    int demension = int.Parse(Console.ReadLine());
    return demension;
}

//Вывод заполненной матрицы
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
            Console.Write($"{matrix[i, j]} ");
        Console.WriteLine();
    }
}

//метод движения по спирали (в данном случае вниз - вправо - вверх - влево)
void HelixMatrix(int[,] matr)
{
    int row = 0;
    int colum = 0;
    int number = 1;
    int point = 1;
    do
    {
        if (point == 1) 
        {
            (row,colum,number) = MoveToDown(matr,row,colum,number);
            point = 2;
        }
        else if (point == 2) 
        {
            (row,colum,number) = MoveToRight(matr,row,colum,number);
            point = 3;
        }
        else if (point == 3) 
        {
            (row,colum,number) = MoveToUp(matr,row,colum,number);
            point = 4;
        }
        else
        {
            (row,colum,number) = MoveToLeft(matr,row,colum,number);
            point = 1;
        }
    } while ( number <= matr.GetLength(0)*matr.GetLength(1));
}

//движение вниз
(int,int,int) MoveToDown(int[,] matr , int row , int colum , int number)
{
    if ( matr[row,colum] != 0 ) row++;
    while ( matr[row,colum] == 0 )
    {
        matr[row,colum] = number;
        number++;
        if ( row + 1 == matr.GetLength(0))
            break;
        else if (matr[row+1,colum] == 0)
            row++;
    }
    return (row,colum,number);
}
//движение вправо
(int,int,int) MoveToRight(int[,] matr , int row , int colum , int number)
{
    if ( matr[row,colum] != 0 ) colum++;
    while ( matr[row,colum] == 0 )
    {
        matr[row,colum] = number;
        number++;
        if ( colum + 1 == matr.GetLength(1))
            break;
        else if (matr[row,colum+1] == 0)
            colum++;
    }
    return (row,colum,number);
}

//движение влево
(int,int,int) MoveToLeft(int[,] matr , int row , int colum , int number)
{
    if ( matr[row,colum] != 0 ) colum--;
    while ( matr[row,colum] == 0 )
    {
        matr[row,colum] = number;
        number++;
        if ( colum - 1 < 0 )
            break;
        else if (matr[row,colum-1] == 0)
            colum--;
    }
    return (row,colum,number);
}
//движение вверх
(int,int,int) MoveToUp(int[,] matr , int row , int colum , int number)
{
    if ( matr[row,colum] != 0 ) row--;
    while ( matr[row,colum] == 0 )
    {
        matr[row,colum] = number;
        number++;
        if ( row - 1 < 0 )
            break;
        else if (matr[row-1,colum] == 0)
            row--;
    }
    return (row,colum,number);
}


int firstDemension = GetDemension("Введите количество строк для матрицы: ");
int secondDemension = GetDemension("Введите количество столбцов для матрицы: ");
Console.WriteLine("Результат расстановки элементов массива по спирали (по маршруту: вниз - вправо - вверх - влево): ");
int[,] matrix = new int[firstDemension,secondDemension];
HelixMatrix(matrix);
PrintMatrix(matrix);