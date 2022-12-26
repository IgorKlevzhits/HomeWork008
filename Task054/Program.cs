/*
Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
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

int[,] newArray(int[,] array)
{
    int max = -1;
    int count = 0;
    int countSort = 0;
    int tmp = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        countSort = 0;
        while (countSort < array.GetLength(1))
        {
            max = -1;
            for (int j = countSort; j < array.GetLength(1); j++)
            {
                if (array[i, j] > max)
                {
                    max = array[i, j];
                    count = j;
                }
            }
            tmp = array[i, count];
            array[i, count] = array[i, countSort];
            array[i, countSort] = tmp;
            countSort++;
        }
    }
    return array;
}

int[,] array = getArray(getNumber("Введите 1-ую размерность массива: "), 
                        getNumber("Введите 2-ую размерность массива: "));
Console.WriteLine("Ваш массив:");
showArray(array);
array = newArray(array);
Console.WriteLine();
showArray(array);
