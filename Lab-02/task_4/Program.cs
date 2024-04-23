using System;
using System.Collections.Generic;

// Інтерфейс для клонування
public interface IPrototype<T>
{
    T Clone();
}

// Клас Virus
public class Virus : IPrototype<Virus>
{
    public string Name { get; set; }
    public double Weight { get; set; }
    public int Age { get; set; }
    public string Type { get; set; }
    public List<Virus> Children { get; set; } = new List<Virus>();

    public Virus(string name, double weight, int age, string type)
    {
        Name = name;
        Weight = weight;
        Age = age;
        Type = type;
    }

    // Метод глибокого клонування
    public Virus Clone()
    {
        var clone = new Virus(Name, Weight, Age, Type);

        // Клонування дітей
        foreach (var child in Children)
        {
            clone.Children.Add(child.Clone());
        }

        return clone;
    }

    // Метод для виводу інформації про вірус та його дітей
    public void DisplayInfo(int level = 0)
    {
        string indent = new string(' ', level * 4);
        Console.WriteLine($"{indent}Virus: {Name}, Weight: {Weight}, Age: {Age}, Type: {Type}");

        foreach (var child in Children)
        {
            child.DisplayInfo(level + 1);
        }
    }
}

// Головний метод програми для перевірки коду
public class Program
{
    public static void Main()
    {
        // Створення сімейства вірусів
        Virus parent = new Virus("ParentVirus", 1.5, 5, "TypeA");

        Virus child1 = new Virus("ChildVirus1", 0.5, 2, "TypeB");
        Virus child2 = new Virus("ChildVirus2", 0.3, 1, "TypeC");

        parent.Children.Add(child1);
        child1.Children.Add(child2);

        Console.WriteLine("Original virus family:");
        parent.DisplayInfo();

        // Клонування вірусу-батька
        Virus clonedParent = parent.Clone();

        Console.WriteLine("\nCloned virus family:");
        clonedParent.DisplayInfo();
    }
}
