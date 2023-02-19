using System;
using UnityEngine;

public sealed class CopterSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] _copters;

    public GameObject Spawn(Config.CoptersInfo.Names name, bool player, Vector3 position)
    {
        GameObject copter = null;

        for(int i = 0; i < _copters.Length; i++)
        {
            if (_copters[i].GetComponent<CopterConfigurator>().GetCopterName() == name)
                copter = _copters[i];
        }

        if (copter == null)
            throw new Exception($"(CopterSpawn-Spawn) Не удалось найти и заспавнить коптер {name}, добавь префаб в Copters");

        return SpawnCopter(player, position, copter, name);
    }

    private GameObject SpawnCopter(bool player, Vector3 position, GameObject copter, Config.CoptersInfo.Names name)
    {
        GameObject newCopter = Instantiate(copter, position, Quaternion.identity);

        if (player)
            return MakePlayer(newCopter, name);
        else
            return MakeBot(newCopter, name);
    }

    private GameObject MakePlayer(GameObject copter, Config.CoptersInfo.Names name)
    {
        copter.GetComponent<CopterConfigurator>().MakePlayer(name);

        return copter;
    }

    private GameObject MakeBot(GameObject copter, Config.CoptersInfo.Names name)
    {
        copter.GetComponent<CopterConfigurator>().MakeBot(name);

        return copter;
    }
}
