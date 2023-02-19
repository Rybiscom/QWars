using UnityEngine;

public class Donations : MonoBehaviour
{
    private const string BAR_NAME = "Bar";
    private const string DONATION_LINK = "https://boosty.to/rybis";
    private const int MINIMUM_LEVEL_FROM_SHOW = 2;
    private const int PERCENT_CHANSE_SHOW = 20;

    private GameObject _bar;

    private void Start()
    {
        _bar = gameObject.transform.Find(BAR_NAME).gameObject;

        TryShowBar();
    }

    public void OpenDonationLink()
    {
        Application.OpenURL(DONATION_LINK);
    }

    public void OpenBar()
    {
        _bar.SetActive(true);
    }

    public void CloseBar()
    {
        _bar.SetActive(false);
    }

    private void TryShowBar()
    {
        bool show = Random.Range(1, 100) <= PERCENT_CHANSE_SHOW;

        if (GameStorage.Level.GetLevel() < MINIMUM_LEVEL_FROM_SHOW)
            show = false;

        if (!show)
            return;

        OpenBar();
    }
}
