using UnityEngine;

public class VRShipMovement : MonoBehaviour
{
    public float moveSpeed = 5f;               // Speed of movement
    public float rotationSpeed = 50f;          // Speed of rotation
    public float bounceBackForce = 10f;        // Force to apply when bouncing back on collision
    public float angularDamping = 2f;          // Angular damping to slow down spinning after collision
    public float maxAngularVelocity = 2f;      // Maximum angular velocity to prevent excessive spin
    public int health = 100;                   // Health of the spaceship
    public Transform vrCamera;                 // Reference to the VR camera (for directional reference)

    private Rigidbody rb;

    private void Awake()
    {
        // Ensure the VR Camera is assigned
        if (vrCamera == null)
        {
            vrCamera = Camera.main?.transform;  // Assigns the Main Camera Transform if available
            if (vrCamera == null)
            {
                Debug.LogError("VR Camera is not assigned and no Main Camera found!");
            }
        }

        // Get or add Rigidbody component
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        rb.isKinematic = false;
        rb.useGravity = false;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.maxAngularVelocity = maxAngularVelocity; // Set max angular velocity to prevent excessive spin
    }

    private void Update()
    {
        // Get keyboard input for space-like movement (WASD for forward/backward/left/right, E/Q for up/down)
        float horizontal = Input.GetAxis("Horizontal");   // A/D or Left/Right arrows
        float vertical = Input.GetAxis("Vertical");       // W/S or Up/Down arrows
        float ascentDescent = 0f;

        if (Input.GetKey(KeyCode.E)) ascentDescent = 1f;  // Move up
        if (Input.GetKey(KeyCode.Q)) ascentDescent = -1f; // Move down

        // Calculate movement direction relative to the camera's orientation
        Vector3 direction = (vrCamera.forward * vertical + vrCamera.right * horizontal + vrCamera.up * ascentDescent).normalized;

        // Apply force to move in the calculated direction
        rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);

        // Handle rotation with mouse input
        float rotationX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime; // Horizontal rotation
        float rotationY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime; // Vertical rotation

        // Rotate based on mouse input
        transform.Rotate(vrCamera.up, rotationX, Space.World);           // Rotate around Y-axis (up/down)
        transform.Rotate(vrCamera.right, -rotationY, Space.World);       // Rotate around X-axis (left/right)

        // Apply angular damping to reduce spinning over time
        rb.angularVelocity *= (1 - angularDamping * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroid") || collision.gameObject.CompareTag("Planet"))
        {
            Debug.Log("Collided with " + collision.gameObject.name);

            // Reduce health
            health -= 10;
            Debug.Log("Health: " + health);

            // Apply bounce-back force
            Vector3 bounceDirection = -collision.contacts[0].normal;
            rb.AddForce(bounceDirection * bounceBackForce, ForceMode.Impulse);

            // Optional: Check if health is 0 or below and handle "game over" logic
            if (health <= 0)
            {
                Debug.Log("Game Over!");
                // Implement game over functionality here, e.g., disable controls, show Game Over screen, etc.
            }
        }
    }
}
