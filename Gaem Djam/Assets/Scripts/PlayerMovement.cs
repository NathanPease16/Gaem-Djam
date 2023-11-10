using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState = PlayerState.Idle;
    [SerializeField] private KeyCode wallRunKey = KeyCode.F;
    [SerializeField] private float moveSpeed = 60f;
    [SerializeField] private float jumpForce = 2400f;
    [SerializeField] private LayerMask groundCheckMask;

    private Transform viewer;
    private Rigidbody rb;
    private Collider feet;

    public enum PlayerState {Idle, Walking, Jumping, WallRunning }
    public ContactPoint floorContact;

    public Vector3 _up;

    void Awake()
    {
        viewer = transform.Find("Viewer");
        rb = GetComponent<Rigidbody>();
        feet = transform.Find("Feet").GetComponent<Collider>();

        _up = Vector3.up;
    }

    void FixedUpdate()
    {
        rb.AddForce(GetInput() * moveSpeed, ForceMode.Acceleration); // Apply forces based off wasd
        HandleGroundCheck();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {Jump();}
        if(Input.GetKeyDown(wallRunKey)) {WallRun();}
    }

    Vector3 GetInput() {
        return (Vector3.ProjectOnPlane(viewer.forward, _up).normalized*Input.GetAxisRaw("Vertical") + viewer.right*Input.GetAxisRaw("Horizontal")).normalized;
    }

    void HandleGroundCheck() {
        if(currentState != PlayerState.WallRunning) {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, Vector3.down, out hit, 1.501f, groundCheckMask)) {
                currentState = PlayerState.Walking;
            } else {
                currentState = PlayerState.Jumping;
            }
            Debug.Log(hit);
        }
    }

    void Jump() {
        if(currentState == PlayerState.Walking) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        } else if(currentState == PlayerState.WallRunning) {
            Debug.Log("aaa");
        }
    }

    void WallRun() {

    }
}
