using System;

public sealed class SettingsStorage : IInitialize
{
    public enum Amount
    {
        Easy,
        Medium,
        Hard
    }

    private const string SETTING_FACTOR_POST_PROCESS_VOLUME_NAME = "setting_post_process_volume";

    private const float FACTOR_POST_PROCESS_VOLUME_EASY = 4f;
    private const float FACTOR_POST_PROCESS_VOLUME_MEDIUM = 2f;
    private const float FACTOR_POST_PROCESS_VOLUME_HARD = 1f;

    public void Init()
    {
        SetPostProcessVolume(Amount.Medium);
    }

    public void SetPostProcessVolume(Amount amount)
    {
        if (amount == Amount.Easy)
        {
            Storage.Save(SETTING_FACTOR_POST_PROCESS_VOLUME_NAME, FACTOR_POST_PROCESS_VOLUME_EASY);
            return;
        }

        if (amount == Amount.Medium)
        {
            Storage.Save(SETTING_FACTOR_POST_PROCESS_VOLUME_NAME, FACTOR_POST_PROCESS_VOLUME_MEDIUM);
            return;
        }

        if (amount == Amount.Hard)
        {
            Storage.Save(SETTING_FACTOR_POST_PROCESS_VOLUME_NAME, FACTOR_POST_PROCESS_VOLUME_HARD);
            return;
        }
    }

    public float GetPostProcessVolumeFactor()
    {
        return Storage.GetFloat(SETTING_FACTOR_POST_PROCESS_VOLUME_NAME);
    }

    public Amount GetCurrentAmount()
    {
        float amount = Storage.GetFloat(SETTING_FACTOR_POST_PROCESS_VOLUME_NAME);

        if (amount == FACTOR_POST_PROCESS_VOLUME_EASY)
            return Amount.Easy;

        if (amount == FACTOR_POST_PROCESS_VOLUME_MEDIUM)
            return Amount.Medium;

        if (amount == FACTOR_POST_PROCESS_VOLUME_HARD)
            return Amount.Hard;

        return Amount.Easy;
    }

    public Amount GetNextAmount(Amount amount)
    {
        var amounts = Enum.GetValues(typeof(Amount));
        int lenght = amounts.Length;

        for (var i = 0; i < amounts.Length; i++)
        {
            int nextIndex = i + 1;

            if (amount == (Amount)amounts.GetValue(i) && nextIndex < lenght)
                return (Amount)amounts.GetValue(nextIndex);
        }

        return (Amount)amounts.GetValue(0);
    }
}
