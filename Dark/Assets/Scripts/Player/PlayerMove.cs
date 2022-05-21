using System;
using Player;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    private PlayerHealth _health;
    private Rigidbody2D _rb;
    private bool _rightFace = true;
    private Animator _animator;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _health = GetComponent<PlayerHealth>();
    }

    private Vector2 MovementVector
    {
        get
        {
            var axisX = Input.GetAxis("Horizontal") * speed;
            var axisY = Input.GetAxis("Vertical") * speed;
            _animator.SetBool("Run", axisX != 0 || axisY != 0);
            Vector2 dir = new Vector2(axisX, axisY);
            Flip(axisX);
            return Vector3.ClampMagnitude(dir, speed);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rb.velocity = _health.IsAlive ? transform.TransformDirection(MovementVector) : Vector2.zero;
    }

    private void Flip(float moveInput)
    {
        var scaler = transform.localScale;
        if (_rightFace == false && moveInput > 0)
        {
            _rightFace = !_rightFace;
            scaler.x *= -1;
        }
        else if (_rightFace && moveInput < 0)
        {
            _rightFace = !_rightFace;
            scaler.x *= -1;
        }

        transform.localScale = scaler;
    }
}