using System;

// Інтерфейс для девайсів
public interface IDevice
{
    void GetDeviceDetails();
}

// Конкретний клас для Laptop
public class Laptop : IDevice
{
    public string Brand { get; set; }

    public Laptop(string brand)
    {
        Brand = brand;
    }

    public void GetDeviceDetails()
    {
        Console.WriteLine($"Laptop of brand {Brand}");
    }
}

// Конкретний клас для Netbook
public class Netbook : IDevice
{
    public string Brand { get; set; }

    public Netbook(string brand)
    {
        Brand = brand;
    }

    public void GetDeviceDetails()
    {
        Console.WriteLine($"Netbook of brand {Brand}");
    }
}

// Конкретний клас для EBook
public class EBook : IDevice
{
    public string Brand { get; set; }

    public EBook(string brand)
    {
        Brand = brand;
    }

    public void GetDeviceDetails()
    {
        Console.WriteLine($"EBook of brand {Brand}");
    }
}

// Конкретний клас для Smartphone
public class Smartphone : IDevice
{
    public string Brand { get; set; }

    public Smartphone(string brand)
    {
        Brand = brand;
    }

    public void GetDeviceDetails()
    {
        Console.WriteLine($"Smartphone of brand {Brand}");
    }
}

// Інтерфейс для фабрик виробництва техніки
public interface IDeviceFactory
{
    IDevice CreateLaptop();
    IDevice CreateNetbook();
    IDevice CreateEBook();
    IDevice CreateSmartphone();
}

// Конкретна фабрика для бренду IProne
public class IProneFactory : IDeviceFactory
{
    public IDevice CreateLaptop()
    {
        return new Laptop("IProne");
    }

    public IDevice CreateNetbook()
    {
        return new Netbook("IProne");
    }

    public IDevice CreateEBook()
    {
        return new EBook("IProne");
    }

    public IDevice CreateSmartphone()
    {
        return new Smartphone("IProne");
    }
}

// Конкретна фабрика для бренду Kiaomi
public class KiaomiFactory : IDeviceFactory
{
    public IDevice CreateLaptop()
    {
        return new Laptop("Kiaomi");
    }

    public IDevice CreateNetbook()
    {
        return new Netbook("Kiaomi");
    }

    public IDevice CreateEBook()
    {
        return new EBook("Kiaomi");
    }

    public IDevice CreateSmartphone()
    {
        return new Smartphone("Kiaomi");
    }
}

// Конкретна фабрика для бренду Balaxy
public class BalaxyFactory : IDeviceFactory
{
    public IDevice CreateLaptop()
    {
        return new Laptop("Balaxy");
    }

    public IDevice CreateNetbook()
    {
        return new Netbook("Balaxy");
    }

    public IDevice CreateEBook()
    {
        return new EBook("Balaxy");
    }

    public IDevice CreateSmartphone()
    {
        return new Smartphone("Balaxy");
    }
}

// Головний метод програми для перевірки коду
public class Program
{
    public static void Main()
    {
        IDeviceFactory iProneFactory = new IProneFactory();
        IDeviceFactory kiaomiFactory = new KiaomiFactory();
        IDeviceFactory balaxyFactory = new BalaxyFactory();

        var laptop = iProneFactory.CreateLaptop();
        laptop.GetDeviceDetails();

        var smartphone = kiaomiFactory.CreateSmartphone();
        smartphone.GetDeviceDetails();

        var ebook = balaxyFactory.CreateEBook();
        ebook.GetDeviceDetails();
    }
}
