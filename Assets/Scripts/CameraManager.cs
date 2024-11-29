using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform player1Transform;
    [SerializeField] private Transform player2Transform;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LightSource lightSource;
    private Light light;


    // Start is called before the first frame update
    void Start()
    {
        light = lightSource.GetComponentInChildren<Light>();
        transform.position = (player1Transform.position + player2Transform.position) / 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (player1Transform.position + player2Transform.position) / 2;
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position,
                                                     new Vector3(transform.position.x, 1.5f * light.intensity, transform.position.z - 0.9f *light.intensity),
                                                     Time.deltaTime);
    }
}
