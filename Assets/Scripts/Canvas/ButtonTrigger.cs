using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]

public sealed class ButtonTrigger : MonoBehaviour, IPressed
{
    private bool _isPressed;

    private void Start()
    {
        EventTrigger eventTrigger = GetComponent<EventTrigger>();

        EventTrigger.Entry pointerEnter = new EventTrigger.Entry();
        pointerEnter.eventID = EventTriggerType.PointerEnter;
        pointerEnter.callback.AddListener((data) => { OnPressEnter(); });

        eventTrigger.triggers.Add(pointerEnter);

        EventTrigger.Entry pointerExit = new EventTrigger.Entry();
        pointerExit.eventID = EventTriggerType.PointerExit;
        pointerExit.callback.AddListener((data) => { OnPressExit(); });

        eventTrigger.triggers.Add(pointerExit);
    }

    private void OnDisable()
    {
        _isPressed = false;
    }

    public bool IsPressed() => _isPressed;

    private void OnPressEnter() => _isPressed = true;

    private void OnPressExit() => _isPressed = false;
}
