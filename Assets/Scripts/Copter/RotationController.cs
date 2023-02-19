using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public sealed class RotationController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void FreezeRotation(bool freeze)
    {
        _rigidbody.freezeRotation = freeze;
    }

    public void UpdateAccelerometer(Vector2 vectorAxis)
    {
        if (_rigidbody == null)
            return;

        if (vectorAxis.x != 0)
        {
            if (vectorAxis.x > 0)
                _rigidbody.MoveRotation(-15 * vectorAxis.x);

            if (vectorAxis.x < 0)
                _rigidbody.MoveRotation(15 * -vectorAxis.x);
        }
        else
        {
            _rigidbody.MoveRotation(0);
        }
    }
}
