using UnityEngine;
using UnityEngine.SceneManagement;

public class CMenuTools : MonoBehaviour
{
    /// <summary>
    /// Метод, который позволяет открыть url в браузере по умолчанию
    /// </summary>
    /// <param name="url">открываемая страница</param>
    public void OpenUrl(string url)
    {
        Application.OpenURL(url);
    }

    /// <summary>
    /// Метод, который позволяет перезапустить текущую сцену
    /// </summary>
    public void RestartSene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Метод, который позволяет открыть сцену unity по URL
    /// </summary>
    /// <param name="index">Индекс открываемой сцены</param>
    public void OpenSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    /// <summary>
    /// Метод, который позволяет выйти из текущей игры
    /// </summary>
    public void ApplicationQuit()
    {
        Application.Quit();
    }
}
