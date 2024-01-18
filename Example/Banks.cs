using System;
namespace Example;

public interface IBaseBank
{
    public int Money { get; }
    public void AddMoney(int money);
    public void SpendMoney(int money);

}
public interface ITosunBank:IBaseBank
{
    public int ChickenCount { get; }
    public void BuyChicken();
}
public abstract class BaseBank : IBaseBank
{
    public int Money { get; protected set; } = 0;

    public void AddMoney(int money)
    {
        Money += money;
        AddMoneyLog(money);
    }
    public void SpendMoney(int money)
    {
        Money -= money;
    }
    public virtual void AddMoneyLog(int money)
    {
    }

}
public class ZiraatBank:BaseBank,IBaseBank
{
    public override void AddMoneyLog(int money)
    {
        Console.WriteLine("Para eklendi "+money);
    }
}
public class TosunBank:BaseBank, ITosunBank
{

    public int ChickenCount  { get; private set; } = 0;
    public void BuyChicken()
    {
        Money -= 10;
        ChickenCount++;
    }
}
public class FinansBank : IBaseBank
{
    public int Money { get; private set; } = 0;

    public void AddMoney(int money)
    {

    }

    public void SpendMoney(int money)
    {
    }
}