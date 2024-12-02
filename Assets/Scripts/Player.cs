using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int playerNumber = 1;
    [SerializeField] private GameInputs gameInputs;
    [SerializeField] private LightSource lightSource;

    private const float INTERACTION_RANGE = 1.5f;
    private float moveSpeed = 5.0f;
    private float rotationSpeed = 10.0f;
    private float moveDistance;
    private bool isWalking;
    private bool interactionKeyIsPressed;
    private bool isCarryingLight = false;
    private Vector3 lastMoveDir;
    private Vector2 inputVector;

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
        interactionKeyIsPressed = playerNumber == 1 ? gameInputs.GetPlayer1Interact() : gameInputs.GetPlayer2Interact();

        InteractWithObject();
    }

    private void InteractWithObject()
    {
        if (interactionKeyIsPressed && !isCarryingLight)
        {
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, INTERACTION_RANGE);

            foreach (var c in colliderArray)
            {
                if (c.TryGetComponent(out LightSource lightSource))
                {
                    this.lightSource = lightSource;
                    lightSource.PickUpLight(transform);
                    isCarryingLight = true;
                }
            }
        }

        else if (interactionKeyIsPressed && isCarryingLight)
        {
            lightSource.DropLight(transform);
            isCarryingLight = false;
            this.lightSource = null;
        }

        if(isCarryingLight)
        {
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, INTERACTION_RANGE);

            foreach (var c in colliderArray)
            {
                if (c.TryGetComponent(out PickUp pickUp))
                {
                    Debug.Log("PickUp Interact");
                    pickUp.pickUpInteraction();
                    lightSource.BoostLight();
                }
            }
        }

    }


    private bool InContact(Vector3 moveDir)
    {
        return !Physics.CapsuleCast(transform.position,
                                    transform.position + Vector3.up * collider.height,
                                    collider.radius,
                                    moveDir,
                                    moveDistance, -5, QueryTriggerInteraction.Ignore);
    }

    private void HandleMovement()
    {
        inputVector = playerNumber == 1 ? gameInputs.GetPlayer1MovementVectorNormalized() : gameInputs.GetPlayer2MovementVectorNormalized();

        var moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        moveDistance = moveSpeed * Time.deltaTime;


        // handle collision
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
