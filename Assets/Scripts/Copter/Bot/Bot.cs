using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(BotInputHandler))]
[RequireComponent(typeof(BotBrain))]

public sealed class Bot : Copter
{
    private LayerMask _raycastLayerMask;

    private BotBrain _botBrain;

    protected override void Start()
    {
        base.Start();

        _raycastLayerMask = LayerMask.GetMask(Layers.Player, Layers.Wall);

        _botBrain = GetComponent<BotBrain>();

        InitInputHandler(GetComponent<BotInputHandler>());

        InitCopterInfo(CopterConfigurator.GetCopterConfig());

        ActivateSavingSystem(_raycastLayerMask);
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

    protected override void InitCopterInfo(ConfigCopters copterInfo)
    {
        base.InitCopterInfo(copterInfo);

        _botBrain.InitCopterInfo(CurrentCopterInfo);
    }

    protected override async void ImDeath()
    {
        if (DeathCheker)
            return;
        DeathCheker = true;

        await Task.Delay(Config.DelayMsForDestroyBotDeadCopter);

        if (this != null && gameObject != null)
            Destroy(gameObject);
    }
}
