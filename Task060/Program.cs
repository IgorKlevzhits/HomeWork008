/*
Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)
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

void showArray(int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int l = 0; l < array.GetLength(2); l++)
            {
                Console.Write($"{array[i,j,l]}({i},{j},{l})  ");
            }
            Console.WriteLine();
        }
    }
}

int[,,] getArray(int firstDimension, int secondDimension, int thirdDimension)
{
    Random rnd = new Random();
    char[] numbers = new char[90];
    int[,,] array = new int[firstDimension, secondDimension, thirdDimension];
    int number = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                while (true)
                {
                    number = rnd.Next(10, 100);
                    if (numbers[number - 10] != '*')
                    {
                        numbers[number - 10] = '*';
                        break;
                    }

                }
                array[i, j, k] = number;
            }
        }
    }
    return array;
}

int[,,] array = getArray(getNumber("Введите 1-ую размерность массива: "),
                        getNumber("Введите 2-ую размерность массива: "),
                        getNumber("Введите 3-ую размерность массива: "));
Console.WriteLine("Ваш массив:");
showArray(array);