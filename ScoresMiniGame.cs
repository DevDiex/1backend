using System.Globalization;
namespace MyConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        List<string> CalledNames = new List<string>();

        CalledNames.Add("Eugene | Admin | 9 | Екатеринбург");
        CalledNames.Add("Maria | Guest | 11 | Москва");
        CalledNames.Add("Renat | Guest | 5 | Италия");
        CalledNames.Add("Obama | Admin | 2 | Екатеринбург");
        CalledNames.Add("Jewes | Guest | 14 | Иран");

        while (true)
        {
            Console.WriteLine($"== Система Контроля Доступа ");
            Console.WriteLine($"1 - Показать все логи ");
            Console.WriteLine($"2 - Показать только Админов из Екатеринбурга ");
            Console.WriteLine($"3 - Удалить гостей, пришедших позже 10:00    ");
            Console.WriteLine($"4 - Выйти (STOP) ");
            Console.WriteLine("");
            Console.WriteLine("Выберите опцию: ");

            ProcessMenu(CalledNames);

        }
    }
    static void ProcessMenu(List<string> logs)
    {
        string? option = Console.ReadLine();

        switch (option)
        {
            case "1":
                for (int i = 0; i < logs.Count; i++)
                {
                    Console.WriteLine($"Все логи: {logs[i]}");
                }
                break;
            case "2":
                for (int i = 0; i < logs.Count; i++)
                {
                    if (logs[i].Contains("Admin"))
                    {
                        Console.WriteLine($"{logs[i]}");
                    }
                }
                break;
            case "3":
                for (int i = logs.Count - 1; i >= 0; i--)
                {
                    string[] names = logs[i].Split("|");

                    // Теперь у нас автоматически:
                    // parts[0] - имя ("Maria")
                    // parts[1] - статус ("Guest")
                    // parts[2] - время ("11")
                    // parts[3] - Город (или страна - Америка)

                    int time = int.Parse(names[2].Trim());

                    if (names[1].Contains("Guest") && time > 10)
                    {
                        logs.RemoveAt(i);
                    }

                }
                break;
            case "4":
                Console.WriteLine("ВВЕДИТЕ STOP");
                string? input1 = Console.ReadLine();
                if (input1 == "STOP")
                {
                    Environment.Exit(0);
                }
                break;
        }
    }
}