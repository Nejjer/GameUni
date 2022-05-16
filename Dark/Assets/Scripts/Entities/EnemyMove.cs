using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Transform _playerTransform;
    private Rigidbody2D _rb;
    private bool _canMove = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            _canMove = false;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            _canMove = true;
    }

    private void Start()
    {
        _playerTransform = player.GetComponent<Transform>();
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