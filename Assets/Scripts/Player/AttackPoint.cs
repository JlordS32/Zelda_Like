using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    [SerializeField] private float _aheadDistance = 0.5f;

    // Reference to the player (optional, for better clarity)
    [SerializeField] private Transform _playerTransform;

    // Offset from the player's position
    private Vector3 _offset;

    private void Update()
    {
        // Keep the attack point's position relative to the player's position
        if (_playerTransform != null)
        {
            transform.position = _playerTransform.position + _offset;
        }
    }

    public void UpdateDirection(int direction)
    {
        // Update the offset based on the direction
        switch (direction)
        {
            case 0: 
                _offset = new Vector3(0, -_aheadDistance, 0);
                break;
            case 1:
                _offset = new Vector3(0, _aheadDistance, 0);
                break;
            case 2:
                _offset = new Vector3(_aheadDistance, 0, 0);
                break;
            case 3:
                _offset = new Vector3(-_aheadDistance, 0, 0);
                break;
            default:
                _offset = Vector3.zero;
                break;
        }
    }
}
