using UnityEngine;

public sealed class BubbleGod : Bubble, IBubble
{
    private const float MINIMUM_DAMAGE = -999f;
    private const float MAXIMUM_HEALTH = 999f;

    private CopterDamages _copterDamages;
    private CopterDamages _copterMinimumDamages;

    protected override void Start()
    {
        base.Start();

        _copterMinimumDamages = new CopterDamages(MINIMUM_DAMAGE);

        LifeTime = 7f;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        GodModeIterate();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        GodModeDeactivate();
    }

    public void Init(Rigidbody2D target, IOpenCopter copter)
    {
        InitBubble(target, copter);

        InitCopterDamages(Copter.GetCopterDamages());
    }

    private void InitCopterDamages(CopterDamages copterDamages)
    {
        _copterDamages = copterDamages;
    }

    private void GodModeIterate()
    {
        if (Copter == null)
            return;

        Copter.SetCopterDamage(_copterMinimumDamages);
        Copter.SetCopterHealth(MAXIMUM_HEALTH);
    }

    private void GodModeDeactivate()
    {
        if (Copter == null)
            return;

        Copter.SetCopterDamage(_copterDamages);
        Copter.SetCopterHealth(Copter.GetCurrentCopterInfo().Health);
    }
}
