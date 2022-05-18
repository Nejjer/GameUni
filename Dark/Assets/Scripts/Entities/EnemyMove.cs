using System;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Transform _playerTransform;
    private Rigidbody2D _rb;
    private bool _canMove = false;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
            _canMove = false;
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
            _canMove = true;
    }


    private void Start()
    {
        _playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = _canMove ? (_playerTransform.position - transform.position).normalized : Vector2.zero;
    }

    public void Spawn()
    {
        _canMove = true;
    }
}