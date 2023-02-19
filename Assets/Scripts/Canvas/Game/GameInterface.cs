using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public sealed class GameInterface : GameComponents
{
    private const float SMOOTHNESS = 0.05f;

    protected override void Start()
    {
        base.Start();
    }

    public void GoToMenu()
    {
        LoadScene(Config.Scenes.Menu.Name);
    }

    public void GoToRestart()
    {
        LoadScene(Config.Scenes.Game.Name);
    }

    public void ShowOne(CanvasElemet canvas)
    {
        foreach (var element in CanvasElemets)
        {
            if (element.Equals(canvas))
                Show(element, true);
            else
                Show(element, false);
        }

        UpdateCanvasesState();
    }

    public void SpawnText(string text)
    {
        if (PrevTextGameAlert != null)
            PrevTextGameAlert.Hide();

        GameObject textObject = Instantiate(TextGameAlert, CanvasInputGameObject.transform);

        PrevTextGameAlert = textObject.GetComponent<TextGameAlert>();

        PrevTextGameAlert.SetText(text);
    }

    public void SpawnAttentionPointer(Transform targetFrom, Transform targetTo)
    {
        GameObject attentionPointer = Instantiate(AttentionPointer, CanvasInputGameObject.transform);

        attentionPointer.GetComponent<AttentionPointer>().SetTarget(targetFrom, targetTo);
    }

    private async void LoadScene(string sceneName)
    {
        LoadingWindow?.Show();

        await Task.Delay(Config.DelayMsForLoadingWindow);

        SceneChange.Load(sceneName);
    }

    private void Show(CanvasElemet canvas, bool show)
    {
        canvas.Show = show;
    }

    private void UpdateCanvasesState()
    {
        foreach (var element in CanvasElemets)
            UpdateCanvasState(element);
    }

    private void UpdateCanvasState(CanvasElemet element)
    {
        StartCoroutine(AnimateShowCanvas(element));
    }

    private IEnumerator AnimateShowCanvas(CanvasElemet element)
    {
        var waitForFixedUpdate = new WaitForFixedUpdate();

        if (element.Show)
        {
            element.CanvasGroup.alpha = 0;

            element.GameObject.SetActive(true);

            while (element.CanvasGroup.alpha < 1)
            {
                element.CanvasGroup.alpha += SMOOTHNESS;

                yield return waitForFixedUpdate;
            }
        }
        else
        {
            element.CanvasGroup.alpha = 1;

            while (element.CanvasGroup.alpha > 0)
            {
                element.CanvasGroup.alpha -= SMOOTHNESS;

                yield return waitForFixedUpdate;
            }

            element.GameObject.SetActive(false);
        }
    }
}