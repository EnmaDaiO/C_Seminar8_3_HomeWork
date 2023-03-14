// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся 
// двузначных чисел. Напишите программу, которая будет построчно выводить массив, 
// добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

//своего решения нет, времени на просмотр доп.лекций до сроков сдачи дз тоже. Взял решение коллеги 
//для анализа в дальнейшем

/*
Задача 60.
Сформировать трёхмерный массив из неповторяющихся двузначных чисел.
Построчный вывод массива, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)
*/

/// <summary>
/// Поиск числа в 3D массиве
/// </summary>
/// <param name="number">искомое число</param>
/// <param name="matrix">массив для поиска</param>
/// <returns>TRUE или FALSE</returns>
bool FindNumber3DMatrix(int number, int[,,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(2); k++)
            {
                if (number == matrix[i, j, k])
                {
                    return true;
                }
            }
        }
    }
    return false;
}

/// <summary>
/// Генератор 3D массива с неповторяющимися значениями
/// </summary>
/// <param name="sizeX">Строки</param>
/// <param name="sizeY">Столбцы</param>
/// <param name="sizeZ">Глубина</param>
/// <param name="min">Минимальное значение</param>
/// <param name="max">Максимальное значение</param>
/// <returns>Заполненный трехмерный массив</returns>
int[,,] Get3DMatrixNoRepeat(int sizeX, int sizeY, int sizeZ, int min, int max)
{
    if (sizeX * sizeY * sizeZ > max - min)
    {
        System.Console.WriteLine("Неповторяющихся значений меньше чем размер массива");
        Environment.Exit(0);
    }
    int[,,] array = new int[sizeX, sizeY, sizeZ];
    for (int i = 0; i < sizeX; i++)
    {
        for (int j = 0; j < sizeY; j++)
        {
            for (int k = 0; k < sizeZ; k++)
            {
                int value = new Random().Next(min, max);
                while (FindNumber3DMatrix(value, array)) // беск. цикл поиска неравного
                {
                    value = new Random().Next(min, max);
                }
                array[i, j, k] = value;
            }
        }
    }
    return array;
}

/// <summary>
/// Печать трехмерного массива
/// </summary>
/// <param name="matrix">трехмерный массив</param>
void Print3DMatrix(int[,,] matrix)
{
    int rows = matrix.GetLength(0);
    int cols = matrix.GetLength(1);
    int dpth = matrix.GetLength(2);
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            for (int k = 0; k < dpth; k++)
            {
                System.Console.Write($"{matrix[i, j, k]} ({i},{j},{k})\t");
            }
            System.Console.WriteLine();
        }
        //System.Console.WriteLine();
    }
}

// проверки

Print3DMatrix(Get3DMatrixNoRepeat(4, 4, 4, 10, 99)); // 64 значения