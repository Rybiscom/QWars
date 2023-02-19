using UnityEngine;

public sealed class RaycastData
{
    public RaycastData(float distance, float angle, Vector2 direction, RaycastHit2D hit)
    {
        Distance = distance;
        Angle = angle;
        Direction = direction;
        Hit = hit;
    }

    public bool IsDangerous { get; set; }

    public bool IsMostDangerous { get; set; }

    public float Distance { get; private set; }

    public float Angle { get; private set; }

    public Vector2 Direction { get; private set; }

    public RaycastHit2D Hit { get; private set; }

    public Vector2 ReverseDirection()
    {
        return new Vector2(-Direction.x, -Direction.y);
    }
}
