using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    public static WeaponManager Instance { get; private set; }

    private GameObject player1;
    private GameObject player2; 
    
    private GunAuto gunAutoplayer1;
    private GunAuto gunAutoplayer2;




    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void setWeapon(bool isPlayerOne, GunAuto.weapons weapon)
    {
        if (isPlayerOne)
        {
            gunAutoplayer1.setWeapon(weapon);
        }

        else
        {
            gunAutoplayer1.setWeapon(weapon);
        }

    }

    public void SetPlayer (bool isPlayerOne, GameObject player)
    {
        if (isPlayerOne) 
        {
            gunAutoplayer1 = player.GetComponent<GunAuto>();
        }
    }

}
