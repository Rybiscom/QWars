using UnityEngine;

public class CopterSavingSystem : ICopterInfo, ICopterSystem
{
    protected ConfigCopters CurrentCopterInfo;

    private LayerMask _layerMask;

    private bool _debbug = Config.DebbugMode;

    private bool _healthWarning;

    public bool Active { get; private set; }

    public void InitCopterInfo(ConfigCopters currentCopterInfo)
    {
        CurrentCopterInfo = currentCopterInfo;
    }

    public void InitLayerMask(LayerMask layerMask)
    {
        _layerMask = layerMask;
    }

    public void SetActive(bool active)
    {
        Active = active;
    }

    public void HealthWarning(bool warning)
    {
        _healthWarning = warning;
    }

    public void Iterate(Rigidbody2D target)
    {
        if (!Active)
            return;

        RaycastData[] raycastDatas;

        CreateRaycasts(target.position, out raycastDatas);

        UpdateDangerousRaycastsDate(target.position, raycastDatas);

        MoveTargetToSafeArea(target, raycastDatas);
    }

    private void CreateRaycasts(Vector3 target, out RaycastData[] raycastDatas)
    {
        raycastDatas = new RaycastData[CurrentCopterInfo.RaycastSettings.Count];

        float maxAngle = 360;
        float angleRounding = 10000;

        float iterateAngle = maxAngle / CurrentCopterInfo.RaycastSettings.Count;

        for (int i = 0; i < CurrentCopterInfo.RaycastSettings.Count; i++)
        {
            float angle = i * iterateAngle;

            float sin = Mathf.Round(Mathf.Sin(Mathf.Deg2Rad * angle) * angleRounding) / angleRounding;
            float cos = Mathf.Round(Mathf.Cos(Mathf.Deg2Rad * angle) * angleRounding) / angleRounding;

            Vector2 direction = new Vector2(sin, cos);

            RaycastHit2D hit = Physics2D.Raycast(target, direction, CurrentCopterInfo.RaycastSettings.MaxDistance, _layerMask);

            float distance = Vector2.Distance(target, hit.point);
            
            raycastDatas[i] = new RaycastData(distance, angle, direction, hit);
        }
    }

    private void UpdateDangerousRaycastsDate(Vector3 target, RaycastData[] raycastDatas)
    {
        int MostDangerousRaycastId = -1;

        float MostDangerousRaycastDistance = CurrentCopterInfo.RaycastSettings.DangerousDistance;

        for (int i = 0; i < raycastDatas.Length; i++)
        {
            float distance = raycastDatas[i].Distance;
            RaycastHit2D hit = raycastDatas[i].Hit;

            if (hit.collider != null)
            {
                if (distance <= CurrentCopterInfo.RaycastSettings.DangerousDistance)
                {
                    raycastDatas[i].IsDangerous = true;

                    if (distance < MostDangerousRaycastDistance)
                    {
                        MostDangerousRaycastDistance = distance;
                        MostDangerousRaycastId = i;
                    }

                    if (_debbug)
                        Debug.DrawLine(target, hit.point, Color.red);
                }
                else
                {
                    if (_debbug)
                        Debug.DrawLine(target, hit.point, Color.green);
                }

                if (MostDangerousRaycastId >= 0)
                    raycastDatas[MostDangerousRaycastId].IsMostDangerous = true;
            }
        }
    }

    private void MoveTargetToSafeArea(Rigidbody2D target, RaycastData[] raycastDatas)
    {
        for (int i = 0; i < raycastDatas.Length; i++)
        {
            if (!raycastDatas[i].IsMostDangerous || !raycastDatas[i].IsDangerous)
                continue;

            MoveTargetOnRaycast(target, raycastDatas[i]);
        }
    }

    private void MoveTargetOnRaycast(Rigidbody2D target, RaycastData raycastData)
    {
        float factorDistance = CurrentCopterInfo.RaycastSettings.MaxDistance / raycastData.Distance;
        float factorSpeed = 1;

        //if (target.velocity.magnitude > CurrentCopterInfo.MaxSpeed)
        //    factorSpeed = target.velocity.magnitude / CurrentCopterInfo.MaxSpeed;

        float finalFactor = factorDistance * factorSpeed;

        if (finalFactor > CurrentCopterInfo.SavingSystemSettings.MaxSpeedFactor)
            finalFactor = CurrentCopterInfo.SavingSystemSettings.MaxSpeedFactor;

        if (_healthWarning)
            finalFactor = finalFactor / CurrentCopterInfo.SavingSystemSettings.HealthWarningFactor;

        Vector2 finalDirectionSpeed = raycastData.ReverseDirection();

        if (raycastData.IsMostDangerous)
            finalDirectionSpeed *= CurrentCopterInfo.SavingSystemSettings.SpeedForMostDangerousMode * finalFactor;

        if (raycastData.IsDangerous)
            finalDirectionSpeed *= CurrentCopterInfo.SavingSystemSettings.SpeedForDangerousMode * finalFactor;

        target.AddForce(finalDirectionSpeed, ForceMode2D.Impulse);
    }
}
