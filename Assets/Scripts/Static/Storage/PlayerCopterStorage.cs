public sealed class PlayerCopterStorage : IInitialize
{
    private const string CURRENT_PLAYER_COPTER_NAME = "current_player_copter";

    public void Init()
    {
        string firstCopter = Config.CoptersInfo.GetStringName(Config.CoptersInfo.Names.MXP);

        string formatName = FormatCopterNameIsPurchased(Config.CoptersInfo.Copters[firstCopter].Name);

        Storage.Save(formatName, 1);

        SetCurrentPlayerCopter(Config.CoptersInfo.GetStringName(Config.CoptersInfo.Names.MXP));
    }

    public string GetCurrentPlayerCopter()
    {
        return Storage.GetString(CURRENT_PLAYER_COPTER_NAME);
    }

    public bool CheckCopterIsPurchased(string copterName)
    {
        bool isPurchased = Storage.HasKey(FormatCopterNameIsPurchased(copterName));

        if (isPurchased)
            return true;

        return false;
    }

    public void SetCurrentPlayerCopter(string name)
    {
        Storage.Save(CURRENT_PLAYER_COPTER_NAME, name);
    }

    public void SetCopterStatusPurchaseSuccess(string copterName)
    {
        Storage.Save(FormatCopterNameIsPurchased(copterName), 1);
    }

    private string FormatCopterNameIsPurchased(string copterName)
    {
        return $"{copterName}_purchased";
    }
}
