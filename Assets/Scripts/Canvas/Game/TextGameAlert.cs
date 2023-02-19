using TMPro;
using UnityEngine;

public sealed class TextGameAlert : MonoBehaviour, IActivable
{
    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        Destroy(gameObject);
    }

    public void Hide()
    {
        GetComponent<Animator>().SetTrigger("Hide");
    }

    public void SetText(string text)
    {
        GetComponent<TextMeshProUGUI>().text = text;
    }
}
