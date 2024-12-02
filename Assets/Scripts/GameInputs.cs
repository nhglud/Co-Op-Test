using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputs : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player1.Enable();
        playerInputActions.Player2.Enable();
    }

    public bool GetPlayer1Interact()
    {
        return playerInputActions.Player1.Interact.triggered;
    }

    public bool GetPlayer2Interact()
    {
        return playerInputActions.Player2.Interact.triggered;
    }


    public Vector2 GetPlayer1MovementVectorNormalized()
    {
        return playerInputActions.Player1.Move.ReadValue<Vector2>().normalized;
    }


    public Vector2 GetPlayer2MovementVectorNormalized()
    {
        return playerInputActions.Player2.Move.ReadValue<Vector2>().normalized;
    }


}
