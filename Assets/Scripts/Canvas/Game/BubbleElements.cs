using UnityEngine;

public sealed class BubbleElements : MonoBehaviour
{
    private const string BUBBLE_DAMAGE_NAME = "BubbleDamage";
    private const string BUBBLE_GOD_NAME = "BubbleGod";

    private GameObject _bubbleDamage;
    private GameObject _bubbleGod;

    private void Start()
    {
        _bubbleDamage = gameObject.transform.Find(BUBBLE_DAMAGE_NAME).gameObject;
        _bubbleGod = gameObject.transform.Find(BUBBLE_GOD_NAME).gameObject;
    }

    public void ShowBubble(Bubbles.Names bubble, bool show)
    {
        switch (bubble)
        {
            case Bubbles.Names.BubbleDamage:
                Show(_bubbleDamage, show);
                break;

            case Bubbles.Names.BubbleGod:
                Show(_bubbleGod, show);
                break;
        }
    }

    private void Show(GameObject bubble, bool show)
    {
        bubble.SetActive(show);
    }
}
