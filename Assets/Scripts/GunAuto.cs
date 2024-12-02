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

    [SerializeField] GunAim gunAim;

    // Start is called before the first frame update
    void Start()
    {
        
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
}
