/*
Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
*/
int[,] getArray(int height, int width)
{
    Random rnd = new Random();
    int[,] array = new int[height, width];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = (rnd.Next(0, 2) < 1) ? -1 : 1 * rnd.Next(0, 9);
        }
    }
    return array;
}

void showArray(int[,] array)
{
    string show = String.Empty;
    int len = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            show = Convert.ToString(array[i, j]);
            len = show.Length;
            for (int k = 0; k < 4 - len; k++)
            {
                show = show.Insert(0, " ");
            }
            Console.Write($"|{show}");
        }
        Console.WriteLine("|");
    }
}

int[,] arrayMultiplication(int[,] arrayLeft, int[,] arrayRight)
{
    int[,] resultArray = new int[arrayLeft.GetLength(0), arrayRight.GetLength(1)];
    for (int i = 0; i < resultArray.GetLength(0); i++)
    {
        for (int j = 0; j < resultArray.GetLength(1); j++)
        {
            for (int k = 0; k < arrayLeft.GetLength(1); k++)
            {
                resultArray[i,j] += arrayLeft[i, k] * arrayRight[k, j];
            }
        }
    }
    return resultArray;
}

int[,] arrayLeft = getArray(5, 2);
int[,] arrayRight = getArray(2, 3);
Console.WriteLine("Ваши массивы:");
showArray(arrayLeft);
Console.WriteLine("---------------------------------");
showArray(arrayRight);
Console.WriteLine("---------------------------------");
if(arrayLeft.GetLength(1) == arrayRight.GetLength(0))
{
Console.WriteLine("Результирующая матрица:");
showArray(arrayMultiplication(arrayLeft, arrayRight));
}
else
    Console.WriteLine("Матрицы не согласованы...");