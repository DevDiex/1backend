using System.Globalization;
namespace MyConsoleApp;

public class Car
{
    public string? Model { get; set; }
    public string? Color { get; set; }
    public int HorsePower { get; set; }

    // Конструктор класса (в круглых скобках указываются параметры которые обязательно нужно дать при созданий машины)
    // Обычно называются также как свойства но с маленькой буквы вполне можно
    public Car(string? model, string? color, int horsepower) // - круглые скробки () вызов конструктора а {} скобки - вызов инициализатора
    {

        Model = model;
        Color = color;
        HorsePower = horsepower;

        if (HorsePower <= 0)
        {
            Console.WriteLine($"Установленная минимальная мощность 1 ваших автомобилей: {Model}");
            HorsePower = 1;
        }
    }

    // Сборка заводской машины по умолчанию (перегрузка). Цвет и мощность выставляется языком, будет просить только модель
    public Car(string? color) // перегрузка конструкторами на примере (можно вместить какие то свойства которые мы можем заранее заполнить в отдельном классе, а какие уже заполнены)

    {

        Model = "Жигуль";
        Color = color;
        HorsePower = 90;

        Console.WriteLine("Собран базовый автомобиль по умолчанию");

    }
    public void PrintInfo()
    {
        // Т.к. как метод внутри класса создается необязательно наличие индексов [i]
        Console.WriteLine($"[ГАРАЖ]: Автомобиль {Model} | Цвет: {Color} | Мощность: {HorsePower}");
    }


    public void Repaint(string newColor)
    {
        Color = newColor;

        Console.WriteLine($"Тюнинг: Машина {Model} успешно перекрашена - новый цвет {Color}");
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

        Garage.Add(new Car("Розовый")); // Компьютер просматривает наши конструкторы в отдельном классе и выбирает подходящий по условиям (1 строка требует заполнения, а остальные заполнены по заводским настройкам/по конструктору)

        while (true)
        {
            Console.WriteLine("1 - Получить список всех машин в гараже");
            Console.WriteLine("2 - Заполнить список пожеланиями");
            Console.WriteLine("3 - Перекрасить машину в гараже");
            Console.WriteLine("4 - Выйти из программы");


            string? command = Console.ReadLine();

            switch (command)
            {
                case "1":
                    for (int i = 0; i < Garage.Count; i++)
                    {
                        Garage[i].PrintInfo(); // какая-либо машина под индексом [i] сама выполнит свой внутренний метод
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

                    Car newcar = new Car(car1, color1, HorsePow);
                    // Car - Тип данных который берется за шаблон
                    // newCar - Название переменной
                    // = - связывание имени переменной с созданным обьектом
                    // new - вызов конструктора 

                    Console.WriteLine($"Ваш {newcar.Model} был добавлен в гараж");
                    Garage.Add(newcar);
                    Console.ReadKey();

                    break;
                case "3":
                    Console.WriteLine("Цех покраски");
                    Console.Write("Введите модель машины которую хотите перекрасить: ");
                    string? targetModel = Console.ReadLine();

                    bool carFound = false;

                    for (int i = 0; i < Garage.Count; i++)
                    {
                        if (Garage[i].Model == targetModel)
                        {
                            Console.Write($"в какой цвет желаете перекрасить {Garage[i].Model}: ");
                            string? userColor = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(userColor)) // Если наша targetModel пуста или был нажат пробел
                            {
                                Console.WriteLine("Строка не может быть пустой");
                                Console.ReadKey();
                                break;
                            }

                            Garage[i].Repaint(userColor); // Вызов метода перекраски (userColor является новым цветом) у конкретной найденной машины

                            carFound = true;
                            Console.ReadKey();
                            break; // Машина перекрашена, останавливаем поиск
                        }
                    }

                    if (!carFound) // Если машина не найдена
                    {
                        Console.WriteLine("Ошибка: Такой машины в гараже нету");
                        Console.ReadKey();
                    }
                    break;

                case "4":
                    return;
            }

        }
    }
}