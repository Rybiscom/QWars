using UnityEngine;

public sealed class BotBrain : CopterInfo
{
    private const string HEAD_NAME = "Head";

    private GameObject _targetPlayer;
    private GameObject _head;

    private Vector2 _direction;

    private void Awake()
    {
        _head = gameObject.transform.Find(HEAD_NAME).gameObject;

        RefindTarget();
    }

    public void RefindTarget()
    {
        _targetPlayer = GameObject.FindWithTag(Tags.PlayerHead)?.gameObject;
    }

    public Vector2 GetDirectionToTheTarget()
    {
        if (_head == null || _targetPlayer == null)
            return _direction;

        _direction = _targetPlayer.transform.position - _head.transform.position;
        _direction.Normalize();

        return _direction;
    }
}
