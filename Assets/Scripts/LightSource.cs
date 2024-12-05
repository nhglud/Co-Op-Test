using UnityEngine;
using UnityEngine.Rendering;

public class LightSource : MonoBehaviour
{

    [SerializeField] private Light light;
    private const float initialIntensity = 15;
    private const float initialRange = 15;

    private float lightDimmingRate = 1f;
   
    private BoxCollider boxCollider;
    private Transform lightSphere;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        lightSphere = transform.Find("Sphere");
        ResetLight();
        lightSphere.localScale = light.range * new Vector3(1, 0.5f, 1);

    }

    public float getLightRadius()
    {
        return lightSphere.localScale.x * 0.5f;
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
        lightSphere.localScale = light.range * new Vector3(1, 0.5f, 1);        
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
