using System;
using System.Collections;
using UnityEngine;

public sealed class BubbleDamage : Bubble, IBubble
{
    [SerializeField] private GameObject _targetPoint;

    private const float MAX_DISTANCE = 8f;
    private const float TIME_LOOP = 0.25f;
    private const float DAMAGE = 15f;

    private GameObject _target;

    protected override void Start()
    {
        base.Start();

        if (_targetPoint == null)
            throw new Exception("Добавь _targetPoint в BubbleDamage");

        LifeTime = 5f;

        StartCoroutine(MainLoop());
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public void Init(Rigidbody2D target, IOpenCopter copter)
    {
        InitBubble(target, copter);
    }

    private void SpawnTargetPoint()
    {
        if (_target == null)
            return;

        Instantiate(_targetPoint, _target.transform.position, Quaternion.identity);
    }

    private IEnumerator MainLoop()
    {
        while (true)
        {
            _target = FindTargetAndDealDamage();

            SpawnTargetPoint();

            yield return new WaitForSeconds(TIME_LOOP);
        }
    }

    private GameObject FindTargetAndDealDamage()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(Tags.Bot);

        for (int i = 0; i < targets.Length; i++)
        {
            if(targets[i].TryGetComponent(out Copter copter))
            {
                GameObject newTarget = copter.GetHeadGameObject();

                float distance = Vector3.Distance(gameObject.transform.position, newTarget.transform.position);

                if (distance <= MAX_DISTANCE)
                {
                    copter.ApplyDamage(DAMAGE);

                    return newTarget;
                }
            }
        }

        return _target;
    }
}
