using UnityEngine;

public class TheEndText : MonoBehaviour
{
    [SerializeField] private GameObject videPlayerObject;

    public void StartVideo() => videPlayerObject.SetActive(true);
}