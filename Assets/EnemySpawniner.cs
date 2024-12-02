using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawniner : MonoBehaviour
{
    [SerializeField] private Transform[] spawner;

    [SerializeField] private GameObject enemyAI;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SpawnAnemyAI();
        }
    }

    private void SpawnAnemyAI()
    {
        // spawne a radom enemy at a radom location.
        int randomInt = Random.RandomRange(1, spawner.Length);
        Transform randomSpawner = spawner[randomInt];
        Instantiate(enemyAI, randomSpawner.position, randomSpawner.rotation);

    }
}
