using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynergyZone : MonoBehaviour
{
    private bool synergy = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            synergy = true;
            Debug.Log("Synergy achieved.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            synergy = false;
        }
    }

    public bool GetSynergy()
    {
        return synergy;
    }
}
