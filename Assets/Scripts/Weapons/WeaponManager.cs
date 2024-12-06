using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    public static WeaponManager Instance { get; private set; }

    [SerializeField] GunAuto player1;
    [SerializeField] GunAuto player2;




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


    public void SetPlayerWeapon ()
    {
        player1.SetPistol();
    }

}
