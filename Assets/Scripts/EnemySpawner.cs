using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _secondsBetweenSpawns;

    private Transform[] spawnPoint;

    private void Start()
    {
        spawnPoint = new Transform[_spawnPoint.childCount];

        for (int i = 0; i < _spawnPoint.childCount; i++)
        {
            spawnPoint[i] = _spawnPoint.GetChild(i);
        }

        StartCoroutine(Creature(_secondsBetweenSpawns));
    }

    private IEnumerator Creature(float seconds)
    {
        var countSpawns = 0;
        var waitForSeconds = new WaitForSeconds(seconds);

        while (true)
        {
            Instantiate(_enemyPrefab, spawnPoint[countSpawns].position, Quaternion.identity);
            yield return waitForSeconds;

            countSpawns++;

            if (countSpawns >= spawnPoint.Length)
            {
                countSpawns = 0;
            }
        }
    }
}
