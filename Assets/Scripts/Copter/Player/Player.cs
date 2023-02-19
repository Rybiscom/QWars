using UnityEngine;

[RequireComponent(typeof(PlayerInputHandler))]

public sealed class Player : Copter
{
    private LayerMask _raycastLayerMask;

    protected override void Start()
    {
        base.Start();

        _raycastLayerMask = LayerMask.GetMask(Layers.Bot, Layers.Wall);

        InitInputHandler(GetComponent<PlayerInputHandler>());
        InitCopterInfo(CopterConfigurator.GetCopterConfig());

        //ActivateSavingSystem(_raycastLayerMask);
    }

    private void FixedUpdate()
    {
        if (!Death)
        {
            UpdateDeathState();
            UpdateHealthWarning();
            UpdateAccelerometer();
            UpdateMotorsActiveState();
            UpdateSavingSystem();
            MovementControl();
        }
        else
        {
            ImDeath();
        }
    }

    protected override void ImDeath()
    {
        if (DeathCheker)
            return;
        DeathCheker = true;

        Debug.Log("DED :(");
    }
}
