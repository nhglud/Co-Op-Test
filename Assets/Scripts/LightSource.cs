using UnityEngine;

public class LightSource : MonoBehaviour
{

    [SerializeField] private Light light;
    private const float initialIntensity = 30;
    private const float initialRange = 30;

    private float lightDimmingRate = 2f;
   
    BoxCollider boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    public void ResetLight()
    {
        light.intensity = initialIntensity;
        light.range = initialIntensity;
    }

    public void BoostLight()
    {
        light.intensity += 50;
        light.range += 50;
    }


    private void Update()
    {
        DimLight();
    }

    private void DimLight()
    {
        light.intensity -= lightDimmingRate * Time.deltaTime;
        light.range -= lightDimmingRate * Time.deltaTime;
    }



    public void PickUpLight(Transform playerTransform)
    {
        transform.SetParent(playerTransform);
        boxCollider.enabled = false;
    }


    public void DropLight(Transform playerTransform)
    {
        transform.SetParent(null);
        boxCollider.enabled = true;
    }


}
