// Product — спільний інтерфейс
public interface IDocument
{
    void Open();
    void Close();
    void Save();
}

// ConcreteProduct A — конкретний продукт
public class TextDocument : IDocument
{
    public void Open()  => Console.WriteLine("Відкрито текстовий документ");
    public void Close() => Console.WriteLine("Закрито текстовий документ");
    public void Save()  => Console.WriteLine("Збережено текстовий документ");
}

// ConcreteProduct B — конкретний продукт
public class SpreadsheetDocument : IDocument
{
    public void Open()  => Console.WriteLine("Відкрито електронну таблицю");
    public void Close() => Console.WriteLine("Закрито електронну таблицю");
    public void Save()  => Console.WriteLine("Збережено електронну таблицю");
}

// Creator — абстрактний творець із фабричним методом
public abstract class Application
{
    public abstract IDocument CreateDocument(); // фабричний метод

    public void NewDocument()
    {
        IDocument doc = CreateDocument(); // виклик фабричного методу
        doc.Open();
        Console.WriteLine("Новий документ створено та відкрито.");
    }
}

// ConcreteCreator A — конкретний творець
public class TextEditor : Application
{
    public override IDocument CreateDocument() => new TextDocument();
}

// ConcreteCreator B — конкретний творець
public class SpreadsheetApp : Application
{
    public override IDocument CreateDocument() => new SpreadsheetDocument();
}

// Client — клієнтський код
class Program
{
    static void Main()
    {
        Application app1 = new TextEditor();
        app1.NewDocument();
        // Виведе: Відкрито текстовий документ
        //         Новий документ створено та відкрито.

        Application app2 = new SpreadsheetApp();
        app2.NewDocument();
        // Виведе: Відкрито електронну таблицю
        //         Новий документ створено та відкрито.
    }
}