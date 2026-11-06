using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _target;
    [SerializeField] private float _delay;

    private void Start()
    {
        StartCoroutine(CreateEnemy());
    }

    private IEnumerator CreateEnemy()
    {
        var wait = new WaitForSeconds(_delay);

        while (isActiveAndEnabled)
        {
            yield return wait;

            Enemy enemy = Instantiate(_enemy, transform.position, transform.rotation);
            enemy.SetTarget(_target);
        }
    }
}
