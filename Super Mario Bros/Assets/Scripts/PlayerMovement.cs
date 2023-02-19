using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private float inputAxis;
    private Vector2 velocity;
    public float moveSpeed = 8.0f;

    private void Awake()
    {
        _rigidbody= GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        HorizontalMovement();
    }
    private void HorizontalMovement()
    {
        inputAxis = Input.GetAxis("Horizontal");
        velocity.x = Mathf.MoveTowards(velocity.x, inputAxis*moveSpeed, moveSpeed*Time.deltaTime);
    }
    private void FixedUpdate()
    {
        Vector2 position = _rigidbody.position;
        position += velocity * Time.fixedDeltaTime;

        _rigidbody.MovePosition(position);
    }
}
