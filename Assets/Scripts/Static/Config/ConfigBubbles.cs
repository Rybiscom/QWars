public sealed class ConfigBubbles
{
    public ConfigBubbles(int bubbleGodPrice, int bubbleDamagePrice)
    {
        BubbleGodPrice = bubbleGodPrice;
        BubbleDamagePrice = bubbleDamagePrice;
    }

    public readonly int BubbleGodPrice = 0;
    public readonly int BubbleDamagePrice = 0;

    public int GetPrice(Bubbles.Names name)
    {
        if (name == Bubbles.Names.BubbleGod)
            return BubbleGodPrice;

        if (name == Bubbles.Names.BubbleDamage)
            return BubbleDamagePrice;

        return 0;
    }
}
