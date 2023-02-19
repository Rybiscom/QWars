public struct BubblesStates
{
    public bool God { get; set; }

    public bool Damage { get; set; }

    public bool IsOneActive()
    {
        if (God || Damage)
            return true;

        return false;
    }
}
