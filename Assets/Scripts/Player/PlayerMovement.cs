using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Params")]
    [SerializeField] private float _speed = 1;

    // References
    private Rigidbody2D _body;
    private Animator _animator;

    // Direction Constants
    private const int DOWN = 0;
    private const int UP = 1;
    private const int RIGHT = 2;
    private const int LEFT = 3;

    // Variables
    private Vector2 _change;
    private int _direction;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Movement();

        // Pass direction reference and update value based on 
        // player movement.
        GetDirection();

        // Animation handler
        HandleAnimation(_direction);
    }

    // Core method to handle player movement logic.
    private void Movement()
    {
        _change.x = Input.GetAxis("Horizontal");
        _change.y = Input.GetAxis("Vertical");

        if (_change.magnitude > 1)
        {
            _change.Normalize();
        }

        // Move the player
        _body.linearVelocity = _change * _speed;
    }

    // Returns the direction based on the strongest axis of movement:
    // 0: Down, 1: Up, 2: Right, 3: Left
    private void GetDirection()
    {
        // Horizontal 
        if (Mathf.Abs(_change.x) > Mathf.Abs(_change.y))
        {
            _direction = _change.x > 0 ? RIGHT : LEFT; 
        }

        // Vertical
        else if (Mathf.Abs(_change.y) > 0)
        {
            _direction = _change.y > 0 ? UP : DOWN;
        }
    }

    private void HandleAnimation(float direction)
    {
        // Change idle animation state based on direction
        _animator.SetFloat("direction", direction);

        // Handle walking animation
        _animator.SetFloat("horizontal", _change.x);
        _animator.SetFloat("vertical", _change.y);
        _animator.SetFloat("speed", _change.magnitude);
    }
}
