using UnityEngine;

public interface IInputHandler
{
    public enum Action
    { 
        SlowMotionKey,
        BubbleGodKey,
        BubbleDamageKey
    }

    public float GetAxisHorizontal();

    public float GetAxisVertical();

    public Vector2 GetAxis();

    public bool GetState(Action action);
}
