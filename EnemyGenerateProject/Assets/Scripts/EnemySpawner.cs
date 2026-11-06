using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform[] _spawnPoints;
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

            int index = Random.Range(0, _spawnPoints.Length);
            Transform spawnPoint = _spawnPoints[index];

            Enemy enemy = Instantiate(_enemy, spawnPoint.position, spawnPoint.rotation);
            enemy.SetDirection(spawnPoint.forward);
        }
    }
}
