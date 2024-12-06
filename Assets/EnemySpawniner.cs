using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawniner : MonoBehaviour
{
    // Array of spawn points
    [SerializeField] private Transform[] spawner;

    // Enemy object
    [SerializeField] private GameObject enemyAI;
    
    // Time in seconds between spawns
    [SerializeField] private float spawnInterval = 5f;



    private void Start()
    {
        //Start the Coroutine to spawn enemies on a timer
        StartCoroutine(SpawnEnemiesWithTimer());
    }

    private IEnumerator SpawnEnemiesWithTimer()
    {
        while (true) // Infinite loop for continuous spawning
        {
            SpawnEnemyAI(); // Spawn an enemy
            yield return new WaitForSeconds(spawnInterval); // Wait before the next spawn
        }
    }

    private void SpawnEnemyAI()
    {
        // spawne a radom enemy at a radom location.
        int randomInt = Random.RandomRange(0, spawner.Length); // Get a random index within the array
        Transform randomSpawner = spawner[randomInt];
        Instantiate(enemyAI, randomSpawner.position, randomSpawner.rotation);

    }
}
