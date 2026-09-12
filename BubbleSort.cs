// Console.WriteLine("First main Array");
// int[] scores = { 950, 231, 120, 433 };

// Console.WriteLine($"Original array:");
// PrintArray(scores);

// BubbleSort(scores);

// Console.WriteLine("\nSorted array");
// PrintArray(scores);

// Console.ReadKey();

// static void PrintArray(int[] arr)
// {
//     for (int i = 0; i < arr.Length; i++)
//     {
//         Console.WriteLine(arr[i]);
//     }
//     Console.WriteLine();
// }

// static void BubbleSort(int[] arr) // Изолированный метод сортировки (работает с массивом)
// {
//     for (int p = 0; p < arr.Length; p++) // внешний цикл отвечает за кол-во полных проходов по массиву.
//     {
//         // Внутренний цикл бегающий по элементам и сравнивающий соседей (arr[i] >=< arr[i + 1])
//         for (int i = 0; i < arr.Length - 1; i++) // важно писать arr.Length - 1, чтобы i + 1 не вылетало за пределы границ массива
//         {
//             if (arr[i] < arr[i + 1])
//             {
//                 int temp = arr[i]; // Создаем временной стакан
//                 arr[i] = arr[i + 1]; // В освободившийся arr[i] переливаем из arr[i + 1]
//                 arr[i + 1] = temp; // в arr[i + 1] выливаем из временного стакана жидкость
//             }
//         }
//     }
// }