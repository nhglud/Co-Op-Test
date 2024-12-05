using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayerSelection : MonoBehaviour
{



    public enum weapons {sniper, pistol, minigun};

    [SerializeField] UnityEngine.UI.Button sniper;
    [SerializeField] UnityEngine.UI.Button pistol;
    [SerializeField] UnityEngine.UI.Button minigun;

    [SerializeField] bool isPlayer1;

    private weapons currentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        sniper.onClick.AddListener(delegate { SelectWeapon(weapons.sniper); });
        pistol.onClick.AddListener(delegate { SelectWeapon(weapons.pistol); });
        minigun.onClick.AddListener(delegate { SelectWeapon(weapons.minigun); });

        pistol.Select();

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

    public void SelectWeapon (weapons input) 
    {
        currentWeapon = input;
        print(currentWeapon);

    }


    
    
    


}
