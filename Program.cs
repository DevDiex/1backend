using System.Globalization;
namespace MyConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        // Создадим массив на 3 дробных числа
        double[] userNumbers = new double[3];

        Console.WriteLine("==: ЗАПОЛНЕНИЕ МАССИВА :==");

        for (int i = 0; i < userNumbers.Length; i++)
        {
            Console.WriteLine($"Введите число для заполнения [{i}]");
            string? input = Console.ReadLine() ?? "";

            // Записываем результат TryParse прямо в userNumbers.
            double.TryParse(input, CultureInfo.InvariantCulture, out userNumbers[i]);
        }
        Console.WriteLine("\n== Вывод результата ==");

        for (int i = 0; i < userNumbers.Length; i++)
        {
            Console.WriteLine($"теперь в ячейке [{i}] лежит: {userNumbers[i]}");
        }
        Console.ReadKey();
    }

    // вместо int < 3 можно написать int < Apples.length и это будет равняться реальному КОЛ-ВУ предметов в коробке.
    // Реальный индекс будет всегда на 1 меньше (<=) длины (например всего 4 индекса ведь он начинается с 0 но по факту длина списка (массива) 5)
    // Условные переменные i < 3 нужны просто для того чтобы вывело все предметы но не прыгнуло на несуществующий индекс.
}
