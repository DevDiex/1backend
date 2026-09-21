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



// List<string> Names = new List<string>();

// Names.Add("Admin_Liciy");
// Names.Add("Mark");
// Names.Add("Gab");
// Names.Add("Mos");
// Names.Add("Admin_Karcen");

// while (true)
// {


//     Console.WriteLine("\n Введите имя пользователя или выйдите из программы командой стоп");
//     string? inputName = Console.ReadLine() ?? "";

//     if (inputName == "STOP")
//     {
//         break;
//     }

//     if (int.TryParse(inputName, out int NameNum) == true)
//     {
//         Console.WriteLine("Error");
//         Console.ReadKey();
//         continue;
//     }

//     if (inputName == "")
//     {
//         Console.WriteLine();
//         Console.ReadKey();
//         continue;
//     }
//     bool isUserAdmin = inputName.StartsWith("Admin_");

//     if (isUserAdmin)
//     {
//         Console.WriteLine($"Вы админ вот все известные вам админы");
//     }
//     else
//     {
//         Console.WriteLine($"Вы обычный гость: Вот список");
//     }

//     foreach (string Name in Names)
//     {
//         bool ListContainAdmins = Name.StartsWith("Admin_");


//         if (isUserAdmin && ListContainAdmins)
//         {
//             Console.WriteLine($"- {Name}");
//         }
//         else if (!isUserAdmin && !ListContainAdmins)
//         {
//             Console.WriteLine($"- {Name}");
//         }
//     }

//     Console.WriteLine($"Введите команду стоп для останвки программы");
//     string? Command = Console.ReadLine();

//     if (Command == "-%Ad.Cls%-")
//     {
//         bool UserIsAdmin = inputName.StartsWith("Admin_");

//         for (int i = 0; i < Names.Count(); i++)
//         {
//             if (!UserIsAdmin || UserIsAdmin)
//             {
//                 Names.Remove("Admin_Liciy");
//                 Names.Remove("Admin_Karcen");
//             }
//             Console.WriteLine($"Sorted Names: {Names[i]}");
//         }
//     }