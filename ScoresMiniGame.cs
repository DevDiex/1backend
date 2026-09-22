using System.Globalization;
namespace MyConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        List<EmployeeLog> CalledNames = new List<EmployeeLog>();

        CalledNames.Add(new EmployeeLog { Name = "Eugene", Status = "Admin", City = "Мосвка", Time = 10 });
        CalledNames.Add(new EmployeeLog { Name = "Krabst", Status = "Guest", City = "Екатеринбург", Time = 5 });
        CalledNames.Add(new EmployeeLog { Name = "Evgene", Status = "Admin", City = "Москва", Time = 15 });
        CalledNames.Add(new EmployeeLog { Name = "Mariana", Status = "Guest", City = "seventeen", Time = 5 });
        CalledNames.Add(new EmployeeLog { Name = "DeanW", Status = "Admin", City = "Сан-Франциско", Time = 15 });

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("== Система Контроля Доступа ==");
            Console.WriteLine("1 - Показать все логи");
            Console.WriteLine("2 - Показать только Админов из Екатеринбурга");
            Console.WriteLine("3 - Удалить гостей, пришедших после 10 ");
            Console.WriteLine("4 - Выйти (STOP)");
            Console.WriteLine();
            Console.WriteLine("Выберите Опцию");

            ProcessMenu(CalledNames);
        }



    }
    static void ProcessMenu(List<EmployeeLog> logs)
    {
        string? option = Console.ReadLine();

        switch (option)
        {
            case "1":
                for (int i = 0; i < logs.Count; i++)
                {
                    Console.WriteLine($"Сотрудник : {logs[i].Name} | Статус: {logs[i].Status} | Время: {logs[i].Time}, Город: {logs[i].City}");
                }
                Console.Write("Нажмите клавишу для перезапуска программы: ");
                Console.ReadKey();

                break;

            case "2":
                for (int i = 0; i < logs.Count; i++)
                {
                    if (logs[i].Status == "Admin" && logs[i].City == "Москва")
                    {
                        Console.WriteLine($"Админ: {logs[i].Name} из города {logs[i].City}");
                    }
                }
                break;
            case "3":
                for (int i = logs.Count - 1; i >= 0; i--)
                {

                    if (logs[i].Status == "Guest" && logs[i].Time > 10)
                    {
                        Console.WriteLine($"Удален гость: {logs[i].Name}");
                        logs.RemoveAt(i); // RemoveAt вместо Remove из-за наличия удаления за счет индексов
                    }

                }
                break;

            case "4":
                Console.WriteLine("Введите STOP");
                string? command = Console.ReadLine();

                if (command == "STOP")
                {
                    Environment.Exit(0);
                }
                break;
        }
    }
}

public class EmployeeLog
{
    public string? Name { get; set; } = string.Empty;
    public string? Status { get; set; } = string.Empty;
    public int Time { get; set; }
    public string? City { get; set; } = string.Empty;
}