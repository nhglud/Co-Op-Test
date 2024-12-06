using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform Player;
    public Transform Player2;
    public Transform LightSource;

    public float FieldOfViewAngle = 90f;
    public float VisionRange = 10f;
    public float SpaceBetween = 1f;
    public float MoveSpeed = 3f;

    public float TargetSwitchDelay = 2f; // Time in seconds to wait before switching target

    private Transform currentTarget;
    private Coroutine targetSwitchCoroutine;

    void Update()
    {
        bool canSeePlayer1 = IsInFieldOfView(Player);
        bool canSeePlayer2 = IsInFieldOfView(Player2);

        if (canSeePlayer1 || canSeePlayer2)
        {
            Transform closestTarget = GetClosestTarget(canSeePlayer1 ? Player : null, canSeePlayer2 ? Player2 : null);
            if (currentTarget != closestTarget)
            {
                if (targetSwitchCoroutine != null) StopCoroutine(targetSwitchCoroutine);
                targetSwitchCoroutine = StartCoroutine(SwitchTargetWithDelay(closestTarget));
            }
        }
        else
        {
            if (currentTarget == null || !IsInFieldOfView(currentTarget))
            {
                if (targetSwitchCoroutine == null)
                {
                    targetSwitchCoroutine = StartCoroutine(SwitchTargetWithDelay(LightSource));
                }
            }
        }

        MoveTowards(currentTarget);
    }

    IEnumerator SwitchTargetWithDelay(Transform newTarget)
    {
        yield return new WaitForSeconds(TargetSwitchDelay);
        currentTarget = newTarget;
        targetSwitchCoroutine = null; // Reset coroutine reference
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

        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * MoveSpeed);
        }

        if (Vector3.Distance(transform.position, target.position) >= SpaceBetween)
        {
            transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // Tjekker om objektet, som enemy rammer, har tag'en "Player" eller "LightSource"
        if (other.CompareTag("Player") || other.CompareTag("LightSource"))
        {
            // Find alle objekter med tagget "Player" eller "LightSource"
            GameObject[] allObjects = GameObject.FindGameObjectsWithTag(other.tag);

            GameObject closestObject = null;
            float closestDistance = Mathf.Infinity;

            // Loop igennem alle objekter og find den nærmeste
            foreach (GameObject obj in allObjects)
            {
                float distance = Vector3.Distance(transform.position, obj.transform.position);

                if (distance < closestDistance)
                {
                    closestObject = obj;
                    closestDistance = distance;
                }
            }

            // Destruer den nærmeste objekt
            if (closestObject != null)
            {
                Destroy(closestObject);
            }
        }
    }
}