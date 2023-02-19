using UnityEngine;

public sealed class ShopBubbleElement : MonoBehaviour
{
    [SerializeField] private Bubbles.Names _bubbleName;

    private const string BUTTON_BUY_NAME = "Buy";
    private const string TEXT_PRICE_NAME = "Price";
    private const string TEXT_COUNT_NAME = "Count";

    private GameObject _buttonBuy;

    private TextSmoothCounter _price;
    private TextSmoothCounter _count;

    private int _bubblePrice;

    private void Start()
    {
        _buttonBuy = gameObject.transform.Find(BUTTON_BUY_NAME).gameObject;

        _price = _buttonBuy.transform.Find(TEXT_PRICE_NAME).gameObject.GetComponent<TextSmoothCounter>();
        _count = gameObject.transform.Find(TEXT_COUNT_NAME).gameObject.GetComponent<TextSmoothCounter>();

        _bubblePrice = Config.Bubbles.GetPrice(_bubbleName);

        UpdateInterface();
    }

    public void ClickBuy()
    {
        bool checkRubins = CheckRubins(_bubblePrice);

        if (!checkRubins)
            return;

        GameStorage.Money.SubtractRubins(_bubblePrice);

        GameStorage.Bubbles.AddBubbleCounts(_bubbleName, 1);

        UpdateInterface();
    }

    private bool CheckRubins(int price)
    {
        if (GameStorage.Money.GetRubins() >= price)
            return true;
        else
            return false;
    }

    private void UpdateInterface()
    {
        int count = GameStorage.Bubbles.GetCounts(_bubbleName);

        UpdateInteface(_bubblePrice, count);
    }

    private void UpdateInteface(int price, int count)
    {
        _price.StartSmoothCount(0, price);
        _count.StartSmoothCount(0, count);

        MenuEvents.MoneyChanged();
    }
}
