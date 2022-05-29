using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        PlaySound();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void ExitGame()
    {
        Debug.Log("Exit Game");
        PlaySound();
        Application.Quit();
    }

    public void PlaySound()
    {
        //GetComponent<AudioSource>().Play();
    }
}
