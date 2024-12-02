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
        ResetLight();
    }

    public float getLightRange()
    {
        return light.range;
    }

    public void ResetLight()
    {
        light.intensity = initialIntensity;
        light.range = initialIntensity;
    }

    public void BoostLight()
    {
        float boost = 10;
        light.intensity += boost;
        light.range += boost;
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
