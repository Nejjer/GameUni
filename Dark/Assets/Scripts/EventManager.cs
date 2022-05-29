using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager
{
    public static UnityEvent OnRestartGame = new UnityEvent();
    public static UnityEvent OnEndGame = new UnityEvent();

    public static void SendRestartGame()
    {
        OnRestartGame.Invoke();
        Debug.Log("Send restart event");
    }
    public static void SendEndGame()
    {
        OnEndGame.Invoke();
    }
}
