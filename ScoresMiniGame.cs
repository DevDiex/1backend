using System.Globalization;
namespace MyConsoleApp;

// Класс (class) - просто чертеж, шаблон. Ничего не делает кроме обьяснения компьютеру - если хотим создать сотрудника у него обязательно должны быть такие свойства
// public - публичный, Позволяет читать компьютеру и менять данные из любой точки программы (если не писать public class - ничего страшного), внутри обязательно писать publc иначе не сможет из отдельного метода и класса вызываться.
public class EmployeeLog
{
    public string? Name { get; set; } = string.Empty;
    public string? Status { get; set; } = string.Empty;
    public int Time { get; set; } // Числа (int) по умолчанию равны 0, тут предупреждения нет
    public string? City { get; set; } = string.Empty;
}
class Program
{
    static void Main(string[] args)
    {
        // Создание списка обьектов вместо списка безликих строк.
        List<EmployeeLog> CalledNames = new List<EmployeeLog>();

        // new - команда: Выделить память и создать новый живой обьект по чертежу EmployeeLog

        CalledNames.Add(new EmployeeLog { Name = "Eugene", Status = "Admin", City = "Мосвка", Time = 10 });
        CalledNames.Add(new EmployeeLog { Name = "Krabst", Status = "Guest", City = "Екатеринбург", Time = 11 });
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
                    // Убираем trim() и Contains (относящееся к List<>) ведь теперь мы работаем с фиксированными функциями/обьектами (int, string. etc) записанные в нашем отдельном классе


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

// Свойство точка (.) - Главный инструмент ООП
// Когда элемент лежит в списке, компьютер знает что logs[i] - не просто текст а целый обьект
// поставив точку после уточнения обьекта мы можем получить доступ к его внутренностям
// logs[i].Name - Вытащит имя
// logs[i].Time - Вытащит имя, по итогу мы избавляемся от склейки ручной строк split("|") и Trim() и не рискуем ошибиться с индексами + Данные типизированы и легко считаются человеком + защищены