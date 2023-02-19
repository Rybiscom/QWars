public sealed class LevelStorage : IInitialize
{
    private const string LEVEL_NAME = "level";

    public void Init()
    {
        Storage.Save(LEVEL_NAME, 0);
    }

    public int GetLevel() => Storage.GetInt(LEVEL_NAME);

    public void LevelUp() => Storage.Save(LEVEL_NAME, GetLevel() + 1);
}
