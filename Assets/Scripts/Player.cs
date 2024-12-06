using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int playerNumber = 1;
    [SerializeField] private GameInputs gameInputs;
    [SerializeField] private LightSource lightSource;

    [SerializeField] private float health = 100;

    private float interactionRange = 1.5f;
    private float moveSpeed = 5.0f;
    private float rotationSpeed = 10.0f;
    private float moveDistance;
    private bool interactionKeyIsPressed;
    private bool isCarryingLight = false;
    private Vector3 lastMoveDir;
    private Vector2 inputVector;
    private bool inTriggerZone = false;

    private float timeToPermaDeath = 7;
    private float elapsedTime = 0;
    private bool isAlive = true;
    
    private CapsuleCollider collider;

<<<<<<< HEAD
    public bool InTriggerZone { get => inTriggerZone; set => inTriggerZone = value; }
    public int GetPlayerNumber { get => playerNumber; }


=======
>>>>>>> 58ef4691b04f28ae8bcc8392d59251bb94556aa3
    private void Awake()
    {
        collider = GetComponent<CapsuleCollider>();

        

    }

    private void Start()
    {
        WeaponManager.Instance.SetPlayer(playerNumber == 1 ? true : false, this.gameObject);
    }

    private void Update()
    {
        if (!inTriggerZone && health > 0)
        {
            HandleMovement();
            HandleInteraction();
            ColdDamage();
        }
        else
        {
            // If the players health reaches zero
            // we start a count down until permadeath 
            Debug.Log("Player is Down");
            elapsedTime += Time.deltaTime;
            if(elapsedTime > timeToPermaDeath)
            {
                isAlive = false;
                Debug.Log("Player is Dead");
            }
        }

    }

    private void ColdDamage()
    {
        // When the player is out of range of the light they start taking damage.
        float distanceToLight = Vector3.Distance(transform.position, lightSource.transform.position);
        if (distanceToLight > lightSource.getLightRadius() && health > 0)
        {
            health -= 0.5f;
        }
    }

    private void HandleInteraction()
    {
        interactionKeyIsPressed = playerNumber == 1 ? gameInputs.GetPlayer1Interact()
                                                    : gameInputs.GetPlayer2Interact();

        if (interactionKeyIsPressed && !isCarryingLight)
        {
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactionRange);

            foreach (var c in colliderArray)
            {
                // revive player
                if (c.TryGetComponent(out Player otherPlayer) && 
                    otherPlayer.isAlive && 
                    otherPlayer.health <= 0)
                {
                    otherPlayer.health = 100;
                    Debug.Log("Player was revived");
                }

                // pick up light
                else if (c.TryGetComponent(out LightSource lightSource))
                {
                    Debug.Log(lightSource);
                    lightSource.PickUpLight(transform);
                    isCarryingLight = true;
                }

            }
        }

        // VERY IMPORTANT ELSE IF--- DO NOT DELETE ELSE
        else if (interactionKeyIsPressed && isCarryingLight)
        {
            // drop light
            lightSource.DropLight(transform);
            isCarryingLight = false;
        }

        if (isCarryingLight)
        {
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactionRange);

            foreach (var c in colliderArray)
            {
                // pick up light booster
                if (c.TryGetComponent(out PickUp pickUp))
                {
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
                                    moveDistance,
                                    -5,
                                    QueryTriggerInteraction.Ignore);
    }

    private void HandleMovement()
    {
        inputVector = playerNumber == 1 ? gameInputs.GetPlayer1MovementVectorNormalized()
                                        : gameInputs.GetPlayer2MovementVectorNormalized();

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


        if (moveDir != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, moveDir, rotationSpeed * Time.deltaTime);
        }
    }

    public void setMovementSpeed(float newMoveSpeed)
    {
        moveSpeed = newMoveSpeed * moveSpeed;
    }

}
