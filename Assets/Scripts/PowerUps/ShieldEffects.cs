using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEffects : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy") || other.CompareTag("enemyProjecttile"))
        {
            Destroy(other.gameObject);
        }
    }
}
