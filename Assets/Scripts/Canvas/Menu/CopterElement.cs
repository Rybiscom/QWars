using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Image))]

public sealed class CopterElement : MonoBehaviour
{
    [SerializeField] private Config.CoptersInfo.Names _copterName;

    private const string SHOW_PARAMETER = "Show";
    private const string HIDE_PARAMETER = "Hide";
    private const float TIME_TO_DESTROY = 0.5f;

    private Animator _animator;
    private Image _image;

    private bool _isPurchased;
    private int _copterPrice;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _image = GetComponent<Image>();

        ShowCopter(_isPurchased);
    }

    public string GetName() => Config.CoptersInfo.GetStringName(_copterName);

    public int GetPrice() => _copterPrice;

    public void Init(bool isPurchased, int copterPrice)
    {
        _isPurchased = isPurchased;
        _copterPrice = copterPrice;
    }

    public void HideAndDestroyCopter()
    {
        _animator.SetTrigger(HIDE_PARAMETER);

        Destroy(gameObject, TIME_TO_DESTROY);
    }

    public bool TryBuyCopter()
    {
        if (_isPurchased)
            return false;

        string currentCopterName = GetName();
        bool successSubstractCoins = false;
        bool success = false;

        int price = GetPrice();
        int coins = GameStorage.Money.GetCoins();

        if (coins >= price)
            successSubstractCoins = GameStorage.Money.SubtractCoins(price);

        if (successSubstractCoins)
        {
            GameStorage.PlayerCopter.SetCopterStatusPurchaseSuccess(currentCopterName);

            success = true;
        }

        if (success)
            return true;
        else
            return false;
    }

    private void ShowCopter(bool isPurchased)
    {
        if (!isPurchased)
            _image.color = new Color(0, 0, 0);

        gameObject.SetActive(true);

        _animator.SetTrigger(SHOW_PARAMETER);
    }
}
