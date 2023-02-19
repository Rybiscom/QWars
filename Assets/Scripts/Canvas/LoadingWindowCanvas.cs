using UnityEngine;

public sealed class LoadingWindowCanvas : MonoBehaviour
{
    public void Show() => gameObject.SetActive(true);

    public void Hide() => gameObject.SetActive(false);
}
