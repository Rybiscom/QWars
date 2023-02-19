using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public sealed class GhostHead : MonoBehaviour
{
    [SerializeField] private GameObject _head;

    private const string CANVAS_NAME = "Canvas";
    private const string HEALTH_WARNING_TEXT = "Warning";

    private Rigidbody2D _ghostHeadRigidBody;
    private Rigidbody2D _headRigidBody;

    private GameObject _healthWarning;

    private void Start()
    {
        _ghostHeadRigidBody = GetComponent<Rigidbody2D>();
        _headRigidBody = _head.GetComponent<Rigidbody2D>();

        _healthWarning = gameObject.transform.Find(CANVAS_NAME).gameObject.transform.Find(HEALTH_WARNING_TEXT).gameObject;
    }

    private void FixedUpdate()
    {
        if (_headRigidBody != null)
            _ghostHeadRigidBody.position = _head.transform.position;
    }

    public void HealthWarning(bool active)
    {
        if (_healthWarning != null)
            _healthWarning.SetActive(active);
    }
}
