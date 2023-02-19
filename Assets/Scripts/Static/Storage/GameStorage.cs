public static class GameStorage
{
    static GameStorage()
    {
        Init();
    }

    private const string STORAGE_FIRST_INIT_NAME = "first_init";

    public static MoneyStorage Money = new MoneyStorage();
    public static LevelStorage Level = new LevelStorage();
    public static BubblesStorage Bubbles = new BubblesStorage();
    public static SettingsStorage Settings = new SettingsStorage();
    public static PlayerCopterStorage PlayerCopter = new PlayerCopterStorage();

    public static void ClearAllDataAndInit(bool sure)
    {
        Storage.DeleteAll(sure);

        Init();
    }

    private static void Init()
    {
        if (Storage.HasKey(STORAGE_FIRST_INIT_NAME))
            return;
        Storage.Save(STORAGE_FIRST_INIT_NAME, 1);

        InitAll();
    }

    private static void InitAll()
    {
        Money.Init();
        Level.Init();
        Bubbles.Init();
        Settings.Init();
        PlayerCopter.Init();
    }
}
