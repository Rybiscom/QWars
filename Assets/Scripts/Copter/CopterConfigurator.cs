using System;
using UnityEngine;

[RequireComponent(typeof(QCopterController))]

public sealed class CopterConfigurator : MonoBehaviour
{
    [SerializeField] private Config.CoptersInfo.Names _copterName;

    private const string HEAD_NAME = "Head";

    private bool _player;

    public Config.CoptersInfo.Names GetCopterName() => _copterName;

    public ConfigCopters GetCopterConfig()
    {
        string copterName = Config.CoptersInfo.GetStringName(GetCopterName());

        return Config.CoptersInfo.Copters[copterName];
    }

    public void MakePlayer(Config.CoptersInfo.Names name)
    {
        _player = true;

        InitCopter(name, _player);
    }

    public void MakeBot(Config.CoptersInfo.Names name)
    {
        _player = false;

        InitCopter(name, _player);
    }

    private void InitCopter(Config.CoptersInfo.Names name, bool player)
    {
        if (name != _copterName)
            throw new Exception("(InitCopter) ќжидаемое им€ коптера из конфига не совпало с именем коптера в префабе, убедись что в префабе стоит правильное им€");

        if (player)
            InitPlayer();
        else
            InitBot();
    }

    private void InitPlayer()
    {
        gameObject.tag = Tags.Player;
        gameObject.transform.Find(HEAD_NAME).gameObject.tag = Tags.PlayerHead;

        SetGameLayerRecursive(gameObject, LayerMask.NameToLayer(Layers.Player));

        gameObject.AddComponent<PlayerInputHandler>();
        gameObject.AddComponent<Player>();
    }

    private void InitBot()
    {
        gameObject.tag = Tags.Bot;

        SetGameLayerRecursive(gameObject, LayerMask.NameToLayer(Layers.Bot));

        gameObject.AddComponent<BotInputHandler>();
        gameObject.AddComponent<BotBrain>();
        gameObject.AddComponent<Bot>();
    }

    private void SetGameLayerRecursive(GameObject copter, int layer)
    {
        copter.layer = layer;

        foreach (Transform child in copter.transform)
        {
            child.gameObject.layer = layer;

            Transform hasChildren = child.GetComponentInChildren<Transform>(includeInactive: true);

            if (hasChildren != null)
                SetGameLayerRecursive(child.gameObject, layer);
        }
    }
}
