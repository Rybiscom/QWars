using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(MenuComponents))]

public sealed class MenuInterace : MonoBehaviour
{
    public enum UiButtons
    {
        Play,
        Shop,
        CloseShop,
        CloseInDeveloping,
        Settings,
        CloseSettings,
        CoptersLeft,
        CoptersRight,
        BuyCopter
    }

    private int _oldCoins;
    private int _oldRubis;

    private MenuComponents _menuComponents;

    private int _currentCopterIndex;
    private GameObject _currentCopter;

    private void Start()
    {
        _menuComponents = GetComponent<MenuComponents>();

        InitInterface();

        SubscribeToEvents();
    }

    public void ClickPlay() => ClickButton(UiButtons.Play);

    public void ClickShop() => ClickButton(UiButtons.Shop);

    public void ClickCloseShop() => ClickButton(UiButtons.CloseShop);

    public void ClickCloseInDeveloping() => ClickButton(UiButtons.CloseInDeveloping);

    public void ClickSettings() => ClickButton(UiButtons.Settings);

    public void ClickCloseSettings() => ClickButton(UiButtons.CloseSettings);

    public void ClickCoptersLeft() => ClickButton(UiButtons.CoptersLeft);

    public void ClickCoptersRigt() => ClickButton(UiButtons.CoptersRight);

    public void ClickBuyCopter() => ClickButton(UiButtons.BuyCopter);

    private void ClickButton(UiButtons button)
    {
        switch (button)
        {
            case UiButtons.Play:
                GoToGame();
                break;

            case UiButtons.Shop:
                ShopSetActive(true);
                break;

            case UiButtons.CloseShop:
                ShopSetActive(false);
                break;

            case UiButtons.CloseInDeveloping:
                InDevelopingSetActive(false);
                break;

            case UiButtons.CoptersLeft:
                SwipeCopter(false);
                break;

            case UiButtons.CoptersRight:
                SwipeCopter(true);
                break;

            case UiButtons.BuyCopter:
                TryBuyCurrentCopter();
                break;

            case UiButtons.Settings:
                SettingsSetActive(true);
                break;

            case UiButtons.CloseSettings:
                SettingsSetActive(false);
                break;
        }
    }

    private async void GoToGame()
    {
        _menuComponents.LoadingWindow?.Show();

        await Task.Delay(Config.DelayMsForLoadingWindow);

        SceneChange.Load(Config.Scenes.Game.Name);
    }

    private void InitInterface()
    {
        InitCopter();

        UpdateUIMoney();
        UpdateUILevel();
    }

    private void SubscribeToEvents()
    {
        MenuEvents.OnMoneyChanged.AddListener(UpdateUIMoney);
        MenuEvents.OnLevelChanged.AddListener(UpdateUILevel);
    }

    private void InitCopter()
    {
        string currentCopterName = GameStorage.PlayerCopter.GetCurrentPlayerCopter();

        for(int i = 0; i < _menuComponents.Copters.Length; i++)
        {
            if (_menuComponents.Copters[i].GetComponent<CopterElement>().GetName() == currentCopterName)
                _currentCopterIndex = i;
        }

        _currentCopter = SpawnNewCopter(_menuComponents.Copters[_currentCopterIndex]);
    }

    private void UpdateUIMoney()
    {
        int newCoins = GameStorage.Money.GetCoins();
        int newRubins = GameStorage.Money.GetRubins();

        if (newCoins != _oldCoins)
            _menuComponents.Coins.StartSmoothCount(_oldCoins, newCoins);

        if (newRubins != _oldRubis)
            _menuComponents.Rubins.StartSmoothCount(_oldRubis, newRubins);

        _oldCoins = newCoins;
        _oldRubis = newRubins;
    }

    private void UpdateUILevel()
    {
        _menuComponents.TextLevel.text = GameStorage.Level.GetLevel().ToString();
    }

    private void ShopSetActive(bool active)
    {
        _menuComponents.Shop.SetActive(active);
    }

    private void SettingsSetActive(bool active)
    {
        _menuComponents.Settings.SetActive(active);
    }

    private void InDevelopingSetActive(bool active)
    {
        _menuComponents.InDeveloping.SetActive(active);
    }

    private void TryBuyCurrentCopter()
    {
        bool success = _currentCopter.GetComponent<CopterElement>().TryBuyCopter();

        if (success)
        {
            MenuEvents.MoneyChanged();

            SwipeCopterCurrent();

            _menuComponents.ButtonBuy.GetComponent<ButtonBuy>().SpawnSuccessParticles();
        }
        else
        {
            _menuComponents.ButtonBuy.GetComponent<ButtonBuy>().TriggerErrorAnimate();
        }
    }

    private void SwipeCopter(bool right)
    {
        if (right)
            SwipeCopterNext();
        else
            SwipeCopterPrevious();
    }

    private void SwipeCopterNext()
    {
        int lastCoptersIndex = _menuComponents.Copters.Length - 1;

        _currentCopterIndex++;

        if (_currentCopterIndex > lastCoptersIndex)
        {
            _currentCopterIndex = lastCoptersIndex;

            return;
        }

        DestroyCopter(_currentCopter);

        _currentCopter = SpawnNewCopter(_menuComponents.Copters[_currentCopterIndex]);
    }

    private void SwipeCopterCurrent()
    {
        DestroyCopter(_currentCopter);

        _currentCopter = SpawnNewCopter(_menuComponents.Copters[_currentCopterIndex]);
    }

    private void SwipeCopterPrevious()
    {
        int firstCopterIndex = 0;

        _currentCopterIndex--;

        if (_currentCopterIndex < firstCopterIndex)
        {
            _currentCopterIndex = firstCopterIndex;

            return;
        }

        DestroyCopter(_currentCopter);

        _currentCopter = SpawnNewCopter(_menuComponents.Copters[_currentCopterIndex]);
    }

    private GameObject SpawnNewCopter(GameObject copter)
    {
        GameObject newCopter = Instantiate(copter, _menuComponents.CenterPanel.transform);

        UpdateCopterState(newCopter);

        return newCopter;
    }

    private void UpdateCopterState(GameObject copter)
    {
        CopterElement copterElement = copter.GetComponent<CopterElement>();

        string copterName = copterElement.GetName();
        bool isPurchased = GameStorage.PlayerCopter.CheckCopterIsPurchased(copterName);
        int copterPrice = Config.CoptersInfo.Copters[copterElement.GetName()].Price;

        copterElement.Init(isPurchased, copterPrice);

        UpdateCenterButtonsActive(isPurchased);
        SetButtonBuyPrice(isPurchased, copterElement.GetPrice());

        TrySetPlayerCopterToStorage(isPurchased, copterName);
    }

    private void TrySetPlayerCopterToStorage(bool isPurchased, string name)
    {
        if (isPurchased)
            GameStorage.PlayerCopter.SetCurrentPlayerCopter(name);
    }

    private void SetButtonBuyPrice(bool isPurchased, int price)
    {
        if (!isPurchased)
            _menuComponents.ButtonBuyPrice.text = $"{price}";
    }

    private void UpdateCenterButtonsActive(bool isPurchased)
    {
        if (isPurchased)
        {
            _menuComponents.ButtonShop.SetActive(true);
            _menuComponents.ButtonBuy.SetActive(false);
        }
        else
        {
            _menuComponents.ButtonShop.SetActive(false);
            _menuComponents.ButtonBuy.SetActive(true);
        }
    }

    private void DestroyCopter(GameObject copter)
    {
        if (copter != null)
            copter.GetComponent<CopterElement>().HideAndDestroyCopter();
    }
}
