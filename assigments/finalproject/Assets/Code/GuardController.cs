using UnityEngine;

public class GuardController : MonoBehaviour
{
    public Transform player; 
    public float moveSpeed = 3f;
    public float detectionRange = 5f; 
    private bool isChasing = false;

    void Update()
    {

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            isChasing = true; 
        }
        else
        {
            isChasing = false;
        }
        if (isChasing)
        {
            MoveTowardsPlayer();
        }
    }
    void MoveTowardsPlayer()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        transform.position += directionToPlayer * moveSpeed * Time.deltaTime;
    }
}
