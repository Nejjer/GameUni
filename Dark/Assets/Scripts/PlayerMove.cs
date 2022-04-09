using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private Vector2 MovementVector
    {
        get
        {
            float axisX = Input.GetAxis("Horizontal") * speed;
            float axisY = Input.GetAxis("Vertical") * speed;
            Vector2 dir = new Vector2(axisX, axisY);
            return Vector3.ClampMagnitude(dir, speed);
        }

    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rb.velocity = transform.TransformDirection(MovementVector);
    }
}
