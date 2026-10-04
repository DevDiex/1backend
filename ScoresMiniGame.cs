public class BankCard
{
    // Открытые свойства
        public string? CardNumber { get; private set; }
        public string? OwnerName { get; private set; }


        // Сверхзащищенные поля (инкапсуляция)
        // private перед переменными, чтобы не было видно из других методов и классов через точку

        private decimal _balance;
        private string? _pinCode;
        
        public BankCard(string cardnumber, string ownername, string pinCode, decimal startBalance) // Создание конструктора который в последствий работает с созданием объектов строго по шаблону
    {
        CardNumber = cardnumber;
        OwnerName = ownername;
        _pinCode = pinCode;

        if (startBalance < 0)
        {
            _balance = 0;
        }
        else
        {
            _balance = startBalance;
        }

    }

        public void CheckBalance(string? inputPin)
    {
        if (inputPin == _pinCode)
        {
            Console.WriteLine("[Банкомат]: Авторизация успешна");
            Console.WriteLine($"[Банкомат]: Ваш текущий баланс: {_balance} рублей");
        }
            else
            {
                Console.WriteLine("Ошибка авторизаций: Неверный пин-код");
            }

    }
        public void DepositMoney(decimal inputBalance)
    {
        if (inputBalance <= 0)
        {
            Console.WriteLine("Ошибка: Сумма пополнения должна быть больше нуля");
            return;
        }

        _balance += inputBalance;
        Console.WriteLine($"Счет успешно пополнен на {inputBalance} рублей");
        Console.WriteLine("Ваш текущий баланс обновлен");
    }

    public bool WithDrawMoney(string? inputPin, decimal inputBalance)
    {
        // Проверка пин-кода
        if (inputPin != _pinCode)
        {
            return false;
        }

        // Проверка хватает ли денег на карте (в отрицательную)
        if (inputBalance <= 0)
        {
            return false;
        }
        // Проверка хватает ли денег на карте (в положительную)
        if (inputBalance > _balance)
        {
            return false;
        }

        // Если все проверки прошли, меняем баланс
        _balance -= inputBalance;
        return true;
    }

    public bool isPinCorrect2(string? inputBalancePin)
    {
        if (inputBalancePin != _pinCode)
        {
            return false;
        }
        return true;
    }

        public bool IsPinCorrect(string? InputPin)
    {
        return InputPin == _pinCode; // if (inputPin != _pinCode)
    }

}

class Program
{
    static void Main(string[] args)
    {
        BankCard myCard = new BankCard("4276 1234 5678 9012", "Arthur", "1111", 500); // Создание конкретной карты на 500 рублей с ПИНОМ: 1111
        while (true)
        {
        Console.WriteLine("МЕНЮ БАНКОМАТА");            
        Console.WriteLine("1 - Проверить баланс карты ");            
        Console.WriteLine("2 - Пополнить баланс карты");
        Console.WriteLine("3 - Снять деньги с карты");             
        Console.WriteLine("4 - Выйти");           
        Console.WriteLine("Выберите действие");                   

        string? input = Console.ReadLine();

        switch (input)
            {
                case "1":
                    Console.WriteLine("Введите 4-ех значный код");
                    string? userPin = Console.ReadLine();

                    myCard.CheckBalance(userPin);
                    Console.ReadKey();
                break;

                case "2":
                    {
                       Console.WriteLine("-- Пополнение счета --");
                       Console.Write("Введите пин-код: ");
                       string? userPin2 = Console.ReadLine();

                       if (int.TryParse(userPin2, out int realPin) == false || string.IsNullOrWhiteSpace(userPin2))
                        {
                            Console.WriteLine("Ошибка: Неверный пин-код");
                            Console.ReadKey();
                            continue;
                        }
                        if (myCard.isPinCorrect2(userPin2) == false)
                        {
                            Console.WriteLine("Ошибка: Неверный пин-код");
                            Console.ReadKey();
                            continue;
                        }

                       Console.Write("Введите сумму пополнения: ");

                        string? inputerMoney = Console.ReadLine();

                       // Считывание строки и безопасный перевод
                       if (decimal.TryParse(inputerMoney, out decimal inputBalance) == false || string.IsNullOrWhiteSpace(inputerMoney))
                        {
                            Console.WriteLine("Ошибка: вы ввели неккоректную сумму");
                            Console.ReadKey();
                            continue; // Возврат в меню while
                        }
                        myCard.DepositMoney(inputBalance);
                        Console.ReadKey();
                    }

                    break;

                 case "3":
                    {
                        Console.WriteLine("-- Снятие денег --");
                        Console.Write("Введите пинки пай: ");

                        string? withDrawPin = Console.ReadLine();

                        if (int.TryParse(withDrawPin, out int pin) == false || string.IsNullOrWhiteSpace(withDrawPin))
                        {
                            Console.WriteLine("Ошибка: Неверный пин-код");
                            Console.ReadKey();
                            continue;
                        }
                        
                    if (myCard.IsPinCorrect(withDrawPin) == false)
                    {
                            Console.WriteLine("Ошибка: Неверный пинкод");
                            Console.ReadKey();
                            continue;
                    }
                        Console.Write("Введите сумму для снятия денег: ");

                        string? amount = Console.ReadLine();

                        if (decimal.TryParse(amount, out decimal money) == false || string.IsNullOrWhiteSpace(amount))
                        {
                            Console.WriteLine("Ошибка: Неверный формат");
                            Console.ReadKey();
                            continue;
                        }
                        
                      if (  myCard.WithDrawMoney(withDrawPin, money))
                        {
                            Console.WriteLine("Ваши деньги успешно списаны");
                        }
                        else
                        {
                            Console.WriteLine("Ошибка.");
                        }
                        Console.ReadKey();
                    }
                    break;

                case "4":
                    {
                        Console.WriteLine("Выходим...");
                        Console.WriteLine("Заберите карту! удачного дня");
                        return;
                    }
            }
        }
    }
}