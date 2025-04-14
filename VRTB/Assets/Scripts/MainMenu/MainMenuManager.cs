using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void Exit()
    {
        #if UNITY_EDITOR
        // ���� ���� �������� � ��������� Unity
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // ���� ���� �������� ��� ����������
        Application.Quit();
        #endif
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
