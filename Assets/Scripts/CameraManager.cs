using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform player1Transform;
    [SerializeField] private Transform player2Transform;
    [SerializeField] private LightSource lightSource;

    private Light light;
    private Vector3 playersMidPoint;
    private float distanceBetweenPlayers;
    private float cameraOffsetY = 8;
    private float cameraOffsetZ = 5;
    private float lerpModifier = 1.5f;
    private float distanceModifier = 1f;


    void Start()
    {
        light = lightSource.GetComponentInChildren<Light>();
        playersMidPoint = (player1Transform.position + player2Transform.position) / 2;
        transform.position = new Vector3(playersMidPoint.x, 
                                         distanceModifier * distanceBetweenPlayers + cameraOffsetY,
                                         playersMidPoint.z - cameraOffsetZ);

    }

    void Update()
    {
        playersMidPoint = (player1Transform.position + player2Transform.position) / 2;

        distanceBetweenPlayers = Vector3.Distance(player1Transform.position, player2Transform.position);

        transform.position = Vector3.Lerp(transform.position,
                                          new Vector3(playersMidPoint.x,
                                                      distanceModifier * distanceBetweenPlayers + cameraOffsetY,
                                                      playersMidPoint.z - cameraOffsetZ),
                                          Time.deltaTime * lerpModifier);
    }
}
