using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void Exit()
    {
        #if UNITY_EDITOR
        // Если игра запущена в редакторе Unity
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // Если игра запущена как приложение
        Application.Quit();
        #endif
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
