using System.Globalization;
namespace MyConsoleApp;

public class Item
{
    public string? Name { get; set; } = string.Empty; // Название Предмета
    public string? Rarity { get; set; } = string.Empty; // Редкость
    public int DamageBonus { get; set; } // Бонус к атаке
}

class Program
{
    static void Main(string[] args)
    {
        List<Item> Inventory = new List<Item>();

        Inventory.Add(new Item { Name = "Ржавый кинжал", Rarity = "Basic", DamageBonus = 2 });
        Inventory.Add(new Item { Name = "Посох Огня", Rarity = "Rare", DamageBonus = 15 });
        Inventory.Add(new Item { Name = "Испепелитель", Rarity = "Epic", DamageBonus = 45 });



        while (true)
        {
            Console.WriteLine("-- ИНВЕНТАРЬ ГЕРОЯ--");
            Console.WriteLine("1 - Показать весь инвентарь");
            Console.WriteLine("2 - Показать только Эпические предметы");
            Console.WriteLine("3 - Введите предмет в инвентарь");
            Console.WriteLine("4 - Выйти из игры");
            Console.Write("Выберите опцию: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("-- Ваши предметы --");
                    for (int i = 0; i < Inventory.Count; i++)
                    {
                        Console.WriteLine($"[{Inventory[i].Rarity}], [{Inventory[i].Name}], [{Inventory[i].DamageBonus}]");
                    }
                    break;
                case "2":
                    Console.WriteLine("-- Ваши эпические предметы --");
                    for (int i = 0; i < Inventory.Count; i++)
                    {
                        if (Inventory[i].Rarity == "Epic")
                        {
                            Console.WriteLine($"{Inventory[i].Name}. Его урон [{Inventory[i].DamageBonus}] и его редкость [{Inventory[i].Rarity}]");
                        }
                    }
                    break;
                case "3":
                    if (Inventory.Count >= 5)
                    {
                        Console.WriteLine("Ошибка! инвентарь заполнен");
                        Console.ReadKey();
                        break;
                    }

                    Console.WriteLine("== Добавление предмета");

                    Console.Write("Введите название предмета: ");
                    string? item1 = Console.ReadLine();

                    if (int.TryParse(item1, out int num1) == true || string.IsNullOrWhiteSpace(item1))
                    {
                        Console.WriteLine("Ошибка: Некоректное название предмета ");
                        Console.ReadKey();
                        continue;
                    }

                    bool isDuplicate = false; // Флаг проверки

                    for (int i = 0; i < Inventory.Count; i++)
                    {
                        if (Inventory[i].Name == item1)
                        {
                            Console.WriteLine("Ошибка: Предмет уже существует");
                            Console.ReadKey();
                            isDuplicate = true;
                            break; // Выход из цикла for ведь дубликат найден
                        }
                    }

                    if (isDuplicate)
                    {
                        continue;
                    }

                    Console.Write("Введите редкость из выпадающего списка: (Basic, Rare, Epic): ");
                    string? Rarity2 = Console.ReadLine();

                    if (Rarity2 != "Basic" && Rarity2 != "Rare" && Rarity2 != "Epic")
                    {
                        Console.WriteLine("Ошибка: Неверная редкость.");
                        Console.ReadKey();
                        continue;
                    }

                    Console.WriteLine("введите бонус к атаке предмету");
                    string? command1 = Console.ReadLine();

                    if (int.TryParse(command1, out int damage) == false || damage < 0)
                    {
                        Console.WriteLine("Ошибка: Неверное значение");
                        Console.ReadKey();
                        continue;
                    }



                    Item newItem = new Item
                    {
                        Name = item1,
                        Rarity = Rarity2,
                        DamageBonus = damage
                    };
                    Inventory.Add(newItem);
                    Console.WriteLine($"Предмет [{newItem.Name}], ({newItem.Rarity}) с уроном +{newItem.DamageBonus} добавлен в инвентарь.");
                    Console.WriteLine($"Мест занято: {Inventory.Count}/5");
                    Console.ReadKey();
                    break;


                case "4":
                    Console.WriteLine("Выход из игры...");
                    return; // Завершаем метод Main и закрываем программу
            }
        }
    }
}