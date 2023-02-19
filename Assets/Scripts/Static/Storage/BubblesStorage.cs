public sealed class BubblesStorage : IInitialize
{
    public void Init()
    {
        Storage.Save(GetBubbleFormattedName(Bubbles.GetStringName(Bubbles.Names.BubbleDamage)), 0);
        Storage.Save(GetBubbleFormattedName(Bubbles.GetStringName(Bubbles.Names.BubbleGod)), 0);
    }

    public int GetCounts(Bubbles.Names name)
    {
        return Storage.GetInt(GetBubbleFormattedName(Bubbles.GetStringName(name)));
    }

    public void AddBubbleCounts(Bubbles.Names name, int counts)
    {
        int newCounts = GetCounts(name) + counts;

        Storage.Save(GetBubbleFormattedName(Bubbles.GetStringName(name)), newCounts);
    }

    public void SubtractBubbleCounts(Bubbles.Names name, int counts)
    {
        int newCounts = GetCounts(name) - counts;

        Storage.Save(GetBubbleFormattedName(Bubbles.GetStringName(name)), newCounts);
    }

    private string GetBubbleFormattedName(string name)
    {
        return $"{name}_counts";
    }
}
