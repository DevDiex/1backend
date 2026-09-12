
// {
//     string?[] inventory = new string[3]; // Массив строк которые могут быть пустыми (null), на 3 ячейки (0, 1, 2)
//     inventory[1] = "Меч новичка";

//     while (true)
//     {

//         Console.WriteLine("= Инвентарь = ");

//         for (int i = 0; i < inventory.Length; i++) // Цикл перфекцонист для вывода предметов
//         {
//             // Проверяем если в ячейке значение равно (null), пишем "Пустой слот"
//             if (inventory[i] == null)
//             {
//                 Console.WriteLine($"Слот [{i}]: -- Пустой слот --");
//             }
//             else
//                 Console.WriteLine($"Слот [{i}]; {inventory[i]}");
//         }

//         bool isFull = true;

//         Console.WriteLine($"\n Enter a new item name to add to inventory");
//         string? newItem = Console.ReadLine();

//         for (int i = 0; i < inventory.Length; i++)
//         {

//             if (inventory[i] == null) // Если ячейка текстового массива пуста то
//             {
//                 inventory[i] = newItem;
//                 Console.WriteLine($"\n Item {newItem} added to your {inventory[i]}");
//                 isFull = false; // Инвентарь не заполнен мы нашли место.
//                 break;
//             }
//         }
//         if (isFull == true)
//         {
//             Console.WriteLine($"\n Error: Inventory is full: Reseting");
//             Console.ReadKey();

//             inventory[0] = null;
//             inventory[2] = null;
//             Console.WriteLine($"\n Inventory cleared, index [0] and [2] are empty");
//         }
//     }
// }
// }
