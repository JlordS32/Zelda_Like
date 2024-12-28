using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Player Params")]
    [SerializeField] private float _attackCooldown;

    // References
    private Animator _animator;
    private PlayerMovement _movement;
    private Rigidbody2D _body;

    // Variables
    private float _attackCooldownValue;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<PlayerMovement>();
        _body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleAnimation();

        _attackCooldownValue += Time.deltaTime;
    }

    private void HandleAnimation()
    {
        if (Input.GetMouseButtonDown(0) && _attackCooldownValue >= _attackCooldown)
        {
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        // Store initial velocity value.
        Vector2 temp = _body.linearVelocity;
        
        // Trigger animation and reset cooldown
        _animator.SetTrigger("attack");
        _attackCooldownValue = 0;
        
        // Disable 
        _movement.enabled = false;
        _body.linearVelocity = Vector2.zero;

        yield return new WaitForSeconds(_attackCooldown);

        // Re-enable
        _movement.enabled = true;
        _body.linearVelocity = temp;
    }
}
