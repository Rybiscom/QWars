using TMPro;
using UnityEngine;

public sealed class MenuComponents : MonoBehaviour
{
    [Header("Коптеры")]
    [SerializeField] public GameObject[] Copters;

    [Header("Элементы меню")]
    [SerializeField] public TextSmoothCounter Coins;
    [SerializeField] public TextSmoothCounter Rubins;

    [HideInInspector] public GameObject Menu;
    [HideInInspector] public GameObject CenterPanel;
    [HideInInspector] public GameObject DownPanel;
    [HideInInspector] public GameObject ButtonShop;
    [HideInInspector] public GameObject ButtonBuy;
    [HideInInspector] public GameObject Shop;
    [HideInInspector] public GameObject Settings;
    [HideInInspector] public GameObject InDeveloping;
    [HideInInspector] public LoadingWindow LoadingWindow;
    [HideInInspector] public TextMeshProUGUI ButtonBuyPrice;
    [HideInInspector] public TextMeshProUGUI TextLevel;

    private const string MENU_NAME = "Menu";
    private const string CENTER_PANEL_NAME = "CenterPanel";
    private const string DOWN_PANEL_NAME = "DownPanel";
    private const string BUTTON_SHOP_NAME = "ButtonShop";
    private const string BUTTON_BUY_NAME = "ButtonBuy";
    private const string SHOP_NAME = "Shop";
    private const string SETTINGS_NAME = "Settings";
    private const string IN_DEVELOPING_NAME = "InDeveloping";
    private const string BUTTON_BUY_PRICE_NAME = "Price";
    private const string LEVEL_NAME = "Level";
    private const string LEVEL_VALUE_NAME = "Value";

    private void Awake()
    {
        Menu = gameObject.transform.Find(MENU_NAME).gameObject;
        CenterPanel = Menu.transform.Find(CENTER_PANEL_NAME).gameObject;
        DownPanel = Menu.transform.Find(DOWN_PANEL_NAME).gameObject;
        ButtonShop = CenterPanel.transform.Find(BUTTON_SHOP_NAME).gameObject;
        ButtonBuy = CenterPanel.transform.Find(BUTTON_BUY_NAME).gameObject;
        Shop = Menu.transform.Find(SHOP_NAME).gameObject;
        Settings = Menu.transform.Find(SETTINGS_NAME).gameObject;
        InDeveloping = Menu.transform.Find(IN_DEVELOPING_NAME).gameObject;
        LoadingWindow = GameObject.FindGameObjectWithTag(Tags.LoadingWindow).GetComponent<LoadingWindow>();
        ButtonBuyPrice = ButtonBuy.transform.Find(BUTTON_BUY_PRICE_NAME).gameObject.GetComponent<TextMeshProUGUI>();
        TextLevel = DownPanel.transform.Find(LEVEL_NAME).gameObject.transform.Find(LEVEL_VALUE_NAME).gameObject.GetComponent<TextMeshProUGUI>();

        if (Copters.Length < 1)
            throw new System.Exception("Добавь хотя-бы 1 коптер в Copters");

        if (Coins == null)
            throw new System.Exception("Добавь TextSmoothCounter Coins");

        if (Rubins == null)
            throw new System.Exception("Добавь TextSmoothCounter Rubins");
    }
}
