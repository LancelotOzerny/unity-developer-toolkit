using UnityEngine;
using UnityEngine.SceneManagement;

public class CMenuTools : MonoBehaviour
{
    /// <summary>
    /// �����, ������� ��������� ������� url � �������� �� ���������
    /// </summary>
    /// <param name="url">����������� ��������</param>
    public void OpenUrl(string url)
    {
        Application.OpenURL(url);
    }

    /// <summary>
    /// �����, ������� ��������� ������������� ������� �����
    /// </summary>
    public void RestartSene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// �����, ������� ��������� ������� ����� unity �� URL
    /// </summary>
    /// <param name="index">������ ����������� �����</param>
    public void OpenSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    /// <summary>
    /// �����, ������� ��������� ����� �� ������� ����
    /// </summary>
    public void ApplicationQuit()
    {
        Application.Quit();
    }
}
