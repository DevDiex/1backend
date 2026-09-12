using System.Globalization;
namespace MyConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        // Первое знакомство после массивов со списками (List<>)

        List<string> ShopTask = new List<string>();


        // Добавление элементов в конец списка

        ShopTask.Add("Alexey");
        ShopTask.Add("Roman");
        ShopTask.Add("Dima");
        ShopTask.Add("Riba");
        ShopTask.Add("LAMA");

        for (int i = 0; i < ShopTask.Count; i++)
        {
            for (int j = 0; j < ShopTask.Count - 1 - i; j++)
            {
                if (ShopTask[j].CompareTo(ShopTask[j + 1]) < 0)
                {
                    string temp = ShopTask[j];
                    ShopTask[j] = ShopTask[j + 1];
                    ShopTask[j + 1] = temp;
                }

            }

        }
        Console.WriteLine($" -- Sorted list -- ");

        foreach (string name in ShopTask)
        {
            Console.WriteLine($"Result are easy of {name}");
        }










        // Узнать кол-во элементов
        //         int NamesAmount = ShopTask.Count; // Вернет 5

        //         string ListStart = ShopTask[0]; // Начало чтения по индексу (как в массиве)


        //         // Удаление элемента по значению (тексту) 
        //         ShopTask.Remove("Dima");

        //         // Удаление по индексу
        //         ShopTask.RemoveAt(0);

        // Console.WriteLine($"Your names are in here {ShopTask[1]}");

    }
}



