using UnityEngine;

public class SkateboardController : MonoBehaviour
{
    public float speed = 10f;  // Movement speed
    public float turnSpeed = 50f;  // Turning speed
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Get the Rigidbody component
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ; // Prevent tipping over
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Vertical");  // Forward/backward movement (W/S or ?/?)
        float turn = Input.GetAxis("Horizontal"); // Left/right movement (A/D or ?/?)

        // Apply forward/backward movement
        Vector3 movement = transform.forward * move * speed;
        rb.AddForce(movement, ForceMode.Acceleration);

        // Apply rotation
        rb.AddTorque(Vector3.up * turn * turnSpeed);
    }
}
