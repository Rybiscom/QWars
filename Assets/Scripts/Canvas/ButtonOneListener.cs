using UnityEngine;

public sealed class ButtonOneListener : MonoBehaviour, IPressed
{
    private bool _isPressed;

    public bool IsPressed()
    {
        bool tempIsPressed = _isPressed;

        if (_isPressed)
            _isPressed = false;

        return tempIsPressed;
    }

    public void Press()
    {
        _isPressed = true;
    }
}
