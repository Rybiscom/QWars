using UnityEngine;

public sealed class DevelopMode : MonoBehaviour, IActivable
{
    private const string BUTTON_NEXT_LEVEL_NAME = "NextLevel";
    private const string BUTTON_GET_MONEY_NAME = "GetMoney";
    private const string BUTTON_DELETE_ALL_NAME = "DeleteAll";

    private const int COINS_QUALITY = 5000;
    private const int RUBINS_QUALITY = 100;

    private GameObject _buttonNextLevel;
    private GameObject _buttonGetMoney;
    private GameObject _buttonDeleteAll;

    private void Start()
    {
        if (!CheckDebbugMode())
            Deactivate();

        _buttonNextLevel = gameObject.transform.Find(BUTTON_NEXT_LEVEL_NAME).gameObject;
        _buttonGetMoney = gameObject.transform.Find(BUTTON_GET_MONEY_NAME).gameObject;
        _buttonDeleteAll = gameObject.transform.Find(BUTTON_DELETE_ALL_NAME).gameObject;

        _buttonNextLevel.SetActive(true);
        _buttonGetMoney.SetActive(true);
        _buttonDeleteAll.SetActive(true);
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void LevelUp()
    {
        GameStorage.Level.LevelUp();

        MenuEvents.LevelChanged();
    }

    public void GetMoney()
    {
        GameStorage.Money.AddCoins(COINS_QUALITY);
        GameStorage.Money.AddRubins(RUBINS_QUALITY);

        MenuEvents.MoneyChanged();
    }

    public void DeleteAll()
    {
        GameStorage.ClearAllDataAndInit(true);

        SceneChange.Load(Config.Scenes.Menu.Name);
    }

    private bool CheckDebbugMode()
    {
        return Config.DebbugMode;
    }
}
