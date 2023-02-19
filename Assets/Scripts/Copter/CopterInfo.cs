using UnityEngine;

public abstract class CopterInfo : MonoBehaviour, ICopterInfo
{
    protected ConfigCopters CurrentCopterInfo;

    public virtual void InitCopterInfo(ConfigCopters currentCopterInfo)
    {
        CurrentCopterInfo = currentCopterInfo;
    }
}
