using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance { get; private set; }

    [SerializeField] GameObject weaponSelectionScene;


    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

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
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void StartGame ()
    {
        Time.timeScale = 1;
        if (weaponSelectionScene != null)
        {
            weaponSelectionScene.SetActive(false);
        }
        
        print("start Game");
    }



}
