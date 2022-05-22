using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class TheEndVideo : MonoBehaviour
{
    private VideoPlayer _videoPlayer;
    [SerializeField] private float delaySecondToMainMenu;

    private void Start()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _videoPlayer.Prepare();
        Debug.Log("Start Prepare video");
        _videoPlayer.prepareCompleted += source => Time.timeScale = 0f;
    }

    private void Update()
    {
        if (_videoPlayer.frame >= (long)_videoPlayer.frameCount - 4)
        {
            if (!_videoPlayer.isPaused)
                StartCoroutine(GoToMenu());
            _videoPlayer.Pause();
        }
    }

    IEnumerator GoToMenu()
    {
        yield return new WaitForSecondsRealtime(delaySecondToMainMenu);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
