using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameInputs gameInputs;
    [SerializeField] private int playerNum = 1;

    private float moveSpeed = 5.0f;
    private float rotationSpeed = 5.0f;
    private float moveDistance;
    private bool isWalking;
    private bool isPressed;
    private Vector3 lastMoveDir;
    Vector2 inputVector;

    private CapsuleCollider collider;

    public bool IsWalking { get => isWalking; }


    private void Awake()
    {
        collider = GetComponent<CapsuleCollider>();
       
    }

    private void Update()
    {
        HandleMovement();
        HandleInteraction();
    }



    private void HandleInteraction()
    {
        if (playerNum == 1)
        {
            isPressed = gameInputs.GetPlayer1Interact();
            

        }
        else
        {
            isPressed = gameInputs.GetPlayer2Interact();

        }

        if(isPressed)
        {
            Debug.Log("preseed");
        }

        //Physics.CapsuleCast(out RaycastHit racasthit);


    }

    private bool InContact(Vector3 moveDir)
    {
        return !Physics.CapsuleCast(transform.position,
                                    transform.position + Vector3.up * collider.height,
                                    collider.radius,
                                    moveDir,
                                    moveDistance);
    }

    private void HandleMovement()
    {


        if (playerNum == 1)
        {
            inputVector = gameInputs.GetPlayer1MovementVectorNormalized();

        }
        else
        {
            inputVector = gameInputs.GetPlayer2MovementVectorNormalized();

        }


        var moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        moveDistance = moveSpeed * Time.deltaTime;


        bool canMove = InContact(moveDir);

        if (!canMove)
        {
            var moveDirX = new Vector3(moveDir.x, 0, 0);

            if (InContact(moveDirX))
            {
                moveDir = moveDirX.normalized;
                transform.position += moveDistance * moveDir;
            }
            else
            {
                var moveDirZ = new Vector3(0, 0, moveDir.z);

                if (InContact(moveDirZ))
                {
                    moveDir = moveDirZ.normalized;
                    transform.position += moveDistance * moveDir;
                }
            }
        }
        else
        {
            transform.position += moveDistance * moveDir;
        }

        isWalking = moveDir != Vector3.zero;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, rotationSpeed * Time.deltaTime);
    }

}
