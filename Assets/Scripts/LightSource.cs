using UnityEngine;

public class LightSource : MonoBehaviour
{
    BoxCollider boxCollider;

    public void Interact(Transform playerTransform)
    {
        transform.SetParent(playerTransform);

        boxCollider = GetComponent<BoxCollider>();
        boxCollider.enabled = false;

    }


    public void DropLight(Transform playerTransform)
    {
        transform.SetParent(null);
        boxCollider.enabled = true;

    }


}
