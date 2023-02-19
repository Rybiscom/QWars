using UnityEngine;

public sealed class CanvasElemet
{
    public CanvasElemet(string name, bool show, GameObject gameObject, CanvasGroup canvasGroup)
    {
        Name = name;
        Show = show;
        GameObject = gameObject;
        CanvasGroup = canvasGroup;
    }

    public readonly string Name;
    public readonly GameObject GameObject;
    public readonly CanvasGroup CanvasGroup;

    public bool Show { get; set; }
}
