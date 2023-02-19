using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public sealed class MotorController : CopterInfo
{
    private const float MIN_SLOW_DOWN_ANIMATOR_SPEED_SMOOTHNESS = 0.2f;
    private const float MAX_SLOW_DOWN_ANIMATOR_SPEED_SMOOTHNESS = 0.4f;
    private const float MAX_VINT_ANIMATOR_SPEED = 8f;
    private const float MOVE_DOWN_SPEED_FACTOR = 4f;

    private Rigidbody2D _motorRigidbody;
    private Animator _vintAnimator;

    private Vector2 _moveDirection;
    private float _baseSpeed;
    private float _speed;
    private float _attitudeBaseSpeedToSpeed;

    private bool _motorActive = true;
    private bool _slowDownTheAnimatorSpeedStartedChecker = false;

    private float _slowDownTheAnimatorSpeedSmoothness = MIN_SLOW_DOWN_ANIMATOR_SPEED_SMOOTHNESS;

    private void Start()
    {
        _motorRigidbody = GetComponent<Rigidbody2D>();

        _slowDownTheAnimatorSpeedSmoothness = Random.Range(MIN_SLOW_DOWN_ANIMATOR_SPEED_SMOOTHNESS, MAX_SLOW_DOWN_ANIMATOR_SPEED_SMOOTHNESS);
    }

    private void FixedUpdate()
    {
        Move();
        UpdateVintAnimationSpeed();
    }

    private void OnDestroy()
    {
        StopAnimator(_vintAnimator);
    }

    public override void InitCopterInfo(ConfigCopters currentCopterInfo)
    {
        base.InitCopterInfo(currentCopterInfo);

        _speed = CurrentCopterInfo.Speed;
        _baseSpeed = CurrentCopterInfo.BaseSpeed;

        _attitudeBaseSpeedToSpeed = _baseSpeed / _speed;
    }

    public void InitVintAnimator(Animator vintAnimator)
    {
        _vintAnimator = vintAnimator;
    }

    public void DisableMotor()
    {
        _motorActive = false;
    }

    public void SetMoveDirection(Vector2 moveDirection)
    {
        _moveDirection = moveDirection;
    }

    private void Move()
    {
        if (!_motorActive)
            return;

        Vector2 newForce;

        if (_moveDirection.x == 0 && _moveDirection.y == 0)
            newForce = Vector2.up * _baseSpeed;
        else if (_moveDirection.y < 0)
            newForce = _moveDirection * (_speed / MOVE_DOWN_SPEED_FACTOR);
        else
            newForce = _moveDirection * _speed;

        _motorRigidbody.AddForce(newForce, ForceMode2D.Impulse);
    }

    private void UpdateVintAnimationSpeed()
    {
        if (_vintAnimator == null)
            return;

        if (!_motorActive)
        {
            if (!_slowDownTheAnimatorSpeedStartedChecker)
            {
                _slowDownTheAnimatorSpeedStartedChecker = true;

                StartCoroutine(SlowDownTheAnimatorSpeed(_vintAnimator));
            }

            return;
        }

        float magnitude = _moveDirection.magnitude;

        if (magnitude >= 1)
        {
            _vintAnimator.speed = MAX_VINT_ANIMATOR_SPEED;
        }
        else
        {
            if (magnitude <= 0)
            {
                _vintAnimator.speed = MAX_VINT_ANIMATOR_SPEED * _attitudeBaseSpeedToSpeed;
            }
            else
            {
                float newVintSpeed = MAX_VINT_ANIMATOR_SPEED * magnitude;
                _vintAnimator.speed = newVintSpeed;
            }
        }
    }

    private void StopAnimator(Animator animator)
    {
        if (animator != null)
            animator.speed = 0;
    }

    private IEnumerator SlowDownTheAnimatorSpeed(Animator animator)
    {
        while (true)
        {
            animator.speed -= _slowDownTheAnimatorSpeedSmoothness;

            if (animator.speed > _slowDownTheAnimatorSpeedSmoothness)
            {
                yield return new WaitForSeconds(Time.fixedDeltaTime);
            }
            else
            {
                StopAnimator(animator);

                break;
            }
        }
    }
}
