using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayerSelection : MonoBehaviour
{

    [SerializeField] UnityEngine.UI.Button sniper;
    [SerializeField] UnityEngine.UI.Button pistol;
    [SerializeField] UnityEngine.UI.Button minigun;

    [SerializeField] bool isPlayer1;

    [SerializeField] WeaponManager wm;

    private GunAuto.weapons currentWeapon;

    // Start is called before the first frame update
    void Start()
    {
   

    }

    // Update is called once per frame
    void Update()
    {
        
        if (isPlayer1)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                print(currentWeapon);
            }   
        }

        else
            if (Input.GetButtonDown("Fire2"))
        {
            print(currentWeapon);
        }



    }




     
    public void PistolPressed ()
    {
        WeaponManager.Instance.setWeapon(isPlayer1, GunAuto.weapons.pistol);

        wm.setWeapon(isPlayer1, GunAuto.weapons.sniper);
    }

    public void SniperPressed()
    {
        wm.setWeapon(isPlayer1, GunAuto.weapons.pistol);
    }
    public void MinigunPressed()
    {
        wm.setWeapon(isPlayer1, GunAuto.weapons.minigun);
    }

}
