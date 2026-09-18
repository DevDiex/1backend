// using System.Globalization;
// namespace MyConsoleApp;

// class Program
// {
//     static void Main(string[] args)
//     {

//         List<string> Names = new List<string>();


//         Names.Add("NameIs");
//         Names.Remove("NameIs");

//     }

// }




// List<string> serverLogs = new List<string>();

//     serverLogs.Add("INFO: Server Started"); // 0
//     serverLogs.Add("Warning: Low Memory"); // 1
//     serverLogs.Add("ERROR: Database connection failed"); // 2
//     serverLogs.Add("INFO: User logged in"); // 3
//     serverLogs.Add("ERROR: Access denied"); // 4
//     // 5 обьектов

//     while (true)
//     {

//         Console.WriteLine("Выберите опцию: 1 - Показать Все логи");
//         Console.WriteLine("Выберите опцию: 2 - Показать Только Ошибки");
//         Console.WriteLine("Выберите опцию: 3 - Удалить все предупреждения");
//         Console.WriteLine("Выберите опцию: 4 - Выйти (STOP)");

//         Output(serverLogs);

//     }
// }

// static void Output(List<string> strings)
// {
//     string? Optionic1 = Console.ReadLine();

//     switch (Optionic1)
//     {
//         case "1":
//             for (int i = 0; i < strings.Count; i++)
//             {
//                 Console.WriteLine($"Ваши логи: {strings[i]}");
//                 Console.WriteLine("");
//             }
//             break;
//         case "2":
//             for (int i = 0; i < strings.Count; i++)
//             {
//                 if (strings[i].StartsWith("ERROR:"))
//                 {
//                     Console.WriteLine($"Ваши ошибки: {strings[i]}");
//                 }
//             }
//             break;
//         case "3":
//             for (int i = strings.Count - 1; i >= 0; i--)
//             {
//                 if (strings[i].StartsWith("Warning:"))
//                 {
//                     strings.RemoveAt(i);
//                 }
//             }

//             Console.WriteLine($"Предупреждения удалены: Оставшиеся логи сервера");
//             for (int i = 0; i < strings.Count; i++)
//             {
//                 Console.WriteLine($"Ваши логи {strings[i]}");
//             }

//             break;
//         case "4":
//             string? Checker = Console.ReadLine();
//             if (Checker == "STOP")
//             {
//                 Environment.Exit(0);
//             }
//             break;

//     }