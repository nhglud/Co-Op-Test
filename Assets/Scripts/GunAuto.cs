using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAuto : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletspawn;
    public float fireRate; // bullet per second
    public float bulletspeed = 20; // speed of the bullet

    private float nextbullet; // tracking for the next shoot
<<<<<<< HEAD

    [SerializeField] GunAim gunAim;
=======
    public float weight;
    public float bulletdamage;

    public float Weight { get => weight; set => weight = value; }
    public float Bulletdamage { get => bulletdamage; set => bulletdamage = value; }

    [SerializeField] Player player1;

    [SerializeField] Enemy enemy;

>>>>>>> 0f7d2610526b61243cab23f4538d94dd2e4656d0

    // Start is called before the first frame update
    void Start()
    {
        
        UpdatePlayerMoveSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextbullet)
        {
            shoot();
            nextbullet = Time.time + 1 / fireRate;
        }

       
    }

   

    public void shoot()
    {
        //Instatiate a bullet at the bulletspawn
        GameObject bulletshot = Instantiate(bullet, bulletspawn.transform);

        Vector3 aimDir = gunAim.updateAimDirection();

        
        bulletspawn.transform.forward = gunAim.updateAimDirection();

        //Add velocity
        bulletshot.GetComponent<Rigidbody>().velocity = bulletspawn.transform.forward.normalized * bulletspeed;


        //Destroy bullet after few seconds
        //Destroy(bullet, 2)
    }

    private void UpdatePlayerMoveSpeed()
    {
        player1.setMovementSpeed(weight);
    }
}
