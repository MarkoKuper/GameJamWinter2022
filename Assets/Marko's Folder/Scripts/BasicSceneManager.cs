        using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicSceneManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject winMenu;
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        GameManager.instance.UnpauseGame();
        PlayerPrefs.SetInt("Collectables", 0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
    }

    public void WinLevel()
    {
        winMenu.SetActive(true);
    }
}
