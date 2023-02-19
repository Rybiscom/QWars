using UnityEngine.SceneManagement;

public static class SceneChange
{
    public static void Load(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}
