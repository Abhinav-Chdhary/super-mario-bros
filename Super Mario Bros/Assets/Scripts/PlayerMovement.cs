using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private float inputAxis;
    private Vector2 velocity;
    public float moveSpeed = 8.0f;
    private Camera _camera;

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
        Vector2 leftEdge = _camera.WorldToScreenPoint(Vector2.zero);
        Vector2 rightEdge = _camera.WorldToScreenPoint(new Vector2(Screen.width, Screen.height));
        position.x = Mathf.Clamp(position.x, leftEdge.x, rightEdge.x);

        _rigidbody.MovePosition(position);
    }
}
