using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform Player;
    public Transform Player2;
    public Transform LightSource;

    // Enemy's field of view angle and vision range.
    public float FieldOfViewAngle = 360f;
    public float VisionRange = 70f;

    public float SpaceBetween = 1f;
    public float MoveSpeed = 5f;

    // Current target (player or light source)
    private Transform currentTarget;
    

    // Update is called once per frame
    void Update()
    {
        // Check if the enemy can see any of the players
        bool canSeePlayer1 = IsInFieldOfView(Player);
        bool canSeePlayer2 = IsInFieldOfView(Player2);

        if (canSeePlayer1 || canSeePlayer2)
        {
            // If any player is visible, set the current target to the closest visible player
            currentTarget = GetClosestTarget(
                canSeePlayer1 ? Player : null,
                canSeePlayer2 ? Player2 : null
            );
        }
        else if (currentTarget == null || !IsInFieldOfView(currentTarget))
        {
            // If no players are visible, switch the target to the light source
            currentTarget = LightSource;
        }

        // Move the enemy toward the current target
        MoveTowards(currentTarget);
    }

    bool IsInFieldOfView(Transform target)
    {
        if (target == null) return false;

        Vector3 directionToTarget = target.position - transform.position;
        float distanceToTarget = directionToTarget.magnitude;

        if (distanceToTarget <= VisionRange)
        {
            float angleToTarget = Vector3.Angle(transform.forward, directionToTarget);

            if (angleToTarget <= FieldOfViewAngle / 2f)
            {
                // Check for line of sight to the target
                RaycastHit hit;
                if (Physics.Raycast(transform.position, directionToTarget.normalized, out hit, VisionRange))
                {
                    return hit.transform == target;
                }
            }
        }
        return false;
    }

    Transform GetClosestTarget(Transform target1, Transform target2)
    {
        if (target1 == null) return target2;
        if (target2 == null) return target1;

        float distanceToTarget1 = Vector3.Distance(transform.position, target1.position);
        float distanceToTarget2 = Vector3.Distance(transform.position, target2.position);

        return distanceToTarget1 < distanceToTarget2 ? target1 : target2;
    }

    void MoveTowards(Transform target)
    {
        if (target == null) return;

        Vector3 direction = (target.position - transform.position).normalized;

        // Ensure the enemy looks in the movement direction
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * MoveSpeed);
        }

        // Move the enemy forward
        if (Vector3.Distance(transform.position, target.position) >= SpaceBetween)
        {
            transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Oh no i got shot!");
        }
    }
}