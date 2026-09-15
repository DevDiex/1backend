using System.Globalization;
namespace MyConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        List<string> NamesMain = new List<string>();

        NamesMain.Add("Admin_Darmek");
        NamesMain.Add("Admin_Remlik");
        NamesMain.Add("Dima");
        NamesMain.Add("Ivan");
        NamesMain.Add("Admin_SanyaSinShluxi");

        while (true)
        {



            Console.WriteLine("\n Введите имя пользователя или выйдите из программы командой STOP: ");
            string? Names = Console.ReadLine() ?? "";
            if (Names == "STOP")
            {
                break;
            }

            if (int.TryParse(Names, out int Namenum) == true)

            {
                Console.WriteLine("Error");
                Console.ReadKey();
                continue;

            }

            if (Names == "")
            {
                Console.Write("Ошибка: Для повторной попытки нажмите любую клавишу  ");
                Console.ReadKey();
                continue;
            }
            bool isUserAdmin = Names.StartsWith("Admin_");

            if (isUserAdmin)
            {
                Console.WriteLine($"Вы админ - вот вам все известные админы: ");
            }
            else
            {
                Console.WriteLine("Вы обычный гость: Вот список");
            }

            foreach (string Nemesis in NamesMain)
            {
                bool ListContainAdmin = Nemesis.StartsWith("Admin_");

                if (isUserAdmin && ListContainAdmin)
                {
                    Console.WriteLine($"- {Nemesis}");
                }
                else if (!isUserAdmin && !ListContainAdmin)
                {
                    Console.WriteLine($"- {Nemesis}");
                }
            }

            Console.WriteLine(" - Введите команду для использования функций - ");
            string? op2 = Console.ReadLine();

            if (op2 == "-%Ad.Cls%-")
            {
                bool UserIsAdmin = Names.StartsWith("Admin_");

                for (int i = 0; i < NamesMain.Count; i++)
                {
                    if (!UserIsAdmin || UserIsAdmin)
                    {
                        NamesMain.Remove("Admin_Darmek");
                        NamesMain.Remove("Admin_Remlik");
                        NamesMain.Remove("Admin_SanyaSinShluxi");
                    }

                    Console.WriteLine($"Sorted Names: {NamesMain[i]}");
                }
            }

        }
    }
}

