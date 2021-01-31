using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void LoadMainMenu()
    {
        LoadScene("MainMenuScene");
    }
    public void LoadGame()
    {
        LoadScene("GameScene");
    }
    public void LoadGameOverScene()
    {
        LoadScene("GameOverScene");
    }
    public void LoadCreditScene()
    {
        LoadScene("CreditScene");
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
