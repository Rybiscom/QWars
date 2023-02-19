using System;

public static class Maps
{
    static Maps()
    {
        ValidateMapNames();
    }

    public enum Names
    {
        Map1
    }

    public static string GetStringName(Names name)
    {
        switch (name)
        {
            case Names.Map1:
                return "Map1";
            default:
                throw new System.Exception($"Карта {name} не найдена, добавь ее в switch");
        }
    }

    private static void ValidateMapNames()
    {
        foreach (Names name in Enum.GetValues(typeof(Names)))
        {
            GetStringName(name);
        }
    }
}
