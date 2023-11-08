using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState = PlayerState.Idle;
    [SerializeField] private float moveSpeed = 60f;
    [SerializeField] private float jumpForce = 2400f;

    private Transform viewer;
    private Rigidbody rb;
    private Collider feet;

    public enum PlayerState {Idle, Walking, Jumping, WallRunning }

    void Awake()
    {
        viewer = transform.Find("Viewer");
        rb = GetComponent<Rigidbody>();
        feet = transform.Find("Feet").GetComponent<Collider>();
    }

    void FixedUpdate()
    {
        rb.AddForce(GetInput() * moveSpeed, ForceMode.Acceleration); // Apply forces based off wasd
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {Jump();}
    }

    Vector3 GetInput() {
        return (Vector3.ProjectOnPlane(viewer.forward, Vector3.down).normalized*Input.GetAxisRaw("Vertical") + viewer.right*Input.GetAxisRaw("Horizontal")).normalized;
    }

    void Jump() {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
