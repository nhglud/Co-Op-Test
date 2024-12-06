using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAim : MonoBehaviour
{
    private List<GameObject> enemiesInRange = new List<GameObject>();
    [SerializeField] Transform playerTrans;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 updateAimDirection ()
    {
        if (enemiesInRange.Count < 1)
        {
            return new Vector3();
        }
        else
        {
            print("EnemyInsight");
            GameObject enemy = UpdateClosestEnemy();

            return (enemy.transform.position - playerTrans.position);

        }

    }

    public GameObject GetClosesEnemy ()
    {
        if (enemiesInRange.Count < 1)
        {
            return null;
        }


        return UpdateClosestEnemy();
    }

    private GameObject UpdateClosestEnemy ()
    {
        if (enemiesInRange.Count < 1)
        {
            return null;
        }

        else
        {
            GameObject closestEnemy = enemiesInRange[0];
            for (int i = 0; i < enemiesInRange.Count; i++)
            {
                Vector3 currentEnemyPos = enemiesInRange[i].transform.position;


                if (Vector3.Distance(playerTrans.position, currentEnemyPos) < Vector3.Distance(playerTrans.position, closestEnemy.transform.position))
                {
                    closestEnemy = enemiesInRange[i];
                }

            }
            return closestEnemy;
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            enemiesInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            enemiesInRange.Remove(other.gameObject);
        }
    }





}
