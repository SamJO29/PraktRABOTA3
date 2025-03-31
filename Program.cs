using System;

class Money
{
    private int first;
    private int second;

    public Money(int nominal, int count)
    {
        first = nominal;
        second = count;
    }

    public void Show()
    {
        Console.WriteLine($"Номинал: {first}, Количество: {second}");
    }

    public bool IsEnough(int amount)
    {
        return TotalAmount >= amount;
    }

    public int CalculateItems(int itemPrice)
    {
        return itemPrice > 0 ? TotalAmount / itemPrice : 0;
    }

    public int First
    {
        get { return first; }
        set { first = value; }
    }

    public int Second
    {
        get { return second; }
        set { second = value; }
    }

    public int TotalAmount
    {
        get { return first * second; }
    }

    public int this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return first;
                case 1: return second;
                default: throw new IndexOutOfRangeException("Индекс может быть только 0 или 1");
            }
        }
        set
        {
            switch (index)
            {
                case 0: first = value; break;
                case 1: second = value; break;
                default: throw new IndexOutOfRangeException("Индекс может быть только 0 или 1");
            }
        }
    }

    public static Money operator ++(Money m)
    {
        m.first++;
        m.second++;
        return m;
    }

    public static Money operator --(Money m)
    {
        m.first--;
        m.second--;
        return m;
    }

    public static bool operator !(Money m)
    {
        return m.second != 0;
    }

    public static Money operator +(Money m, int scalar)
    {
        m.second += scalar;
        return m;
    }
}

class Program
{
    static void Main()
    {
        Money money = new Money(100, 5);
        money.Show();

        Console.WriteLine($"Общая сумма: {money.TotalAmount}");
        Console.WriteLine($"Хватит на 600 рублей: {money.IsEnough(600)}");
        Console.WriteLine($"Можно купить товаров по 150 рублей: {money.CalculateItems(150)}");

        money++;
        Console.WriteLine("\nПосле ++:");
        money.Show();

        money += 10;
        Console.WriteLine("\nПосле += 10:");
        money.Show();

        Console.WriteLine($"\nПоле second не нулевое: {!money}");

        Console.WriteLine($"\nОбращение по индексу [0]: {money[0]}");
        Console.WriteLine($"Обращение по индексу [1]: {money[1]}");

        try
        {
            Console.WriteLine(money[2]);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}