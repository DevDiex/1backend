using System.Globalization;
namespace MyConsoleApp;

class Program
{
    static void Main(string[] args)
    {

        while (true)
        {

            int maxLimit = 1000;
            int maxScore = 0;

            int[] scoreLeaderBoard = new int[5];
            Console.WriteLine("= Заполнение таблицы =");

            for (int i = 0; i < scoreLeaderBoard.Length; i++)
            {
                Console.WriteLine($"Введите очки от от 1 до 1000: [{i + 1}]");
                string? input1 = Console.ReadLine();

                if (int.TryParse(input1, CultureInfo.InvariantCulture, out int score) == false)
                {

                    Console.WriteLine("Ошибка");
                    Console.ReadLine();
                    i--;
                    continue;
                }
                if (score >= maxLimit)
                {
                    Console.WriteLine("Ошибка");
                    Console.ReadKey();
                    continue;
                }

                scoreLeaderBoard[i] = score;
            }
            Console.WriteLine("\n= Вывод Результата =");


            for (int i = 0; i < scoreLeaderBoard.Length; i++)
            {
                if (scoreLeaderBoard[i] > maxScore)
                {
                    maxScore = scoreLeaderBoard[i];
                }
                Console.WriteLine($"Теперь в ячейке [{i}] лежит {scoreLeaderBoard[i]}");
            }
            Console.WriteLine($" Максимальный результат раунда: {maxScore}");

            Console.ReadKey();


        }

        // вместо int < 3 можно написать int < Apples.length и это будет равняться реальному КОЛ-ВУ предметов в коробке.
        // Реальный индекс будет всегда на 1 меньше (<=) длины (например всего 4 индекса ведь он начинается с 0 но по факту длина списка (массива) 5)
        // Условные переменные i < 3 нужны просто для того чтобы вывело все предметы но не прыгнуло на несуществующий индекс.
    }
}
