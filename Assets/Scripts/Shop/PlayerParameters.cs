using System;

public class PlayerParameters
{
    public event Action moneyUpdated;
    public int CurrentMoney { get; private set; }

    public void AddMoney(int amount)
    {
        CurrentMoney += amount;
        moneyUpdated?.Invoke();
    }
}