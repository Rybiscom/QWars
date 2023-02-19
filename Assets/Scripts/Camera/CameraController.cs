using UnityEngine;

[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(CameraMotionBlur))]
[RequireComponent(typeof(CameraPostProcessing))]

public sealed class CameraController : CopterInfo
{
    [SerializeField] private GameObject _target;

    private const float TARGET_VELOCITY_MAGNITUDE_TRIGGER = 5f;
    private const float TARGET_VELOCITY_MAGNITUDE_FACTOR = 6f;
    private const float ORTHOGRAPHIC_SIZE_OFFSET = 0.1f;
    private const float MAX_DISTANCE_TO_TARGET = 3f;
    private const float MIN_ORTHOGRAPHIC_SIZE = 1f;
    private const float MAX_ORTHOGRAPHIC_SIZE = 100f;
    private const float CAMERA_MOVE_DAMPING = 3f;

    private readonly Vector2 CAMERA_OFFSET = new Vector2(2f, 1f);

    private Rigidbody2D _targetRigidBody;
    private Transform _targetTransform;
    private Camera _camera;

    private float _distanceToTarget;
    private bool _cameraFaceRight;
    private int _lastTargetPositionX;

    private CameraPostProcessing _cameraPostProcessing;
    private CameraMotionBlur _cameraMotionBlur;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        _cameraMotionBlur = GetComponent<CameraMotionBlur>();
        _cameraPostProcessing = GetComponent<CameraPostProcessing>();
    }

    private void FixedUpdate()
    {
        UpdateCamera();
    }

    public void SetTarget(GameObject target)
    {
        _target = target;

        _targetRigidBody = _target.GetComponent<Rigidbody2D>();
        _targetTransform = _target.GetComponent<Transform>();
    }

    public void UpdateOrthographicSize(float orthographicSize)
    {
        if (orthographicSize < MIN_ORTHOGRAPHIC_SIZE || orthographicSize > MAX_ORTHOGRAPHIC_SIZE)
            return;

        _camera.orthographicSize = orthographicSize;
    }

    public void UpdateOrthographicSizeByTargetSpeed()
    {
        if (_target == null)
            return;

        float orthographicSize = CurrentCopterInfo.OrthographicSize;
        float maxOrthographicSize = CurrentCopterInfo.MaxOrthographicSize;

        if (_targetRigidBody.velocity.magnitude > TARGET_VELOCITY_MAGNITUDE_TRIGGER)
        {
            float newOrthographicSize = orthographicSize + (_targetRigidBody.velocity.magnitude / TARGET_VELOCITY_MAGNITUDE_FACTOR);

            if (_camera.orthographicSize < newOrthographicSize)
                _camera.orthographicSize += ORTHOGRAPHIC_SIZE_OFFSET;
        }
        else
        {
            if (_camera.orthographicSize > orthographicSize)
                _camera.orthographicSize -= ORTHOGRAPHIC_SIZE_OFFSET;
        }

        if (_camera.orthographicSize > maxOrthographicSize)
            _camera.orthographicSize = maxOrthographicSize;
    }

    public void SlowMotion(bool active, float postProcessinWeight)
    {
        _cameraMotionBlur.SlowMotion(active);

        _cameraPostProcessing.SetWeight(postProcessinWeight);
    }

    private void UpdateCamera()
    {
        if (_target == null)
            return;

        int currentX = Mathf.RoundToInt(_targetTransform.position.x);

        if (currentX > _lastTargetPositionX)
            _cameraFaceRight = true; 
        else if (currentX < _lastTargetPositionX)
            _cameraFaceRight = false;

        _lastTargetPositionX = currentX;

        float newTargetPositionX;

        if (_cameraFaceRight)
            newTargetPositionX = _targetTransform.position.x - CAMERA_OFFSET.x;
        else
            newTargetPositionX = _targetTransform.position.x + CAMERA_OFFSET.x;

        Vector3 newTargetPosition = new Vector3(newTargetPositionX, _targetTransform.position.y + CAMERA_OFFSET.y, transform.position.z);
        
        _distanceToTarget = Vector3.Distance(transform.position, newTargetPosition);
        
        float newCameraMoveDamping = CAMERA_MOVE_DAMPING;

        if (_distanceToTarget >= MAX_DISTANCE_TO_TARGET)
        {
            float accelerationFactor = _distanceToTarget / MAX_DISTANCE_TO_TARGET;

            newCameraMoveDamping = CAMERA_MOVE_DAMPING * accelerationFactor;
        }

        transform.position = Vector3.Lerp(transform.position, newTargetPosition, newCameraMoveDamping * Time.fixedDeltaTime);
    }
}
