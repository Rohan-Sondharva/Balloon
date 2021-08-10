using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // To Reference the Pause Menu
    [SerializeField] GameObject pauseMenuPanel;
    [SerializeField] GameObject pauseMenuUI;

    public void Pause()
    {
        pauseMenuPanel.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenuPanel.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
