using UnityEngine;

public sealed class LoadingWindow : MonoBehaviour
{
    public static LoadingWindow instance;

    private const string CANVAS_NAME = "Canvas";

    private GameObject _canvas;
    private LoadingWindowCanvas _loadingWindowCanvas;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        Initialize();
    }

    public void Show()
    {
        _loadingWindowCanvas.Show();
    }

    private void Initialize()
    {
        _canvas = gameObject.transform.Find(CANVAS_NAME).gameObject;
        _loadingWindowCanvas = _canvas.GetComponent<LoadingWindowCanvas>();
    }
}

