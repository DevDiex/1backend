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