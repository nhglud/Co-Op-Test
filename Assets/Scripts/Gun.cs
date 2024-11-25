using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{


    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bulletSpawn;
    [SerializeField] Transform playerLocation;
    float counter = 0;

    // Start is called before the first frame update
    void Start()
    {
       
    }


    private void shoot ()
    {
        GameObject bulletShot = Instantiate(bullet, bulletSpawn.transform);
        bulletShot.GetComponent<Rigidbody>().velocity = bulletSpawn.transform.forward.normalized *100;
        bulletShot.gameObject.transform.parent = null;


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
    }
}
