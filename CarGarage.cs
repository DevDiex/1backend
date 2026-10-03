using System.Globalization;
namespace MyConsoleApp;

public class Car
{
    public string? Model { get; private set; } // без set; можем вывести значение объекта в отдельном классе в Console.WriteLine(); но там же нельзя будет использовать обращение к классу и его свойству через наше имя например Car myCar и myCar.Model = "...." - нельзя
    public string? Color { get; private set; }
    public int HorsePower { get; private set; } 

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
        Console.WriteLine();
    }


    public void Repaint(string newColor) // отдельный метод хранящий в себе переменную текста для Смены цвета
    {
        Color = newColor;
    }

}

public class GarageManager
{


    private List<Car> Garage { get; set; } = new List<Car>();

    public GarageManager()
    {
        // Три машины вызванные 1-ым конструктором с 3-емя параметрами
        Garage.Add(new Car("BMW", "Синий", 600));
        Garage.Add(new Car("Lada Granta", "Желтый", 495));
        Garage.Add(new Car("Audi R6", "Фиолетовый", 333));

        Garage.Add(new Car("Фиолетовый")); // Вызов 2-ого конструктора класса Car с 1 параметром
    }

    // метод перебора который засорял прошлый метод Main внутри класса Program
    public void ShowAllCars()
    {
        Console.WriteLine("\n -- Список всех машин в гараже--");

        if (Garage.Count == 0)
        {
            Console.WriteLine("Гараж абсолютно пуст");
            return;
        }

        for (int i = 0; i < Garage.Count; i++)
        {
            // Менеджер просит вызвать свой собственный метод вывода существующий у каждой машины
            Garage[i].PrintInfo();
        }
    }


    public bool AddCarToGarage(Car newCar)
    {

        if (Garage.Count >= 5)
        {
            return false; // Завершение метода, машина не добавляется
        }
        Garage.Add(newCar);
        return true;
    }

    public void TryRepaintCar(string? targetModel, string? newColor) // отдельно прописанная логика case "3" (в скобках ровно два значения текстовых ведь перекраска машины - текст)
    {
        if (string.IsNullOrWhiteSpace(newColor))
        {
            Console.WriteLine("Ошибка: Неверный цвет");
            return;
        }

        bool carFound = false;

        for (int i = 0; i < Garage.Count; i++)
        {
            if (Garage[i].Model == targetModel)
            {   
                Garage[i].Repaint(newColor);

                carFound = true;
                break; // Останавливаем цикл ведь машина найдена и покрашена
            }
        }
        if (!carFound)
        {
            Console.WriteLine($"Машина марки {targetModel} не найдена в гараже");
        }
    }

    public bool IsCarExists(string? model)
    {
        for (int i = 0; i < Garage.Count; i++)
        {
            if (Garage[i].Model == model)
            {
                return true;
            }
        }
        return false; // Если прошлись по всему списку и ничего не нашли
    }
}

class Program
{
    static void Main(string[] args)
    {
        GarageManager manager = new GarageManager();

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

                    // Чистое ООП без циклов в методе Main основного интерфейс класса - менеджер просто выводит список через обращение к классу менеджера который содержит в листе тип данных списка с его установленными правилами

                    manager.ShowAllCars();
                    Console.ReadKey();
                    break;


                case "2":
                    Console.WriteLine($"\n - Заполнение гаража - ");

                    Console.Write("Введите название нашей машины: ");
                    string? carName = Console.ReadLine();

                    if (int.TryParse(carName, out int num1) == true || string.IsNullOrWhiteSpace(carName))
                    {
                        Console.WriteLine("Ошибка: Некорректное название марки машины");
                        Console.ReadKey();
                        continue;
                    }

                    if (manager.IsCarExists(carName)) // Вызов класса GarageManager через вызов его имени maanger который проверяет уже существующие машины с помощью метода IsCarExists
                    {
                        Console.WriteLine("Ошибка: Машина с таким названием уже существует");
                        Console.ReadKey();
                        continue;
                    }

                    Console.Write("Введите цвет машины (Черный, Синий, Белый): ");
                    string? carColor = Console.ReadLine();


                    if (carColor != "Черный" && carColor != "Синий" && carColor != "Белый")
                    {
                        Console.WriteLine("Ошибка: Такой цвет не производится на нашем заводе");
                        Console.ReadKey();
                        continue;
                    }

                    Console.Write("Введите мощность: ");

                    string? HorseP = Console.ReadLine();

                    if (int.TryParse(HorseP, out int HorsePowers) == false || string.IsNullOrWhiteSpace(HorseP) || HorsePowers < 0)
                    {
                        Console.WriteLine($"Ошибка ввода мощности");
                        Console.ReadKey();
                        continue;
                    }

                    Car userCar = new Car(carName, carColor, HorsePowers); // Создание новой машины по чертежу Car (первому классу) - вызовом первого конструктора

                    // Связывание отдачей созданной машины менеджеру
                    // Менеджер проверит сам внутри себя лимит (count >= 5) и положит ее в свой список
                    manager.AddCarToGarage(userCar);
                    Console.ReadKey();
                    break;

                case "3":

                    Console.WriteLine("Цех покраски");

                    Console.Write("Введите машину которую хотите перекрасить");
                    string? carModel = Console.ReadLine();

                    Console.Write("Введите новый цвет: ");
                    string? newColor = Console.ReadLine();

                    manager.TryRepaintCar(carModel, newColor);
                    Console.ReadKey();
                    break;

                // Кейс становится компатным и ему становится достаточно компактной логики через ввод в строке и остальную логику на себя берет класс менеджер (внутренню)
                // остальные значения подставляются по-ходу событий из скобок нашего метода string в то что 

                case "4":
                Console.WriteLine("Все будет хорошо...");
                return;
            }
        }
    }
}
// логика вызова классов и их методов проста - есть класс Car и ему нужно выделить память под функционал класса и вызов методов этого класса все что внутри него идет через точку
// То есть мы обращаемся к любому классу или классу Car и выдаем ему название а внутри уже тут можем ссылаться на все методы функций класса через точку (например manager.TryRepaintCar)?
// В том числе можно ссылаться на класс и после выдачи имени через new вызывать конструктор (внимательно смотреть на переменные внутри скобок - 1/2/3/4 и тд соблюдать тип данных)