using System.Globalization;
namespace MyConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("First main Array");
        int[] scores = { 950, 231, 120, 433 };

        Console.WriteLine($"Original array:");
        PrintArray(scores);

        BubbleSort(scores);

        Console.WriteLine("\nSorted array");
        PrintArray(scores);

        Console.ReadKey();
    }
    static void PrintArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine(arr[i] + " ");
        }
        Console.WriteLine();
    }

    static void BubbleSort(int[] arr) // Изолированный метод сортировки (работает с массивом)
    {
        for (int p = 0; p < arr.Length; p++) // внешний цикл отвечает за кол-во полных проходов по массиву.
        {
            // Внутренний цикл бегающий по элементам и сравнивающий соседей (arr[i] >=< arr[i + 1])
            for (int i = 0; i < arr.Length - 1; i++) // важно писать arr.Length - 1, чтобы i + 1 не вылетало за пределы границ массива
            {
                if (arr[i] > arr[i + 1])
                {
                    int temp = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = temp;
                }
            }
        }
        // Цикл вывода изолированный (чтобы не писать цикл вывода дважды)
    }








    // string?[] inventory = new string[3]; // Массив строк которые могут быть пустыми (null), на 3 ячейки (0, 1, 2)
    // inventory[1] = "Меч новичка";

    // while (true)
    // {

    //     Console.WriteLine("= Инвентарь = ");

    //     for (int i = 0; i < inventory.Length; i++) // Цикл перфекцонист для вывода предметов
    //     {
    //         // Проверяем если в ячейке значение равно (null), пишем "Пустой слот"
    //         if (inventory[i] == null)
    //         {
    //             Console.WriteLine($"Слот [{i}]: -- Пустой слот --");
    //         }
    //         else
    //             Console.WriteLine($"Слот [{i}]; {inventory[i]}");
    //     }

    //     bool isFull = true;

    //     Console.WriteLine($"\n Enter a new item name to add to inventory");
    //     string? newItem = Console.ReadLine();

    //     for (int i = 0; i < inventory.Length; i++)
    //     {

    //         if (inventory[i] == null) // Если ячейка текстового массива пуста то
    //         {
    //             inventory[i] = newItem;
    //             Console.WriteLine($"\n Item {newItem} added to your {inventory[i]}");
    //             isFull = false; // Инвентарь не заполнен мы нашли место.
    //             break;
    //         }
    //     }
    //     if (isFull == true)
    //     {
    //         Console.WriteLine($"\nError: Inventory is full: Reseting");
    //         Console.ReadKey();

    //         inventory[0] = null;
    //         inventory[2] = null;
    //         Console.WriteLine($"\n Inventory cleared, index [0] and [2] are empty");
    //     }

    // while (true)
    // {

    //     int maxLimit = 1000; // Переменная для хранения максимального счета
    //     int maxScore = 0; // лучший результат раунда

    //     int[] scoreLeaderBoard = new int[5]; // Массив для хранения 5 чисел
    //     Console.WriteLine("= Filling an array ="); // Вывод 
    //                                                // Цикл валидаций и ввода данных
    //     for (int i = 0; i < scoreLeaderBoard.Length; i++) // Цикл for с массивом (списком) scoreLeaderBoard
    //     {
    //         Console.WriteLine($"Enter a score between 1 and 1000: [{i + 1}]");
    //         string? input1 = Console.ReadLine();
    //         // Ввел ли пользователь число?
    //         if (int.TryParse(input1, CultureInfo.InvariantCulture, out int score) == false)
    //         {

    //             Console.WriteLine("Error: Please enter a valid number");
    //             Console.ReadLine();
    //             i--; // Отматываем счетик раунда назад, чтобы переделать шаг
    //             continue;
    //         }
    //         if (score >= maxLimit) // Условие для проверки лимита введенего счетчика и валидаций чисел (не больше 1000)
    //         {
    //             Console.WriteLine("Error");
    //             Console.ReadKey();
    //             i--; // Отматываем счетик раунда назад, чтобы переделать шаг
    //             continue;
    //         }

    //         scoreLeaderBoard[i] = score;
    //     }
    //     Console.WriteLine("\n= Result output ="); // Выведем результат


    //     for (int i = 0; i < scoreLeaderBoard.Length; i++) // Снова вызовем массив
    //     {
    //         if (scoreLeaderBoard[i] > maxScore) // Если массив равен очкам (0) и он будет больше 0, то (0) = массиву (управляется массивом)
    //         {
    //             maxScore = scoreLeaderBoard[i];
    //         }
    //         Console.WriteLine($"in cell [{i}] the amount of scores equals to {scoreLeaderBoard[i]}");
    //     }
    //     Console.WriteLine($" Maximal round score: {maxScore}");

    //     Console.ReadKey();


    // }

    // вместо int < 3 можно написать int < Apples.length и это будет равняться реальному КОЛ-ВУ предметов в коробке.
    // Реальный индекс будет всегда на 1 меньше (<=) длины (например всего 4 индекса ведь он начинается с 0 но по факту длина списка (массива) 5)
    // Условные переменные i < 3 нужны просто для того чтобы вывело все предметы но не прыгнуло на несуществующий индекс.
}


