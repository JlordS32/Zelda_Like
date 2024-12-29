using TMPro;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void Update()
    {
        if (_target == null) return;

        // Follow Player
        transform.position = new Vector3(_target.position.x, _target.position.y, transform.position.z);

        // Something
    }
}
