using UnityEngine;

public sealed class AttentionPointer : MonoBehaviour, IActivable
{
    private Transform _targetFrom;
    private Transform _targetTo;

    private void FixedUpdate()
    {
        UpdateTarget();
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        Destroy(gameObject);
    }

    public void SetTarget(Transform targetFrom, Transform targetTo)
    {
        _targetFrom = targetFrom;
        _targetTo = targetTo;
    }

    private void UpdateTarget()
    {
        if (_targetFrom == null || _targetTo == null)
            return;

        Vector2 target = _targetTo.position - _targetFrom.position;

        target.Normalize();

        float angle = -Vector2.SignedAngle(target, Vector2.up);

        gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
