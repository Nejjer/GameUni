using Player;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Transform _playerTransform;
    private Rigidbody2D _rb;
    private SpriteRenderer _renderer;
    private bool _canMove = false;
    private PlayerHealth _playerHealth;


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
        var player = GameObject.FindWithTag("Player");
        _playerTransform = player.GetComponent<Transform>();
        _playerHealth = player.GetComponent<PlayerHealth>();
        _rb = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        var vectorToPlayer = _playerHealth.IsAlive
            ? (_playerTransform.position - transform.position).normalized
            : -(_playerTransform.position - transform.position).normalized;
        _rb.velocity = !_playerHealth.IsAlive || _canMove ? vectorToPlayer : Vector2.zero;
        _renderer.flipX = vectorToPlayer.x < 0;
    }

    public void Spawn() => _canMove = true;
}