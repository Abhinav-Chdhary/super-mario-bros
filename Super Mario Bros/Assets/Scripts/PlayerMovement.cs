using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private float inputAxis;
    private Vector2 velocity;
    public float moveSpeed = 8.0f;
    private Camera _camera;
    public float maxJumpHeight = 5.0f;
    public float maxJumpTime = 1.0f;
    public float jumpForce => (2f * maxJumpHeight) / (maxJumpHeight / 2);
    public float gravity => (-2f * maxJumpHeight) / Mathf.Pow((maxJumpTime/2f), 2);

    public bool ground { get; private set; }
    public bool jumping { get; private set; }

    private void Awake()
    {
        _rigidbody= GetComponent<Rigidbody2D>();
        _camera= Camera.main;
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

        //bounds checking
        Vector2 leftEdge = _camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 rightEdge = _camera.ScreenToWorldPoint(new Vector2(Screen.width+0.5f, Screen.height-0.5f));
        position.x = Mathf.Clamp(position.x, leftEdge.x, rightEdge.x);

        _rigidbody.MovePosition(position);
    }
}
