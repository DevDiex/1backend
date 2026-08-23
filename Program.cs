namespace MyConsoleApp;

class Program
{
    static void Main(string[] args)
    {

        while (true) // бесконечный цикл крутящий код внутри {} чтобы из него выйти нужен оператор break и чтобы прыгнуть в него игнорируя код снизу нужен continue;
        {
            Console.Write("Введите первое число: "); // Write не переносит строку как Enter как WriteLine
            string? input1 = Console.ReadLine(); // Считываем что ввели на клавиатуре и сохраняем как строку из текста

            if (int.TryParse(input1, out int num1) == false) // Сразу переводим в число (если ввели букву - ошибка) и out int num1 удобно на лету создать переменную.
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

            if (int.TryParse(input2, out int num2) == false)
            {
                Console.WriteLine("Ошибка");
                Console.ReadKey();

                continue;
            }
            int result = 0;

            if (op == "+")
            {
                result = num1 + num2;
            }
            else if (op == "-")
            {
                result = num1 - num2;
            }
            else if (op == "*")
            {
                result = num1 * num2;
            }

            else if (op == "/")
            {
                result = num1 / num2;
            }
            // Условия (conditions - if/else if) проверяемые компом сверху вниз (from top to bottom)
            // если сработает один if остальные компьютер скипнет.
            // == проверка сравнение (точно ли) а не присвоение как =
            Console.WriteLine($"Результат операций: {result}");
            Console.WriteLine($"Нажми любую кнопку для следующего круга...");
            Console.ReadKey();
        }
    }
    // Main главная точка входа в программу с которой все начинается (в бэкэнде так не пишут)
}