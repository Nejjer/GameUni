using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool pause;
    [SerializeField] private GameObject pausePanel;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        pause = false;
        Time.timeScale = 1f;
    }

    private void Pause()
    {
        pausePanel.SetActive(true);
        pause = true;
        Time.timeScale = 0f;
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
