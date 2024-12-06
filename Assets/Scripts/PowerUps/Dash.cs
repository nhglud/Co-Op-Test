using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class Dash : Abilities
{
    public float dashVelocity;

    // �ger spillerens hastighed i en kort periode.
    public override void Activate(GameObject parent, bool synergy)
    {
        if (synergy == true)
        {
            // Fanger Player-scriptet for at kunne kontrollere hastighed.
            Player player = parent.GetComponent<Player>();

            // Synergi betyder dobbelt effekt af for�gelse.
            dashVelocity = dashVelocity * 2;

            // �ger spillerens hastighed.
            //player.BoostMovementSpeed(dashVelocity);

            // For�gelsen s�ttes tilbage, n�ste aktivering ikke "automatisk" er med synergi effekt.
            dashVelocity = dashVelocity * 0.5f;
        }
        else
        {
            Player player = parent.GetComponent<Player>();

            // �ger spillerens hastighed.
            //player.BoostMovementSpeed(dashVelocity);
        }
    }

    public override void BeginCooldown(GameObject parent)
    {
        Player player = parent.GetComponent<Player>();

        // S�tter spillerens hastighed tilbage til den normale v�rdi.
        //player.SetMovementSpeed(player.GetNormalMovementSpeed());
    }
}
