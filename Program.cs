namespace MyConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        int o = 0;
        int a = 5;
        int b = 10;
        int c = 265;
        int h = 250;
        int g = (a + b + c + c);
        int sum = (h + h); // Баланс банка
        int sum2 = (sum - c); // (500 - 265 = 235) новый баланс банка после перевода
        int sum3 = (o + c); // сумма на нашей карте (0 + 265)
        int sum4 = sum2; // баланс банка
        Console.WriteLine($"Баланс банка равен: {sum}.");
        Console.WriteLine($"Баланс банка изменен - сумма успешно переведена: {sum2}.");
        Console.WriteLine($"Сумма на карте равна: {sum3}.");

        if (sum3 >= h)
        {
            int sum5 = (sum3 - h);
            Console.WriteLine($"Покупка успешна, Сумма списана! {sum5}.");
        }
        else
            Console.WriteLine($"Недостаток средств: СУММА НЕ МОЖЕТ БЫТЬ СПИСАНА (тест)");
    }
}

