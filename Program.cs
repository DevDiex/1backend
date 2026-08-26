using System.Globalization;
namespace MyConsoleApp;

class Program
{
    static void Main(string[] args)
    {


        // ПОД СКАЗКА ПО WHILE:
        // 1. Использовать, когда НЕ знаешь заранее, сколько раз выполнится код (пока не введут 'exit', пока не скачается файл).
        // 2. Если внутри while(true) нет break или continue — программа зависнет навсегда.
        // 3. НЕ использовать вместо if для простых одиночных проверок.

        while (true) // бесконечный цикл крутящий код внутри {} чтобы из него выйти нужен оператор break и чтобы прыгнуть в него игнорируя код снизу нужен continue;
        {
            Console.Write("Введите первое число: "); // Write не переносит строку как Enter как WriteLine
            string? input1 = Console.ReadLine(); // Считываем что ввели на клавиатуре и сохраняем как строку из текста

            // перевод системы на CultureInfo.InvariantCulture дает возможность системе работать на неизменной культуре (она будет ждать в дробях точку вместо запятой)
            if (double.TryParse(input1, CultureInfo.InvariantCulture, out double num1) == false) // Сразу переводим в число (если ввели букву - ошибка) и out int num1 удобно на лету создать переменную.
            {
                Console.WriteLine("Ошибка");
                Console.ReadKey(); // Ждем нажатия кнопки

                continue; // Возвращаем принудительно программу в самое начало цикла while

            }

            Console.WriteLine("Что вводим? (+, -, *, /, exit,); ");
            string? op = Console.ReadLine(); // Считываем введеный математический знак (+, -, *, /, exit) и сохраняем в строку op

            if (op == "exit")
            {
                break;
            }

            // Запросим второе число
            Console.Write("Введите второе число: ");
            string? input2 = Console.ReadLine();

            if (double.TryParse(input2, CultureInfo.InvariantCulture, out double num2) == false)
            {
                Console.WriteLine("Ошибка");
                Console.ReadKey();

                continue;
            }
            double result = 0;

            result = CalculNum(num1, num2, op);

            if (op == "/" && num2 == 0)
            {
                Console.WriteLine("Ошибка: На ноль делить нельзя");
                Console.ReadKey();
                continue; // Сбрасываем круг не заходя в вычисления
            }

            Console.WriteLine($"Результат операций: {result}");
            Console.WriteLine($"Нажми любую кнопку для следующего круга...");
            Console.ReadKey();

        }
        // Условия (conditions - if/else if) проверяемые компом сверху вниз (from top to bottom)
        // если сработает один if остальные компьютер скипнет.
        // == проверка сравнение (точно ли) а не присвоение как =
    }
    // изменили переменную (типа данных) int на double для хранения дробей калькулятора без округления до 2 или 3 (5/2 = 2.5 а не 2)
    // string? op знак вопроса (не обычная переменная string хранящая текст) нужен для хранения вероятности того что значение (переменная) может быть равно null, защищена от падения.
    static double CalculNum(double a, double b, string? op)
    {
        double result = 0;

        switch (op)
        {

            case "+": result = a + b; break;
            case "-": result = a - b; break;
            case "*": result = a * b; break;
            case "/":
                {
                    if (b != 0)

                        result = a / b;
                    break;

                }
        }

        return result;

    }

}
// Main главная точка входа в программу с которой все начинается (в бэкэнде так не пишут).