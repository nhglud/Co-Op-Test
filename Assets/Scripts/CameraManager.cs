using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform player1Transform;
    [SerializeField] private Transform player2Transform;
    [SerializeField] private LightSource lightSource;
    private Light light;
    private Vector3 playerMidPoint;
    private float distanceBetweenPlayers;


    void Start()
    {
        light = lightSource.GetComponentInChildren<Light>();
        playerMidPoint = (player1Transform.position + player2Transform.position) / 2;

    }

   
    void Update()
    {
        playerMidPoint = (player1Transform.position + player2Transform.position) / 2;

        distanceBetweenPlayers = Vector3.Distance(player1Transform.position, player2Transform.position);

        transform.position = Vector3.Lerp(transform.position,
                                                     new Vector3(playerMidPoint.x, 
                                                                 0.5f * distanceBetweenPlayers + 8,
                                                                 playerMidPoint.z - 5),
                                                     Time.deltaTime);
    }
}
