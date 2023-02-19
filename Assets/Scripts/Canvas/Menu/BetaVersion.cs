using System.Threading.Tasks;
using UnityEngine;

public sealed class BetaVersion : MonoBehaviour
{
    private const string BETA_VERSION_PARAMETER = "__beta_version";
    private const string BAR_FINAL_NAME = "BarFinal";
    private const string BAR_NAME = "Bar";

    private const int MAX_BETA_LEVEL = 51;

    private GameObject _barFinal;
    private GameObject _bar;

    private void Start()
    {
        _barFinal = gameObject.transform.Find(BAR_FINAL_NAME).gameObject;
        _bar = gameObject.transform.Find(BAR_NAME).gameObject;

        UpdateBar();

        UpdateEndOfBeta();
    }

    public void ShowBar() => _bar.SetActive(true);
    public void HideBar() => _bar.SetActive(false);

    public void ShowFinalBar() => _barFinal.SetActive(true);
    private void HideFinalBar() => _barFinal.SetActive(false);

    public async void TryAgain()
    {
        LoadingWindow loadingWindow = GameObject.FindGameObjectWithTag(Tags.LoadingWindow)?.GetComponent<LoadingWindow>() ?? null;

        loadingWindow?.Show();

        await Task.Delay(Config.DelayMsForLoadingWindow);

        GameStorage.ClearAllDataAndInit(true);

        GameStorage.Money.AddCoins(100000);
        GameStorage.Money.AddRubins(1000);

        SceneChange.Load(Config.Scenes.Menu.Name);
    }

    private void UpdateBar()
    {
        if (!Storage.HasKey(BETA_VERSION_PARAMETER) || Storage.GetInt(BETA_VERSION_PARAMETER) != 1)
        {
            Storage.Save(BETA_VERSION_PARAMETER, 1);

            ShowBar();
        }
    }

    private void UpdateEndOfBeta()
    {
        if (GameStorage.Level.GetLevel() >= MAX_BETA_LEVEL)
        {
            ShowFinalBar();
        }
    }
}
