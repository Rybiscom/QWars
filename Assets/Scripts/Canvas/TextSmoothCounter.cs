using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]

public sealed class TextSmoothCounter : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public string GetText() => _text.text;

    public void StartSmoothCount(int from, int to)
    {
        StartCoroutine(SmoothCount(from, to));
    }

    private IEnumerator SmoothCount(int from, int to)
    {
        int current = from;
        int offset = CountOffset(from, to);

        if (from >= to)
            offset = -offset;

        while (true)
        {
            current += offset;

            if (current >= to && offset > 0)
            {
                SetText($"{to}");

                yield break;
            }
            else if (current <= to && offset < 0)
            {
                SetText($"{to}");

                yield break;
            }

            SetText($"{current}");

            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
    }

    private void SetText(string text)
    {
        _text.text = text;
    }

    private int CountOffset(int from, int to)
    {
        int difference = Mathf.Abs(from - to);

        if (difference >= 5000)
            return 500;

        if (difference >= 2000)
            return 100;

        if (difference >= 1000)
            return 50;

        if (difference >= 500)
            return 25;

        if (difference >= 100)
            return 5;

        return 1;
    }
}
