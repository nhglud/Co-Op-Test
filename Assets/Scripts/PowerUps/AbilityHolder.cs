using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public Abilities ability;
    private float cooldownTime;
    private float activeTime;
    private bool synergy = false;
    SynergyZone synergyZone;

    private enum AbilityState
    {
        Ready,
        Active,
        Cooldown,
    }

    AbilityState state = AbilityState.Ready;

    public KeyCode key;

    private void Start()
    {
        synergyZone = gameObject.transform.GetChild(2).GetComponent<SynergyZone>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(synergy);

        // Kontrol af nuv�rende syngeri-status
        if (synergyZone.GetSynergy())
        {
            synergy = true;
        }
        else
        {
            synergy = false;
        }

        // Logik til hver AbilityState
        switch (state)
        {
            // Klar stadie, ability kan nu bruges
            case AbilityState.Ready:
                if (Input.GetKeyDown(key))
                {
                    ability.Activate(gameObject, synergy);
                    state = AbilityState.Active;
                    // Kontrol af synergi-status og p�virker aktiveringsperioden.
                    if (synergy == true)
                    {
                        activeTime = ability.activeTime * 2;
                        synergy = false;
                    }
                    else
                    {
                        activeTime = ability.activeTime;
                    }
                }
                break;
            // Igangv�rende stadie, effekt er pt. aktiv og g�r p� cooldown efterf�lgende.
            case AbilityState.Active:
                if (activeTime > 0)
                {
                    // Nedt�lling af aktiveringperioden
                    activeTime -= Time.deltaTime;
                    Debug.Log(activeTime);
                }
                else
                {
                    ability.BeginCooldown(gameObject);
                    state = AbilityState.Cooldown;
                    cooldownTime = ability.cooldownTime;
                }
                break;
            // Cooldown, ventetid indtil effekten igen kan bruges.
            case AbilityState.Cooldown:
                if (cooldownTime > 0)
                {
                    // Nedt�lling af cooldowns-perioden.
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.Ready;
                }
                break;
        }
    }
}
