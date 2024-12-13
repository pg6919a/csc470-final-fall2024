using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float rotateSpeed = 90;
    public float moveSpeed = 8f;
    public float jumpVelocity = 8f;
    private float yVelocity = 0;
    private float gravity = -9.8f;
    private float dashAmount = 8f;
    private float dashVelocity = 0;
    private float friction = -2.8f;

    private float fallingTime = 0;
    private float coyoteTime = 0.5f;

    private UnityEngine.CharacterController cc;

    void Start()
    {
        cc = GetComponent<UnityEngine.CharacterController>();
    }

    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        transform.Rotate(0, rotateSpeed * hAxis * Time.deltaTime, 0);

        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            dashVelocity = dashAmount;
        }
        dashVelocity += friction * Time.deltaTime;
        dashVelocity = Mathf.Clamp(dashVelocity, 0, 10000);

        if (!cc.isGrounded) 
        {
            fallingTime += Time.deltaTime;
            if (fallingTime < coyoteTime && Input.GetKeyDown(KeyCode.Space)) {
                yVelocity = jumpVelocity;
            }

            if (yVelocity > 0 && Input.GetKeyUp(KeyCode.Space))
            {
                yVelocity = 0;
            }

            yVelocity += gravity * Time.deltaTime;
        }
        else
        {
            yVelocity = -2;
            fallingTime = 0;
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                yVelocity = jumpVelocity;
            }
        }

        Vector3 amountToMove = transform.forward * moveSpeed * vAxis;
        amountToMove += transform.forward * dashVelocity;
        amountToMove.y += yVelocity;
        amountToMove *= Time.deltaTime;
        cc.Move(amountToMove);
    }
}
