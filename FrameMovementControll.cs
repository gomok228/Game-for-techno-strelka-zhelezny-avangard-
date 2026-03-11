using UnityEngine;

public class FrameMovementControll : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody rb;
    private Vector3 movementInput;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movementInput = new Vector3(horizontal, 0.0f, vertical);
    }

    void FixedUpdate()
    {
       
        Vector3 newVelocity = movementInput * speed;
        newVelocity.y = rb.linearVelocity.y; 

        rb.linearVelocity = newVelocity;
    }
}
