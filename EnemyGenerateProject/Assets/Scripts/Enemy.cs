using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _movementDirection;

    private void Update()
    {
        transform.Translate(_movementDirection * _speed * Time.deltaTime, Space.World);
    }

    public void SetDirection(Vector3 direction)
    {
        _movementDirection = direction.normalized;
    }
}