using System;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeed = 8f;
    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = player.GetComponent<Transform>();
    }

    private void Update()
    {
        var position = _playerTransform.position;
        var target = new Vector3
        {
            x = position.x,
            y = position.y,
            z = position.z - 10,
        };
        transform.position = Vector3.Lerp(transform.position, target, moveSpeed * Time.fixedDeltaTime);
    }
}