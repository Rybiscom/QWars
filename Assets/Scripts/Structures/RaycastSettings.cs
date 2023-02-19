public struct RaycastSettings
{
    public RaycastSettings(float dangerousDistance, float maxDistance, int count)
    {
        _dangerousDistance = dangerousDistance;
        _maxDistance = maxDistance;
        _count = count;
    }

    private float _dangerousDistance;
    private float _maxDistance;
    private int _count;

    public float DangerousDistance
    {
        get => _dangerousDistance;
        set => _dangerousDistance = ValidateNotLowerThanZero(value);
    }

    public int Count
    {
        get => _count;
        set => _count = ValidateNotLowerThanZero(value);
    }

    public float MaxDistance
    {
        get => _maxDistance;
        set => _maxDistance = ValidateNotLowerThanZero(value);
    }

    private int ValidateNotLowerThanZero(int value)
    {
        return value <= 0 ? 0 : value;
    }

    private float ValidateNotLowerThanZero(float value)
    {
        return value <= 0 ? 0 : value;
    }
}
