using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private float _minimumSpawnTime;

    [SerializeField]
    private float _maximumSpawnTime;

    private float _timeUntilSpawn;

    
    void Awake()
    {
        // Set the initial random spawn timer
        SetTimeUntilSpawn();
    }

    
    void Update()
    {
        // Reduce the timer by the time passed since last frame
        _timeUntilSpawn -= Time.deltaTime;

        // If time is up, spawn a new enemy
        if (_timeUntilSpawn <= 0)
        {
            // Instantiate a new enemy at this object's position with no rotation
            Instantiate(_enemyPrefab, transform.position, Quaternion.identity);

            // Reset the spawn timer for the next enemy
            SetTimeUntilSpawn();
        }
    }

    // Set a random time between min and max for the next spawn
    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }
}
