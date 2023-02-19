using UnityEngine;

[RequireComponent(typeof(BotBrain))]

public sealed class BotInputHandler : MonoBehaviour, IInputHandler
{
    private BotBrain _botBrain;

    private Vector2 _vectorAxis;

    private void Start()
    {
        _botBrain = GetComponent<BotBrain>();
    }

    public float GetAxisHorizontal()
    {
        return GetAxis().x;
    }

    public float GetAxisVertical()
    {
        return GetAxis().y;
    }

    public Vector2 GetAxis()
    {
        if (_botBrain != null)
            _vectorAxis = _botBrain.GetDirectionToTheTarget();

        return _vectorAxis;
    }

    public bool GetState(IInputHandler.Action action)
    {
        switch (action)
        {
            default:
                return false;
        }
    }
}
