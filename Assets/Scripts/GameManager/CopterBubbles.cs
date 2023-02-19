using System.Collections;
using UnityEngine;

public sealed class CopterBubbles : CopterInfo
{
    [SerializeField] private GameObject _bubbleGod;
    [SerializeField] private GameObject _bubbleDamage;

    private const float BUBBLE_UPDATE_TIME = 0.5f;

    private GameObject _prevBubble;

    private bool _bubbleCreated;

    private BubblesStates _bubblesStates;

    private void Start()
    {
        if (_bubbleGod == null)
            throw new System.Exception("Добавь префаб _bubbleGod");

        if (_bubbleDamage == null)
            throw new System.Exception("Добавь префаб _bubbleDamage");
    }

    public void UpdateStates(BubblesStates bubblesStates)
    {
        _bubblesStates = bubblesStates;
    }

    public void CreateBubble(Rigidbody2D target, IOpenCopter copter)
    {
        if (_bubbleCreated || target == null || copter == null)
            return;

        if (_bubblesStates.God)
        {
            GameStorage.Bubbles.SubtractBubbleCounts(Bubbles.Names.BubbleGod, 1);

            StartCoroutine(CreateBubble(target, copter, _bubbleGod));

            return;
        }

        if (_bubblesStates.Damage)
        {
            GameStorage.Bubbles.SubtractBubbleCounts(Bubbles.Names.BubbleDamage, 1);

            StartCoroutine(CreateBubble(target, copter, _bubbleDamage));

            return;
        }
    }

    private IEnumerator CreateBubble(Rigidbody2D target, IOpenCopter copter, GameObject bubble)
    {
        if (_bubbleCreated || target == null || copter == null)
            yield break;

        _bubbleCreated = true;

        _prevBubble = Instantiate(bubble);

        yield return null;

        _prevBubble.GetComponent<IBubble>().Init(target, copter);

        while (true)
        {
            if (_prevBubble != null)
                yield return new WaitForSeconds(BUBBLE_UPDATE_TIME);
            else
                break;
        }

        _bubbleCreated = false;
    }

}
