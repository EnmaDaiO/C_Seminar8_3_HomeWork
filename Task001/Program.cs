// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит 
// по убыванию элементы каждой строки двумерного массива.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

/// <summary>
/// Метод создания массива
/// </summary>
/// <param name="rows">переменная с индексом строки</param>
/// <param name="cols">переменная с индексом столбца</param>
/// <param name="minValue"> минимальное значение элементов матрицы</param>
/// <param name="maxValue">максимальное значение элементов матрицы</param>
/// <returns>Возвращает матрицу целых чисел</returns>
int[,] CreatMarix(int rows, int cols, int minValue, int maxValue)
{
    int[,] matrix = new int[rows, cols]; // [строчка, столбец]
    for (int i = 0; i < rows; i++) // строчки; rows = matrix.GetLength(0)
    {
        // i,j,m,k - индексы
        for (int j = 0; j < cols; j++)// столбцы; cols = matrix.GetLength(1)
        {
            matrix[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return matrix; // Вернули заполненную табличку
}
/// <summary>
/// Метод вывода готовой матрицы в консоль
/// </summary>
/// <param name="matr">переменная с названием матрицы</param>
void PrintMatrix(int[,] matr) // Печатаем двумерный массив
{
    for (int i = 0; i < matr.GetLength(0); i++) // проход по строчкам
    {
        for (int m = 0; m < matr.GetLength(1); m++) // Проход по столбцам
        {
            Console.Write(matr[i, m] + "\t"); // "\t" = 4 пробела или tab
        }
        Console.WriteLine();
    }
}


int[,] resultMatrix = CreatMarix(3, 4, 0, 10); // Вызов метода создания матрицы.

PrintMatrix(resultMatrix); //Вывод матрицы в консоль

/// <summary>
/// Метод сортировки матрицы по строкам, от большего элемента к меньшему(по убыванию)
/// </summary>
/// <param name="inputMatrix">переменная с именем матрицы которую необходимо отсортировать</param>
/// <returns></returns>
int[,] SortRowsMatrix(int[,] inputMatrix)
{
    int rows = inputMatrix.GetLength(0); // присвоили размер строк сортируемой матрицы переменной rows
    int cols = inputMatrix.GetLength(1); // присвоили размер столбцов сортируемой матрицы переменной cols
    int temp = 0;// буфер в котором хранятся переменные
    for (int i = 0; i < resultMatrix.GetLength(0); i++) // проход по строчкам
    {
        for (int m = 0; m < resultMatrix.GetLength(1); m++) // Проход по столбцам
        {
            for (int k = m + 1; k < cols; k++)// задаем переменную следующего значения(прим. array[0,1]) в строке, с которым будем сравнивать первое взятое значение(прим. array[0,0]).
            {
                if (inputMatrix[i, m] < inputMatrix[i, k])
                {
                    temp = inputMatrix[i, m];
                    inputMatrix[i, m] = inputMatrix[i, k];
                    inputMatrix[i, k] = temp;
                }
            }

        }

    }
    return inputMatrix;
}


int[,] sortResultMatrix = SortRowsMatrix(resultMatrix); // присваиваем отсортированной матрице новое название.
Console.WriteLine("\n Отсортированный по возрастанию массив:  ");
PrintMatrix(sortResultMatrix); // выводим отсортированную матрицу


// Код коллеги, в нем добавлена логическая функция с доп.сортировкой по убыванию

// int[,] SortRowsMatrix(int[,] inputMatrix, bool sortType = true)
// {
//     int rows = inputMatrix.GetLength(0);
//     int cols = inputMatrix.GetLength(1);
//     int tmp = 0;
//     for (int i = 0; i < rows; i++)
//     {
//         for (int j = 0; j < cols - 1; j++)
//         {
//             for (int k = j + 1; k < cols; k++)
//             {
//                 if (sortType)
//                 {
//                     if (inputMatrix[i, j] > inputMatrix[i, k])
//                     {
//                         tmp = inputMatrix[i, j];
//                         inputMatrix[i, j] = inputMatrix[i, k];
//                         inputMatrix[i, k] = tmp;
//                     }
//                 }
//                 else
//                 {
//                     if (inputMatrix[i, j] < inputMatrix[i, k])
//                     {
//                         tmp = inputMatrix[i, j];
//                         inputMatrix[i, j] = inputMatrix[i, k];
//                         inputMatrix[i, k] = tmp;
//                     }
//                 }
//             }
//         }
//     }
//     return inputMatrix;
// }

// // проверки.
// int[,] array = CreatMarix(5, 5);
// Console.WriteLine("\nИсходный массив:");
// PrintMatrix(array);

// int[,] sortDownArray = SortRowsMatrix(array); // по возрастанию
// Console.WriteLine("\nОтсортированный по возрастанию массив:");
// PrintMatrix(sortDownArray);

// int[,] sortUpArray = SortRowsMatrix(array, false); // по убыванию
// Console.WriteLine("\nОтсортированный по убыванию массив:");
// PrintMatrix(sortUpArray);
