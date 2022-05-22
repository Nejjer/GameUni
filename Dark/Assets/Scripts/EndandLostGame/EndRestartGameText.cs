using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRestartGameText : MonoBehaviour
{
    [SerializeField] private GameObject gameLostText;
    [SerializeField] private GameObject theEndGameText;
    void Start()
    {
        EventManager.OnRestartGame.AddListener(() => {gameLostText.SetActive(true);});
        EventManager.OnEndGame.AddListener(() => {theEndGameText.SetActive(true);});
    }
}

