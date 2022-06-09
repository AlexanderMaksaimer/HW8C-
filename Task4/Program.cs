//Задача 60: Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
//Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.

int GetDemension(string message)
{
    Console.WriteLine(message);
    int demension = int.Parse(Console.ReadLine());
    return demension;
}


//метод проверки наличия числа в матрице
bool CheckNum(int number, int[,,] matrix)
{
    bool result = true;
    for ( int x = 0 ; x < matrix.GetLength(0) ; x++)
        for ( int y = 0 ; y < matrix.GetLength(1) ; y++)
            for ( int z = 0 ; z < matrix.GetLength(2) ; z++)
                if ( number == matrix[x,y,z]) result = false;
    return result;
}

//метод создания трехмерной матрицы и проверки числа
int[,,] InitMatrix(int DemensionX, int DemensionY, int DemensionZ)
{
    int[,,] matrix = new int[DemensionX,DemensionY,DemensionZ];
    Random rnd = new Random();
    for (int x = 0 ; x < DemensionX ; x++)
        for (int y = 0 ; y < DemensionY ; y++)
            for (int z = 0 ; z < DemensionZ ; z++)
            {
                bool needNum = true;
                while (needNum)
                {
                    matrix[x,y,z] = rnd.Next(10,100);
                    needNum = CheckNum(matrix[x,y,z],matrix);
                }
            }
    return matrix;
}

//метод построчной печати числа с индексами матрицы
void PrintMatrixRow(int[,,] matrix)
{
    Console.Write($"\nx.y.z.\tЧисло\n");
    for (int x = 0 ; x < matrix.GetLength(0) ; x++)
        for (int y = 0 ; y < matrix.GetLength(1) ; y++)
            for (int z = 0 ; z < matrix.GetLength(2) ; z++)
                Console.Write($"{x}.{y}.{z}.\t{matrix[x,y,z]}\n");
}

int firstDemension = GetDemension("Введите количество элементов по Оси X: ");
int secondDemension = GetDemension("Введите количество элементов по Оси Y: ");
int thirdDemension = GetDemension("Введите количество элементов по Оси Z");
if (firstDemension*secondDemension*thirdDemension > 90)
    Console.WriteLine("Число элементов матрицы не позволяет использовать заданный набор неповторяющихся двухзначных чисел");
else
{
    int[,,] matrix = InitMatrix(firstDemension,secondDemension,thirdDemension);
    PrintMatrixRow(matrix);
}


