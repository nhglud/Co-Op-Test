using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtScript : MonoBehaviour
{



    [SerializeField] SceneManager scenemanager;

    private void Awake()
    {
        
    }

    public void StartGamePushed ()
    {
        scenemanager.StartGame();
    }

}
