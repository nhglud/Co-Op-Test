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
    private List<string> code = new List<string>();
    int lengthOfCode;
    int codeChoice;
    bool minigameActive;
    [SerializeField] Slider timer;
    [SerializeField] TextMeshProUGUI timerValue;
    [SerializeField] int time = 10;
    [SerializeField] GameObject minigameArea;
    [SerializeField] GameObject minigame;

    private void Start()
    {
        timer.maxValue = time;
        lengthOfCode = UnityEngine.Random.Range(5, 8);
        for (int i = 0; i < lengthOfCode; i++)
        {
            codeChoice = UnityEngine.Random.Range(0, 4);
            code.Add(player1Movement[codeChoice]);
            Debug.Log(code[i]);
        }
        for (int i = 0; i < lengthOfCode; i++)
        {
            codeChoice = UnityEngine.Random.Range(0, 4);
            code.Add(player2Movement[codeChoice]);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Player player = other.GetComponent<Player>();

            // Fjerne kontrols fra karakteren, så spillerens input kan bruges til minigame input.
            //player.MovementDisabled();

            //lengthOfCode = UnityEngine.Random.Range(5, 8);

            //switch (player.GetPlayerID())
            //{
            //    case 1:
            //        // Kode for at Player 1 spiller
            //        break;
            //    case 2:
            //        // Kode for at Player 2 spiller
            //        break;
            //}
        }

        for (int i = 0; i < lengthOfCode; i++)
        {
            minigame.transform.GetChild(i).gameObject.SetActive(true);
        }

        MinigameActivate();
    }

    private void Update()
    {
        if (timer.value == 0)
        {
            // GameOver
            minigame.transform.GetChild(0).gameObject.SetActive(false);
            minigame.transform.GetChild(1).gameObject.SetActive(false);
            minigame.transform.GetChild(2).gameObject.SetActive(false);
            minigame.transform.GetChild(3).gameObject.SetActive(false);
            minigame.transform.GetChild(4).gameObject.SetActive(false);
            minigame.transform.GetChild(5).gameObject.SetActive(false);
            minigame.transform.GetChild(6).gameObject.SetActive(false);
            minigameArea.SetActive(false);
            minigameActive = false;
            timer.value = time;
            code.Clear();
            Destroy(gameObject);
        }
        else if (minigameActive)
        {
            // Game running
            timer.value -= Time.deltaTime;
            timerValue.SetText(timer.value.ToString().Substring(0, 4));
        }
    }

    void MinigameActivate()
    {
        minigameActive = true;
        minigameArea.SetActive(true);
    }
}
