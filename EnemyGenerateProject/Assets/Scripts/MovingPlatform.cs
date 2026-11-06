using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform _firstPoint;
    [SerializeField] private Transform _secondtPoint;
    [SerializeField] private float _speed;

    private Transform _target;

    private void Start()
    {
        _target = _firstPoint;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        if(transform.position == _target.position)
        {
            _target = _target == _firstPoint ? _secondtPoint : _firstPoint;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy enemy)) enemy.Die();
    }
}