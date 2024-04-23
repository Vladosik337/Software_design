using System;
using System.Collections.Generic;

// Базовий клас для підписок
public abstract class Subscription
{
    public decimal MonthlyFee { get; set; }
    public int MinimumPeriod { get; set; }
    public List<string> Channels { get; set; } = new List<string>();
    public List<string> Features { get; set; } = new List<string>();
}

// Клас підписки для домогосподарств
public class DomesticSubscription : Subscription
{
    public DomesticSubscription()
    {
        MonthlyFee = 15.99m;
        MinimumPeriod = 6;
        Channels.Add("Channel 1");
        Channels.Add("Channel 2");
        Features.Add("Standard Definition");
    }
}

// Клас освітньої підписки
public class EducationalSubscription : Subscription
{
    public EducationalSubscription()
    {
        MonthlyFee = 9.99m;
        MinimumPeriod = 3;
        Channels.Add("Educational Channel 1");
        Channels.Add("Educational Channel 2");
        Features.Add("Access to Study Materials");
    }
}

// Клас преміум підписки
public class PremiumSubscription : Subscription
{
    public PremiumSubscription()
    {
        MonthlyFee = 29.99m;
        MinimumPeriod = 12;
        Channels.Add("Premium Channel 1");
        Channels.Add("Premium Channel 2");
        Features.Add("High Definition");
        Features.Add("No Ads");
    }
}

// Інтерфейс для створення підписок
public interface ISubscriptionCreator
{
    Subscription CreateSubscription();
}

// Клас, що створює підписки через вебсайт
public class WebSiteSubscriptionCreator : ISubscriptionCreator
{
    public Subscription CreateSubscription()
    {
        return new DomesticSubscription();
    }
}

// Клас, що створює підписки через мобільний додаток
public class MobileAppSubscriptionCreator : ISubscriptionCreator
{
    public Subscription CreateSubscription()
    {
        return new PremiumSubscription();
    }
}

// Клас, що створює підписки через менеджера по телефону
public class ManagerCallSubscriptionCreator : ISubscriptionCreator
{
    public Subscription CreateSubscription()
    {
        return new EducationalSubscription();
    }
}

// Головний метод програми для перевірки коду
public class Program
{
    public static void Main()
    {
        List<ISubscriptionCreator> creators = new List<ISubscriptionCreator>
        {
            new WebSiteSubscriptionCreator(),
            new MobileAppSubscriptionCreator(),
            new ManagerCallSubscriptionCreator()
        };

        foreach (var creator in creators)
        {
            var subscription = creator.CreateSubscription();
            Console.WriteLine($"Created subscription with fee: {subscription.MonthlyFee}, " +
                              $"minimum period: {subscription.MinimumPeriod}, " +
                              $"channels: {string.Join(", ", subscription.Channels)}, " +
                              $"features: {string.Join(", ", subscription.Features)}");
        }
    }
}
