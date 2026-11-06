using UnityEngine;

public class BotMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _arrivalDistance;


    private Rigidbody _rigidbody;
    private int _currentWayPointIndex;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Transform currentWayPoint = _wayPoints[_currentWayPointIndex];

        float distance = Vector3.Distance(_rigidbody.position, currentWayPoint.position);

        if(distance <= _arrivalDistance)
        {
            ChooseNextWayPoint();
            currentWayPoint = _wayPoints[_currentWayPointIndex];
        }

        Vector3 direction = (currentWayPoint.position - _rigidbody.position).normalized;
        _rigidbody.AddForce(direction * _moveSpeed);
    }

    private void ChooseNextWayPoint()
    {
        int nextIndex = Random.Range(0, _wayPoints.Length - 1);

        if(nextIndex >= _currentWayPointIndex) nextIndex++;

        _currentWayPointIndex = nextIndex;

        Debug.Log($"Выбрана точка: {_wayPoints[_currentWayPointIndex].name}");
    }
}
