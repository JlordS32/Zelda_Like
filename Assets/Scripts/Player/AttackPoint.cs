using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    [SerializeField] private float _aheadDistance = 0.5f;
    [SerializeField] private Transform _playerTransform;

    // References
    private Animator _animator;

    // Offset from the player's position
    private Vector3 _offset;
    private Vector3 _scaleOffset;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Keep the attack point's position relative to the player's position
        if (_playerTransform != null)
        {
            transform.position = _playerTransform.position + _offset;
            transform.localScale = _scaleOffset;
        }
    }

    public void UpdateDirection(int direction)
    {
        // Update the offset based on the direction
        switch (direction)
        {
            case 0:
                _offset = new Vector3(0, -_aheadDistance, 0);
                _scaleOffset = new Vector3(-1, -1, 1);
                break;
            case 1:
                _offset = new Vector3(0, _aheadDistance, 0);
                _scaleOffset = new Vector3(1, 1, 1);
                break;
            case 2:
                _offset = new Vector3(_aheadDistance, 0, 0);
                _scaleOffset = new Vector3(1, 1, 1);
                break;
            case 3:
                _offset = new Vector3(-_aheadDistance, 0, 0);
                _scaleOffset = new Vector3(-1, -1, 1);
                break;
            default:
                _offset = Vector3.zero;
                break;
        }
    }

    public void Attack()
    {
        _animator.SetTrigger("attack");
    }

    private void TakeDamage()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

    }

}
