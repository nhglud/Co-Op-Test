using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TriggerZone : MonoBehaviour
{
    private List<string> player1Movement = new List<string>() { "W", "A", "S", "D"};
    private List<string> player2Movement = new List<string>() { "UPARROW", "LEFTARROW", "DOWNARROW", "RIGHTARROW"};
    private List<string> codePlayer1 = new List<string>();
    private List<string> codePlayer2 = new List<string>();
    int lengthOfCode;
    int codeChoice;
    int playerID;
    bool minigameActive;
    string playerInput;
    [SerializeField] Slider timer;
    [SerializeField] TextMeshProUGUI timerValue;
    [SerializeField] int time = 10;
    [SerializeField] GameObject minigameArea;
    [SerializeField] GameObject minigame;
    public List<GameObject> player1Buttons = new List<GameObject>();
    public List<GameObject> player2Buttons = new List<GameObject>();

    private void Start()
    {
        minigameArea.SetActive(false);

        timer.maxValue = time;
        lengthOfCode = UnityEngine.Random.Range(5, 8);

        for (int i = 0; i < lengthOfCode; i++)
        {
            codeChoice = UnityEngine.Random.Range(0, 4);
            codePlayer1.Add(player1Movement[codeChoice]);
            switch (codePlayer1[i])
            {
                case "W":
                    Instantiate(player1Buttons[1]).transform.SetParent(minigame.transform);
                    break;
                case "A":
                    Instantiate(player1Buttons[2]).transform.SetParent(minigame.transform);
                    break;
                case "S":
                    Instantiate(player1Buttons[3]).transform.SetParent(minigame.transform);
                    break;
                case "D":
                    Instantiate(player1Buttons[4]).transform.SetParent(minigame.transform);
                    break;
            }
            Debug.Log(codePlayer1[i]);
        }
        for (int i = 0; i < lengthOfCode; i++)
        {
            codeChoice = UnityEngine.Random.Range(0, 4);
            codePlayer2.Add(player2Movement[codeChoice]);
            //switch (codePlayer2[i])
            //{
            //    case "W":
            //        Instantiate(player2Buttons[1]).transform.SetParent(minigame.transform);
            //        break;            
            //    case "A":             
            //        Instantiate(player2Buttons[2]).transform.SetParent(minigame.transform);
            //        break;            
            //    case "S":             
            //        Instantiate(player2Buttons[3]).transform.SetParent(minigame.transform);
            //        break;            
            //    case "D":             
            //        Instantiate(player2Buttons[4]).transform.SetParent(minigame.transform);
            //        break;
            //}
            Debug.Log(codePlayer2[i]);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();

            // Fjerne kontrols fra karakteren, så spillerens input kan bruges til minigame input.
            player.InTriggerZone = true;

            playerID = player.GetPlayerNumber;
        }

        MinigameActivate();
    }

    private void Update()
    {
        if (timer.value == 0)
        {
            // GameOver
            MinigameOver();
        }
        else if (minigameActive)
        {
            // Game running
            timer.value -= Time.deltaTime;
            timerValue.SetText(timer.value.ToString().Substring(0, 4));
            //PlayerGuess(playerID);
        }
    }

    void MinigameActivate()
    {
        minigameActive = true;
        minigameArea.SetActive(true);
    }
    void MinigameOver()
    {
        minigameActive = false;
        minigameArea.SetActive(false);
        timer.value = time;
        codePlayer1.Clear();
    }
    //void PlayerGuess(int ID)
    //{
    //    foreach (string codePart in code)
    //    {
    //        if (playerID == 1 && Input.GetKeyDown(KeyCode.W) || playerID == 2 && Input.GetKeyDown(KeyCode.UpArrow))
    //        {
    //            switch (playerID)
    //            {
    //                case 1:
    //                    playerInput = "W";
    //                    break;
    //                case 2:
    //                    playerInput = "UPARROW";
    //                    break;
    //            }
    //        }
    //        else if (playerID == 1 && Input.GetKeyDown(KeyCode.A) || playerID == 2 && Input.GetKeyDown(KeyCode.LeftArrow))
    //        {
    //            switch (playerID)
    //            {
    //                case 1:
    //                    playerInput = "A";
    //                    break;
    //                case 2:
    //                    playerInput = "LEFTARROW";
    //                    break;
    //            }
    //        }
    //        else if (playerID == 1 && Input.GetKeyDown(KeyCode.S) || playerID == 2 && Input.GetKeyDown(KeyCode.DownArrow))
    //        {
    //            switch (playerID)
    //            {
    //                case 1:
    //                    playerInput = "S";
    //                    break;
    //                case 2:
    //                    playerInput = "DOWNARROW";
    //                    break;
    //            }
    //        }
    //        else if (playerID == 1 && Input.GetKeyDown(KeyCode.D) || playerID == 2 && Input.GetKeyDown(KeyCode.RightArrow))
    //        {
    //            switch (playerID)
    //            {
    //                case 1:
    //                    playerInput = "D";
    //                    break;
    //                case 2:
    //                    playerInput = "RIGHTARROW";
    //                    break;
    //            }
    //        }

    //        if (playerInput == codePart)
    //        {
    //            Debug.Log("Correct guess.");
    //        }
    //    }
    //}
}
