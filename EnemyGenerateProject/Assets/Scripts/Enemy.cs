using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private ParticleSystem _effect;

    private Transform _target;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        transform.LookAt(_target);
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void Die()
    {
        Instantiate(_effect, transform.position, Quaternion.identity);

        _effect.Play();
        Destroy(gameObject);
    }
}