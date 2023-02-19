public sealed class CopterDamages
{
    public CopterDamages(float damage)
    {
        LeftMotorDamage = damage;
        RightMotorDamage = damage;
        LeftLegDamage = damage;
        RightLegDamage = damage;
        HeadDamage = damage;
    }

    public CopterDamages(float leftMotorDamage, float rightMotorDamage, float leftLegDamage, float rightLegDamage, float headDamage)
    {
        LeftMotorDamage = leftMotorDamage;
        RightMotorDamage = rightMotorDamage;
        LeftLegDamage = leftLegDamage;
        RightLegDamage = rightLegDamage;
        HeadDamage = headDamage;
    }

    public readonly float LeftMotorDamage;
    public readonly float RightMotorDamage;
    public readonly float LeftLegDamage;
    public readonly float RightLegDamage;
    public readonly float HeadDamage;
}
