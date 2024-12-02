using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawniner : MonoBehaviour
{
    [SerializeField] private Transform[] spawner;

    [SerializeField] private GameObject enemyAI;

    [SerializeField] private float spawnInterval = 5f;



    private void Start()
    {
        // Start the Coroutine to spawn enemies on a timer
        //StartCoroutine(SpawnEnemiesWithTimer());
    }

    //private IEnumerator SpawnEnemiesWithTimer()
    //{
    //    while (true) // Infinite loop for continuous spawning
    //    {
    //        S; // Spawn an enemy
    //        yield return new WaitForSeconds(spawnInterval); // Wait before the next spawn
    //    }
    //}

    private void SpawnAnemyAI()
    {
        // spawne a radom enemy at a radom location.
        int randomInt = Random.RandomRange(1, spawner.Length);
        Transform randomSpawner = spawner[randomInt];
        Instantiate(enemyAI, randomSpawner.position, randomSpawner.rotation);

    }
}
