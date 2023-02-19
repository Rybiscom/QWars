public static class Bubbles
{
    public enum Names
    {
        BubbleGod,
        BubbleDamage
    }

    public static readonly string BubbleGod = "BubbleGod";
    public static readonly string BubbleDamage = "BubbleDamage";

    public static string GetStringName(Names name)
    {
        switch (name)
        {
            case Names.BubbleGod:
                return BubbleGod;

            case Names.BubbleDamage:
                return BubbleDamage;

            default:
                throw new System.Exception($"(Bubbles-GetStringName) ѕузырь {name} не найден, добавь его в switch");
        }
    }
}
