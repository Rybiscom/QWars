using UnityEngine;

public sealed class PlayerInputHandler : MonoBehaviour, IInputHandler
{
    private const string AXIS_HORIZONTAL_NAME = "Horizontal";
    private const string AXIS_VERTICAL_NAME = "Vertical";

    private VariableJoystick _joystick;

    private IPressed _buttonSlowMotion;
    private IPressed _buttonBubbleGod;
    private IPressed _buttonBubbleDamage;

    private Vector2 _vectorAxis;

    private void Start()
    {
        _joystick = GameObject.FindWithTag(Tags.Joystick).GetComponent<VariableJoystick>();

        _buttonSlowMotion = GameObject.FindWithTag(Tags.ButtonSlowMotion).GetComponent<IPressed>();
        _buttonBubbleGod = GameObject.FindWithTag(Tags.ButtonBubbleGod)?.GetComponent<IPressed>();
        _buttonBubbleDamage = GameObject.FindWithTag(Tags.ButtonBubbleDamage)?.GetComponent<IPressed>();
    }

    public float GetAxisHorizontal()
    {
        return Input.GetAxisRaw(AXIS_HORIZONTAL_NAME);
    }

    public float GetAxisVertical()
    {
        return Input.GetAxisRaw(AXIS_VERTICAL_NAME);
    }

    public Vector2 GetAxis()
    {
        if (_joystick == null)
        {
            _vectorAxis.x = GetAxisHorizontal();
            _vectorAxis.y = GetAxisVertical();
        }
        else
        {
            _vectorAxis.x = _joystick.Horizontal;
            _vectorAxis.y = _joystick.Vertical;
        }
        return _vectorAxis;
    }

    public bool GetState(IInputHandler.Action action)
    {
        switch (action)
        {
            case IInputHandler.Action.SlowMotionKey:
                return (_buttonSlowMotion?.IsPressed() ?? false) || Input.GetKey(KeyCode.E);

            case IInputHandler.Action.BubbleGodKey:
                return _buttonBubbleGod?.IsPressed() ?? false;

            case IInputHandler.Action.BubbleDamageKey:
                return _buttonBubbleDamage?.IsPressed() ?? false;

            default:
                return false;
        }
    }
}
