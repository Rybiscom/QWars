public sealed class MoneyStorage : IInitialize
{
    private const string COINS_NAME = "coins";
    private const string RUBINS_NAME = "rubins";

    public void Init()
    {
        Storage.Save(COINS_NAME, 0);
        Storage.Save(RUBINS_NAME, 0);
    }

    public int GetCoins() => Storage.GetInt(COINS_NAME);

    public int GetRubins() => Storage.GetInt(RUBINS_NAME);

    public void AddCoins(int coins) => Storage.Save(COINS_NAME, GetCoins() + coins);

    public void AddRubins(int rubins) => Storage.Save(RUBINS_NAME, GetRubins() + rubins);

    public bool SubtractCoins(int coins)
    {
        if (coins <= GetCoins())
        {
            Storage.Save(COINS_NAME, GetCoins() - coins);

            return true;
        }

        return false;
    }

    public bool SubtractRubins(int rubins)
    {
        if (rubins <= GetRubins())
        {
            Storage.Save(RUBINS_NAME, GetRubins() - rubins);

            return true;
        }

        return false;
    }
}
