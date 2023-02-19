using UnityEngine;

public static class Storage
{
    public static void Save(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
        SaveAllToMemory();
    }

    public static void Save(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
        SaveAllToMemory();
    }

    public static void Save(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
        SaveAllToMemory();
    }

    public static int GetInt(string key) => PlayerPrefs.GetInt(key, 0);

    public static float GetFloat(string key) => PlayerPrefs.GetFloat(key, 0);

    public static string GetString(string key) => PlayerPrefs.GetString(key, "");

    public static bool HasKey(string key) => PlayerPrefs.HasKey(key);

    public static void DeleteKey(string key) => PlayerPrefs.DeleteKey(key);

    public static void DeleteAll(bool sure)
    {
        if (sure)
            PlayerPrefs.DeleteAll();
    }

    private static void SaveAllToMemory()
    {
        PlayerPrefs.Save();
    }
}
