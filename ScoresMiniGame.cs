
public class Book
{
    public string? bookName { get; private set;}
    public string? authorsName { get; private set;}
    public int pagesAmount { get; private set;}
    public bool IsBorrowed { get; set;}




    public Book(string? bookname, string? authorsname, int pagesamount)
    {
        bookName = bookname;
        authorsName = authorsname;
        pagesAmount = pagesamount;

        IsBorrowed = false;
    }


    public void PrintedBooks()
    {
        string borrowStatus;
        if (IsBorrowed == true)
        {
            borrowStatus = "на руках";
        }
        else
        {
            borrowStatus = "в хранилище";
        }

        Console.WriteLine($"Книга {bookName} с Авторством  - {authorsName} и кол-вом страниц равному {pagesAmount} была добавлена в вашу библиотеку - статус = {borrowStatus}");
    }
}

public class LibraryManager
{
    public List<Book> Library { get; private set;} = new List<Book>(); // список книг

    public LibraryManager() // Создание конструктора и последующий вызов через new
    {
        
        Library.Add(new Book("Мастер и Маргарита", "М. Булгаков", 448));
        Library.Add(new Book("Капитанская дочка", "А. Пушкин", 160));

    }

    public void ShowAllBooks()
    {
        
        Console.WriteLine("-- Библиотека -- ");

        if (Library.Count == 0)
        {
            Console.WriteLine("Наша библиотека пуста");
            return;
        }

        for (int i = 0; i < Library.Count; i++)
        {
            Library[i].PrintedBooks();
        }

    }

    public bool IsBookExists(string? title)
    {
        for (int i = 0; i < Library.Count; i++)
        {
            if (Library[i].bookName == title)
            {
                Console.WriteLine("Такая книга уже существует");
                return true;
                
            }
        }
        return false;
    }

    public bool AddBookToLibrary(Book newBook)
    {
        if (Library.Count >= 5)
        {
            Console.WriteLine("Ошибка: Библиотека переполнена");
            return false;
        }
        Library.Add(newBook);
        Console.WriteLine($"Книга {newBook} успешно добавлена");
        return true;
    }


    public void BorrowBook(string? title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("[ОШИБКА!]: Название книги не может быть пустым");
            return;
        }
        bool isFound = false;

        for (int i = 0; i < Library.Count; i++)
        {
            if (Library[i].bookName == title)
            {
                if (Library[i].IsBorrowed == true) // Вдруг книгу кто то забрал до нас - проверка
                {
                    Console.WriteLine($"Ошибка - книга {Library[i].bookName} уже выдана другому читателю");
                    isFound = true;
                    return;
                }

                Library[i].IsBorrowed = true;
                isFound = true;

                Console.WriteLine($"Книга {Library[i].bookName} успешно выдана");
                break; // Останавливаем цикл после того как нашли и переключили флаг


            }
        }
        if (!isFound)
        {
            Console.WriteLine($"Ошибка: Книга с названием {title} не найдена");
        }
    }
}

class Program
{
    
    static void Main(string[] args)
    {
        LibraryManager manager = new LibraryManager();
        while (true)
        {
            Console.WriteLine("1 - Показать все книги");
            Console.WriteLine("2 - Добавить книгу");
            Console.WriteLine("3 - Выдать книгу читателю");
            Console.WriteLine("4 - Выйти...");

            string? Command = Console.ReadLine();
            

            switch (Command)
            {
                case "1":
                manager.ShowAllBooks();
                Console.ReadKey();
                break;

                case "2":
                Console.WriteLine("Введите название книги");
                string? newBook = Console.ReadLine();

                if (int.TryParse(newBook, out int num) == true || string.IsNullOrWhiteSpace(newBook))
                    {
                        Console.WriteLine("Ошибка: Неверное значение или формат");
                        Console.ReadKey();
                        continue;
                    }

                    if (manager.IsBookExists(newBook))
                    {
                        Console.WriteLine("Ошибка; Книга уже есть");
                        Console.ReadKey();
                        continue;
                    }

                    Console.WriteLine("Введите Автора книги");
                    string? newAuthor = Console.ReadLine();

                    if (int.TryParse(newAuthor, out int num2) == true || string.IsNullOrWhiteSpace(newAuthor))
                    {
                        Console.WriteLine("Ошибка: Неверное имя Автора");
                        Console.ReadKey();
                        continue;
                    }

                    Console.WriteLine("Введите кол-во страниц в книге");
                    string? newBookLines = Console.ReadLine();

                    if (int.TryParse(newBookLines, out int num3) == false || string.IsNullOrWhiteSpace(newBookLines) || num3 <= 0)
                    {
                        Console.WriteLine("Ошибка: Неверный формат ввода");
                        Console.ReadKey();
                        continue;
                    }

                    Book ourBook = new Book(newBook, newAuthor, num3);

                    manager.AddBookToLibrary(ourBook);
                    Console.ReadKey();
                    break;



                        case "3":
                        Console.WriteLine("Введите книгу которую желаете взять");

                        string? TakenBook = Console.ReadLine();
                        manager.BorrowBook(TakenBook);
                        Console.ReadKey();
                        break;



                case "4":
                Console.WriteLine("Все будет хорошо...");
                return;

            }
        }
    }
}