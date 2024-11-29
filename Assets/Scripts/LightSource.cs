using UnityEngine;

public class LightSource : MonoBehaviour
{

    [SerializeField] private Light light;


    private float lightDimmingRate = 0.13f;
   
    BoxCollider boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
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
