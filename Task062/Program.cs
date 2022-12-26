/*
Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4. 
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07
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

int[,] getArray(int height)
{
    int count = 1;
    int n = 0;
    int i = 0;
    int j = 0;
    int x = 0;
    int y = 0;
    int[,] array = new int[height, height];


    while (count < array.GetLength(0) * array.GetLength(0) + 1)
    {
        for (j = x; j < array.GetLength(0) - n; j++)//right
        {
            array[i, j] = count++;
        }
        --j;
        for (i = 1 + n; i < array.GetLength(0) - n; i++)//down
        {
            array[i, j] = count++;
        }
        --i;
        x = --j;
        for (j = x; j > -1 + n; j--)//left
        {
            array[i, j] = count++;
        }
        y = --i;
        x = ++j;
        n++;
        for (i = y; i > -1 + n; i--)//up
        {
            array[i, j] = count++;
        }
        x = ++j;
        y = ++i;
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
int height = getNumber("Введите размерность массива: ");
int[,] array = getArray(height);
Console.WriteLine("Ваш массив:");
showArray(array);