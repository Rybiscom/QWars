public struct SavingSystemSettings
{
    public SavingSystemSettings(float maxSpeedFactor, float speedForDangerousMode, float speedForMostDangerousMode, float healthWarningFactor)
    {
        _maxSpeedFactor = maxSpeedFactor;
        _speedForDangerousMode = speedForDangerousMode;
        _speedForMostDangerousMode = speedForMostDangerousMode;
        _healthWarningFactor = healthWarningFactor;
    }

    private float _maxSpeedFactor;
    private float _speedForDangerousMode;
    private float _speedForMostDangerousMode;
    private float _healthWarningFactor;

    public float MaxSpeedFactor => _maxSpeedFactor;

    public float SpeedForDangerousMode => _speedForDangerousMode;

    public float SpeedForMostDangerousMode => _speedForMostDangerousMode;

    public float HealthWarningFactor => _healthWarningFactor;
}
