using UnityEngine.Events;

public sealed class MenuEvents
{
    public static UnityEvent OnMoneyChanged = new UnityEvent();
    public static UnityEvent OnLevelChanged = new UnityEvent();

    public static void MoneyChanged()
    {
        OnMoneyChanged.Invoke();
    }

    public static void LevelChanged()
    {
        OnLevelChanged.Invoke();
    }
}
