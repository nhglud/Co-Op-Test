using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{


    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bulletSpawn;
    [SerializeField] Transform playerLocation;

    //[SerializeField] float damage;
    //[SerializeField] float weight;
    //[SerializeField] float reloading;

    public int currentAmmo;
    private int maxAmmo = 1;
    [SerializeField] float reloading;
    public bool currentlyReloading = false;

    float counter = 0;

    
    public void Reload()
    {

    }
    
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
    }


    private void shoot ()
    {
        currentAmmo--;

        GameObject bulletShot = Instantiate(bullet, bulletSpawn.transform);
        bulletShot.GetComponent<Rigidbody>().velocity = bulletSpawn.transform.forward.normalized*100;
        bulletShot.gameObject.transform.parent = null;


    }


    IEnumerator reload()
    {
        currentlyReloading = true;
        yield return new WaitForSeconds(reloading);
        currentAmmo = maxAmmo;
        currentlyReloading = false;
    }




    // Update is called once per frame
    void Update()
    {
       
        counter += 1 * Time.deltaTime;
        if (counter > 1)
        {
            shoot();
            counter = 0;

        }
        if (currentAmmo < 1) StartCoroutine(reload());

    }
}
