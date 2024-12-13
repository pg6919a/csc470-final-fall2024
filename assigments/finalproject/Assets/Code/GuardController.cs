using UnityEngine;

public class GuardController : MonoBehaviour
{
    public Transform player; 
    public float moveSpeed = 3f;
    public float detectionRange = 5f; 
    private bool isChasing = false;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

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
        rb.MovePosition(transform.position + directionToPlayer * moveSpeed * Time.deltaTime);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            
            HealthManager healthManager = collision.gameObject.GetComponent<HealthManager>();
            if (healthManager != null)
            {
                healthManager.TakeDamage(); 
            }

            
            isChasing = false; 
        }
    }
}
