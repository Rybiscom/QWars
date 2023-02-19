using System.Collections;
using TMPro;
using UnityEngine;

public sealed class ButtonEffectsAmount : MonoBehaviour
{
    private const string TEXT_NAME = "Text";

    private TextMeshProUGUI _text;

    private CameraPostProcessing _cameraPostProcessing;

    private SettingsStorage.Amount _amount;

    private void Start()
    {
        _text = gameObject.transform.Find(TEXT_NAME).gameObject.GetComponent<TextMeshProUGUI>();

        _cameraPostProcessing = Camera.main.gameObject.GetComponent<CameraPostProcessing>();

        _amount = GameStorage.Settings.GetCurrentAmount();

        UpdateText();
    }

    private void OnDisable()
    {
        ClearCameraEffects();
    }

    public void SetNextAmount()
    {
        NextAmount();

        UpdateText();

        StartCoroutine(AnimateCamera());
    }

    private void NextAmount()
    {
        _amount = GameStorage.Settings.GetNextAmount(_amount);

        GameStorage.Settings.SetPostProcessVolume(_amount);
    }

    private void UpdateText()
    {
        string newText = "";

        switch (_amount)
        {
            case SettingsStorage.Amount.Easy:
                newText = "Easy";
                break;

            case SettingsStorage.Amount.Medium:
                newText = "Medium";
                break;

            case SettingsStorage.Amount.Hard:
                newText = "Hard";
                break;
        }

        _text.text = newText;
    }

    private void ClearCameraEffects()
    {
        if (_cameraPostProcessing != null)
            _cameraPostProcessing.SetWeight(0);
    }

    private IEnumerator AnimateCamera()
    {
        float weightOffset = 0.02f;
        float maxWeight = 0.7f;

        var waitForFixedUpdate = new WaitForFixedUpdate();

        float postProcessVolumeFactor = GameStorage.Settings.GetPostProcessVolumeFactor();

        while (maxWeight > 0)
        {
            _cameraPostProcessing.SetWeight(maxWeight, postProcessVolumeFactor);

            maxWeight -= weightOffset;

            yield return waitForFixedUpdate;
        }

        ClearCameraEffects();
    }
}
