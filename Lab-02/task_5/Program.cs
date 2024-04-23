using System;
using System.Collections.Generic;

// Інтерфейс для будівельників
public interface ICharacterBuilder
{
    ICharacterBuilder SetHeight(double height);
    ICharacterBuilder SetBuild(string build);
    ICharacterBuilder SetHairColor(string color);
    ICharacterBuilder SetEyeColor(string color);
    ICharacterBuilder SetOutfit(string outfit);
    ICharacterBuilder AddInventoryItem(string item);
    Character Build();
}

// Клас Character, що представляє персонажа
public class Character
{
    public double Height { get; set; }
    public string Build { get; set; }
    public string HairColor { get; set; }
    public string EyeColor { get; set; }
    public string Outfit { get; set; }
    public List<string> Inventory { get; set; } = new List<string>();

    public override string ToString()
    {
        return $"Character [Height={Height}, Build={Build}, HairColor={HairColor}, EyeColor={EyeColor}, Outfit={Outfit}, Inventory={string.Join(", ", Inventory)}]";
    }
}

// Будівельник для героїв
public class HeroBuilder : ICharacterBuilder
{
    private Character _character = new Character();

    public ICharacterBuilder SetHeight(double height)
    {
        _character.Height = height;
        return this;
    }

    public ICharacterBuilder SetBuild(string build)
    {
        _character.Build = build;
        return this;
    }

    public ICharacterBuilder SetHairColor(string color)
    {
        _character.HairColor = color;
        return this;
    }

    public ICharacterBuilder SetEyeColor(string color)
    {
        _character.EyeColor = color;
        return this;
    }

    public ICharacterBuilder SetOutfit(string outfit)
    {
        _character.Outfit = outfit;
        return this;
    }

    public ICharacterBuilder AddInventoryItem(string item)
    {
        _character.Inventory.Add(item);
        return this;
    }

    public Character Build()
    {
        Character result = _character;
        _character = new Character(); // Готуємо новий об'єкт для наступного будівництва
        return result;
    }
}

// Будівельник для ворогів
public class EnemyBuilder : ICharacterBuilder
{
    private Character _character = new Character();

    public ICharacterBuilder SetHeight(double height)
    {
        _character.Height = height;
        return this;
    }

    public ICharacterBuilder SetBuild(string build)
    {
        _character.Build = build;
        return this;
    }

    public ICharacterBuilder SetHairColor(string color)
    {
        _character.HairColor = color;
        return this;
    }

    public ICharacterBuilder SetEyeColor(string color)
    {
        _character.EyeColor = color;
        return this;
    }

    public ICharacterBuilder SetOutfit(string outfit)
    {
        _character.Outfit = outfit;
        return this;
    }

    public ICharacterBuilder AddInventoryItem(string item)
    {
        _character.Inventory.Add(item);
        return this;
    }

    public Character Build()
    {
        Character result = _character;
        _character = new Character(); // Готуємо новий об'єкт для наступного будівництва
        return result;
    }
}

// Клас-директор
public class Director
{
    private ICharacterBuilder _builder;

    public Director(ICharacterBuilder builder)
    {
        _builder = builder;
    }

    public Character BuildDefaultCharacter()
    {
        return _builder.SetHeight(1.8)
            .SetBuild("Athletic")
            .SetHairColor("Brown")
            .SetEyeColor("Blue")
            .SetOutfit("Armor")
            .AddInventoryItem("Sword")
            .AddInventoryItem("Shield")
            .Build();
    }
}

public class Program
{
    public static void Main()
    {
        // Створення героя
        var heroBuilder = new HeroBuilder();
        var heroDirector = new Director(heroBuilder);
        var hero = heroDirector.BuildDefaultCharacter();
        Console.WriteLine("Hero: " + hero);

        // Створення ворога
        var enemyBuilder = new EnemyBuilder();
        var enemyDirector = new Director(enemyBuilder);
        var enemy = enemyDirector.BuildDefaultCharacter();
        Console.WriteLine("Enemy: " + enemy);
    }
}
