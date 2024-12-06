using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_2 : MonoBehaviour
{
    public Transform Player1;       // Første spiller
    public Transform Player2;       // Anden spiller
    public Transform LightSource;   // Lyskilde
    public float SpaceBetween = 1.5f; // Minimum afstand til spillerne
    public float DelayBetweenTargets = 2.0f; // Tid mellem målskift
    private Transform currentTarget;
    private Coroutine searchCoroutine;
    private float health = 10;
    [SerializeField] float speed;


    void Start()
    {

        health = Random.Range(4, 10);

        // Start coroutine for at søge efter mål
        searchCoroutine = StartCoroutine(SearchForTarget());
    }

    void Update()
    {
        if (currentTarget != null)
        {
            // Beregn retningen fra objektet til target
            Vector3 direction = (currentTarget.position - transform.position).normalized;

            // Få objektet til at kigge mod target
            transform.LookAt(currentTarget.position);

            // Flyt objektet i den beregnede retning
            transform.Translate(direction * Time.deltaTime * speed, Space.World);
        }
    }

    IEnumerator SearchForTarget()
    {
        while (true)
        {
            // Vælg mål baseret på synlighed
            currentTarget = CanSee(Player1) ? Player1 : (CanSee(Player2) ? Player2 : LightSource);

            // Vent før næste målskift
            yield return new WaitForSeconds(DelayBetweenTargets);
        }
    }

    public void SetDelayBetweenTargets(float newDelay)
    {
        DelayBetweenTargets = newDelay;

        // Genstart coroutinen for at bruge den nye delayværdi
        if (searchCoroutine != null)
        {
            StopCoroutine(searchCoroutine);
        }
        searchCoroutine = StartCoroutine(SearchForTarget());
    }

    bool CanSee(Transform target)
    {
        if (target == null) return true;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, target.position - transform.position, out hit))
        {
            return hit.transform == target;
        }
        return false;

    }
    private void OnTriggerEnter(Collider other)
    {


        // Tjekker om objektet, som enemy rammer, har tag'en "Player"
        if (other.CompareTag("Player") || other.CompareTag("LightSource"))
        {


            // Destruerer player-objektet


            Time.timeScale = 0;
            Destroy(other.gameObject);

        }


        else
        if (other.CompareTag(GunAuto.weapons.sniper.ToString()) ||
            other.CompareTag(GunAuto.weapons.pistol.ToString()) || 
            other.CompareTag(GunAuto.weapons.minigun.ToString()))
        {
            
            switch (other.tag)
            {
                //todo hvorfor virker det her ikke?
                //case GunAuto.weapons.sniper.ToString():
                //
                //    break;

                case "sniper":
                    TakeDamage(10);
                    break;

                case "pistol":
                    TakeDamage(5);
                    break;

                case "minigun":
                    TakeDamage(1);
                    break;


            }
            

        }

    }




    public void TakeDamage (int damage)
    {
        damage = Mathf.Abs(damage);

        health -= damage;


        if (health <1 )
        {
            Destroy(this.gameObject);
        }

    }

}
