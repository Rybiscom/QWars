using UnityEngine;

public class GameComponents : MonoBehaviour
{
    [SerializeField] protected GameObject TextGameAlert;
    [SerializeField] protected GameObject AttentionPointer;

    [HideInInspector] public TextSmoothCounter CoinsWin;
    [HideInInspector] public TextSmoothCounter RubinsWin;
    [HideInInspector] public BubbleElements BubbleElements;

    public CanvasElemet CanvasInput { get; protected set; }
    public CanvasElemet CanvasDeath { get; protected set; }
    public CanvasElemet CanvasWin { get; protected set; }

    protected const string CANVAS_INPUT_NAME = "CanvasInput";
    protected const string CANVAS_DEATH_NAME = "CanvasDeath";
    protected const string CANVAS_WIN_NAME = "CanvasWin";
    protected const string COINS_NAME = "Coins";
    protected const string RUBINS_NAME = "Rubins";
    protected const string BUBBLES_NAME = "Bubbles";

    protected GameObject CanvasInputGameObject;
    protected GameObject CanvasDeathGameObject;
    protected GameObject CanvasWinGameObject;

    protected CanvasElemet[] CanvasElemets;

    protected TextGameAlert PrevTextGameAlert;

    protected LoadingWindow LoadingWindow;

    protected virtual void Start()
    {
        CanvasInputGameObject = gameObject.transform.Find(CANVAS_INPUT_NAME).gameObject;
        CanvasGroup canvasInputGroup = CanvasInputGameObject.GetComponent<CanvasGroup>();
        CanvasInput = new CanvasElemet(CANVAS_INPUT_NAME, false, CanvasInputGameObject, canvasInputGroup);

        CanvasDeathGameObject = gameObject.transform.Find(CANVAS_DEATH_NAME).gameObject;
        CanvasGroup canvasDeathGroup = CanvasDeathGameObject.GetComponent<CanvasGroup>();
        CanvasDeath = new CanvasElemet(CANVAS_DEATH_NAME, false, CanvasDeathGameObject, canvasDeathGroup);

        CanvasWinGameObject = gameObject.transform.Find(CANVAS_WIN_NAME).gameObject;
        CanvasGroup canvasWinGroup = CanvasWinGameObject.GetComponent<CanvasGroup>();
        CanvasWin = new CanvasElemet(CANVAS_WIN_NAME, false, CanvasWinGameObject, canvasWinGroup);

        BubbleElements = CanvasInputGameObject.transform.Find(BUBBLES_NAME).gameObject.GetComponent<BubbleElements>();

        CanvasElemets = new CanvasElemet[]
        {
            CanvasInput,
            CanvasDeath,
            CanvasWin
        };

        CoinsWin = CanvasWinGameObject.transform.Find(COINS_NAME).gameObject.GetComponent<TextSmoothCounter>();
        RubinsWin = CanvasWinGameObject.transform.Find(RUBINS_NAME).gameObject.GetComponent<TextSmoothCounter>();

        LoadingWindow = GameObject.FindGameObjectWithTag(Tags.LoadingWindow)?.GetComponent<LoadingWindow>() ?? null;

        if (TextGameAlert == null)
            throw new System.Exception("Добавь префаб TextGameAlert");

        if (AttentionPointer == null)
            throw new System.Exception("Добавь префаб AttentionPointer");
    }
}
