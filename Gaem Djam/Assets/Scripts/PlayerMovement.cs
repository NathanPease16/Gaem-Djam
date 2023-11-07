using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 60f;
    [SerializeField] private float jumpForce = 2400f;

    private Transform viewer;
    private Rigidbody rb;

    void Awake()
    {
        viewer = transform.Find("Viewer");
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(GetInput() * moveSpeed, ForceMode.Acceleration); // Apply forces based off wasd
        
    }

    void Update()
    {
        Jump();
    }

    Vector3 GetInput() {
        return (Vector3.ProjectOnPlane(viewer.forward, Vector3.down).normalized*Input.GetAxisRaw("Vertical") + viewer.right*Input.GetAxisRaw("Horizontal")).normalized;
    }

    void Jump() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
