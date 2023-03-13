// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, 
// которая будет находить строку с наименьшей суммой элементов.

// Например, задан массив:

// 1 4 7 2

// 5 9 2 3

// 8 4 2 4

// 5 2 6 7

// Программа считает сумму элементов в каждой строке и выдаёт номер строки с 
// наименьшей суммой элементов: 1 строка



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

int SumElementRows(int[,] matr) // меняем подход
{
    int rows = matr.GetLength(0);
    int cols = matr.GetLength(1);
    int rowsMin = int.MaxValue;  // индекс строки с минималной суммой
    int prevSum = int.MaxValue; // предыдущая сумма
    int currSum = int.MinValue; // текущая сумма

    for (int i = 0; i < rows; i++)
    {
        currSum = 0;
        for (int j = 0; j < cols; j++)
        {
            currSum = currSum + matr[i, j]; // или currSum += matr[i, j]
        }
        if (currSum < prevSum)
        {
            prevSum = currSum;
            rowsMin = i;
        }
    }
    return rowsMin;
}

int rowMin = SumElementRows(resultMatrix);
System.Console.WriteLine($"Строка с наименьшей суммой: {rowMin + 1}");