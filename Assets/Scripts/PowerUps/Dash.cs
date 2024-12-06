using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class Dash : Abilities
{
    public float dashVelocity;

    // Øger spillerens hastighed i en kort periode.
    public override void Activate(GameObject parent, bool synergy)
    {
        if (synergy == true)
        {
            // Fanger Player-scriptet for at kunne kontrollere hastighed.
            Player player = parent.GetComponent<Player>();

            // Synergi betyder dobbelt effekt af forøgelse.
            dashVelocity = dashVelocity * 2;

            // Øger spillerens hastighed.
            //player.BoostMovementSpeed(dashVelocity);

            // Forøgelsen sættes tilbage, næste aktivering ikke "automatisk" er med synergi effekt.
            dashVelocity = dashVelocity * 0.5f;
        }
        else
        {
            Player player = parent.GetComponent<Player>();

            // Øger spillerens hastighed.
            //player.BoostMovementSpeed(dashVelocity);
        }
    }

    public override void BeginCooldown(GameObject parent)
    {
        Player player = parent.GetComponent<Player>();

        // Sætter spillerens hastighed tilbage til den normale værdi.
        //player.SetMovementSpeed(player.GetNormalMovementSpeed());
    }
}
