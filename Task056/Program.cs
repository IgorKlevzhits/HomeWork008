/*
Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
*/
int getNumber(string message)
{
    int result = 0;
    while (true)
    {
        Console.Write(message);
        if (int.TryParse(Console.ReadLine(), out result) && (result > 0))
        {
            break;
        }
        else
        {
            Console.WriteLine($"Введено неверное число, повторить ввод");
        }
    }
    return result;
}

int[,] getArray(int height, int width)
{
    Random rnd = new Random();
    int[,] array = new int[height, width];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = rnd.Next(0, 100);
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

int findMinIndex(int[,] array)
{
    int min = 0;
    int minSum = 999990;
    int minString = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        min = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            min += array[i, j];
        }
        if (min < minSum)
        {
            minSum = min;
            minString = i;
        }
    }
    return minString + 1;
}

int[,] array = getArray(getNumber("Введите 1-ую размерность массива: "),
                        getNumber("Введите 2-ую размерность массива: "));
Console.WriteLine("Ваш массив:");
showArray(array);
Console.WriteLine($"Номер строки с минимальной суммой элементов - {findMinIndex(array)}");