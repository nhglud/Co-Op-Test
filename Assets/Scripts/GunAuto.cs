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

    public float weight;
    public float bulletdamage;

    public float Weight { get => weight; set => weight = value; }
    public float Bulletdamage { get => bulletdamage; set => bulletdamage = value; }

    [SerializeField] Player player1;

    public enum weapons {sniper, pistol, minigun};
    [SerializeField] weapons selectStartWeapon;



    // Start is called before the first frame update
    void Start()
    {
        setWeapon(selectStartWeapon);
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



    public void setWeapon (weapons weapon )
    {
        switch (weapon)
        {
            case weapons.sniper:
                SetSniper();
                break;

            case weapons.pistol:
                SetPistol();
                break;

            case weapons.minigun:
                SetMinigun();
                break;

        }
    }


    public void SetSniper ()
    {
        fireRate = 0.5f;
        bulletspeed = 20; // speed of the bullet
        weight = 4;
        bulletdamage = 10;
    }

    public void SetPistol()
    {
        fireRate = 2;
        bulletspeed = 20; // speed of the bullet
        weight = 2;
        bulletdamage = 1;
    }

    public void SetMinigun()
    {
        fireRate = 6;
        bulletspeed = 20; // speed of the bullet
        weight = 6;
        bulletdamage = 5;
    }




    public void shoot()
    {
        //Instatiate a bullet at the bulletspawn
        GameObject bulletshot = Instantiate(bullet, bulletspawn.transform);

        Vector3 aimDir = gunAim.updateAimDirection();

        if (aimDir.x > 0 || aimDir.y > 0 || aimDir.z > 0)
        {
            bulletspawn.transform.forward = aimDir;
        }
        

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
