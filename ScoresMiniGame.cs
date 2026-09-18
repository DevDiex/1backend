using System.Globalization;
namespace MyConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(" \n Бэкэнд серверная логика");
        int[] serverLogHours = { 12, 45, 5, 90, 23, 150, 4 };
        int sum = 0;


        Console.WriteLine($"\nОшибки в массиве");
        PrintArray(serverLogHours);

        foreach (int num in serverLogHours)
        {
            sum += num;
        }
        Console.WriteLine($"Количество ошибок в этом дне: {sum}");

        BackEndSort(serverLogHours);
        Console.WriteLine();

        SortedList(serverLogHours);
        SortedConsole(serverLogHours);
    }

    static void PrintArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {

            Console.WriteLine($"Ошибок {arr[i]} в часу {i}");
        }
        Console.WriteLine();
    }

    static void BackEndSort(int[] arr)
    {
        Console.WriteLine($" \n Проверка критических ошибок (i > 50) =:");
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] >= 50)
            {
                Console.WriteLine($"Критических ошибок: Количество {arr[i]} больше 50 на часу [{i + 1}]");
            }
        }
    }
    static void SortedList(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr.Length - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
    static void SortedConsole(int[] arr)
    {
        foreach (int errors in arr)
        {
            Console.WriteLine($"{errors}");
        }
    }
}

