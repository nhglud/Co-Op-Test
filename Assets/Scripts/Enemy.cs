using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        // face the target
        transform.LookAt(target);


        //get the distance between the chaser and the target
        float distance = Vector3.Distance(transform.position, target.position);


        transform.position += transform.forward * 2 * Time.deltaTime;
    }
}
