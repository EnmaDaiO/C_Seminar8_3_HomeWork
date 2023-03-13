// Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18


// Судя по ответу-примеру абсолютно не понял как матрица перемножается.
//==============================
// СВОЕГО РЕШЕНИЯ НЕТ. Перенес к себе вариант коллеги для дальнейшего анализа.



/*
Задача 58:
Заданы две матрицы.
Найти произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
*/

/// <summary>
/// Генератор двумерного массива целых двузначных чисел
/// </summary>
/// <param name="rows">кол-во строк</param>
/// <param name="cols">кол-во столбцов</param>
/// <param name="min">минимальное значение</param>
/// <param name="max">максимальное значение</param>
/// <returns>Двумерный массив заполненный рандомными целыми двузначными числами</returns>
int[,] GetMatrix(int rows, int cols, int min, int max)
{
    int[,] matrix = new int[rows, cols];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            matrix[i, j] = new Random().Next(min, max + 1);
        }
    }
    return matrix;
}

/// <summary>
/// Печать двумерного массива целых чисел
/// </summary>
/// <param name="inputMatrix">Двумерный массив целых чисел</param>
void PrintMatrix(int[,] inputMatrix)
{
    for (int i = 0; i < inputMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < inputMatrix.GetLength(1); j++)
        {
            Console.Write($"{inputMatrix[i, j]}\t");
        }
        Console.WriteLine();
    }
}

/// <summary>
/// Умножение матриц
/// </summary>
/// <param name="matrixA">Двумерный массив целых чисел</param>
/// <param name="matrixB">Двумерный массив целых чисел</param>
/// <returns>Результирующая матрица (двумерный массив)</returns>
int[,] MultiMatrix(int[,] matrixA, int[,] matrixB)
{
    if (matrixA.GetLength(1) != matrixB.GetLength(0))
    {
        Console.WriteLine("Умножение невозможно.\nМатрицы не соответствуют.\nКол-во столбцов первой матрицы не равно кол-ву строк второй матрицы.");
        Environment.Exit(0);
    }

    int rowsA = matrixA.GetLength(0);
    int colsA = matrixA.GetLength(1);

    int rowsB = matrixB.GetLength(0);
    int colsB = matrixB.GetLength(1);

    int[,] resMatrix = new int[rowsA, colsB];

    for (int i = 0; i < rowsA; i++) // из первой матрицы по строкам
    {
        for (int j = 0; j < colsB; j++) // из второй матрицы по столбцам
        {
            for (int k = 0; k < colsA; k++) // перебираем значения в строке для умножения на ...
            {   // значение в строке 1й матрицы умножаем на значение в столбце 2й матрицы
                resMatrix[i, j] += matrixA[i, k] * matrixB[k, j];
            }
        }
    }

    return resMatrix;
}

// проверки
int size1 = 2;
int size2 = 2;
int min = 2;
int max = 4;

int[,] matrixA = GetMatrix(size1, size2, min, max);
//int[,] matrixA = { { 2, 4 }, { 3, 2 } }; // тест по ДЗ (рабочий)
Console.WriteLine("Matrix A");
PrintMatrix(matrixA);

Console.WriteLine();

int[,] matrixB = GetMatrix(size2, size1, min, max);
//int[,] matrixB = { { 3, 4 }, { 3, 3 } }; // тест по ДЗ (рабочий)
Console.WriteLine("Matrix B");
PrintMatrix(matrixB);

Console.WriteLine();

int[,] resMatrix = MultiMatrix(matrixA, matrixB);
Console.WriteLine("Multiplied Matrix");
PrintMatrix(resMatrix);
