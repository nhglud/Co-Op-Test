using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

[CreateAssetMenu]
public class Shield : Abilities
{
    // Omringer spilleren med et skjold af ild, som bloker projektiler og skader fjender.
    public override void Activate(GameObject parent, bool synergy)
    {
        if (synergy == true)
        {
            // Mulighed for at ændre på effekter - IKKE i bruge på nuværende tidspunkt.
            parent.transform.GetChild(1).gameObject.GetComponent<ShieldEffects>();

            // Aktiver skjoldet
            parent.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            // Aktiver skjoldet
            parent.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public override void BeginCooldown(GameObject parent)
    {
        // Deaktiver skjoldet
        parent.transform.GetChild(1).gameObject.SetActive(false);
    }
}
