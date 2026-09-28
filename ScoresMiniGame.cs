using System.Globalization;
namespace MyConsoleApp;

public class Car
{
    public string? Model { get; set; }
    public string? Color { get; set; }
    public int HorsePower { get; set; }

    // Конструктор класса (в круглых скобках указываются параметры которые обязательно нужно дать при созданий машины)
    // Обычно называются также как свойства но с маленькой буквы вполне можно
    public Car(string? model, string? color, int horsepower)
    {
        Model = model;
        Color = color;
        HorsePower = horsepower;

        if (horsepower <= 0)
        {
            Console.WriteLine($"Установленная минимальная мощность 1 ваших автомобилей: {Model}");
            HorsePower = 1;
        }
        Console.WriteLine($"Выпущена новая марка машины - {Model}"); // Любая логика выполняющаяся при рождений обьекта
        Console.WriteLine();
    }

}

class Program
{
    static void Main(string[] args)
    {
        List<Car> Garage = new List<Car>(); // Обычный динамический массив (лист список)

        Garage.Add(new Car("BMW M5", "Черный", 0)); // Разница в отсутствий громоздкого кода и фигурных скобок (new Item{ Name = "..."})
        Garage.Add(new Car("Audi RS6", "Синий", 0));
        Garage.Add(new Car("Lada Granta", "Белый", 90));

        while (true)
        {
            Console.WriteLine("1 - Получить список всех машин в гараже");
            Console.WriteLine("2 - Заполнить список пожеланиями");
            Console.WriteLine("3 - Выйти из программы");


            string? command = Console.ReadLine();

            switch (command)
            {
                case "1":
                    for (int i = 0; i < Garage.Count; i++)
                    {
                        Console.WriteLine($"Машина {Garage[i].Model} с цветом {Garage[i].Color} и мощностью {Garage[i].HorsePower} в вашем гараже");
                    }
                    break;
                case "2":
                    Console.WriteLine("== Заполнение гаража == ");
                    if (Garage.Count >= 5)
                    {
                        Console.WriteLine("Ошибка: Максимальное вместилище хранилища = 5");
                        Console.ReadKey();
                        continue;
                    }
                    Console.WriteLine("Введите название новой машины");
                    string? car1 = Console.ReadLine();

                    if (int.TryParse(car1, out int carModel) == true || string.IsNullOrWhiteSpace(car1))
                    {
                        Console.WriteLine("Ошибка: Неккоректное название марки машины");
                        Console.ReadKey();
                        continue;
                    }

                    bool isDuplicated = false;

                    for (int i = 0; i < Garage.Count; i++)
                    {
                        if (Garage[i].Model == car1)
                        {
                            Console.WriteLine("Ошибка: Вы не можете повторно вписать сюда существующую модель");
                            Console.ReadKey();
                            isDuplicated = true;
                            break;
                        }
                    }
                    if (isDuplicated)
                    {
                        continue;
                    }

                    Console.Write("Введите цвет машины: (Черный, Синий, Белый): ");
                    string? color1 = Console.ReadLine();

                    if (color1 != "Черный" && color1 != "Синий" && color1 != "Белый")
                    {
                        Console.WriteLine("Ошибка: Такой цвет не производится у нас");
                        Console.ReadKey();
                        continue;
                    }

                    Console.Write("Введите лошадиные мощности машины: ");
                    string? HorseP = Console.ReadLine();

                    if (int.TryParse(HorseP, out int HorsePow) == false || string.IsNullOrWhiteSpace(HorseP) || HorsePow < 0)
                    {
                        Console.WriteLine("Ты уебан тупой");
                        Console.ReadKey();
                        continue;
                    }

                    Garage.Add(new Car(car1, color1, HorsePow));

                    for (int i = 0; i < Garage.Count; i++)
                    {
                        Console.WriteLine($"\n[УСПЕХ]:  {Garage[i].Model} успешно припаркован в гараж");
                    }
                    Console.ReadKey();

                    break;
                case "3":
                    return;
            }

        }
    }
}