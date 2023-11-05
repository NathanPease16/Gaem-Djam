using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 60f;
    [SerializeField] private float uprightPower = 50f;

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
        rb.AddForce(Vector3.down * rb.mass, ForceMode.Force); // Apply gravity
        Upright();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) { rb.AddTorque(transform.right * 10, ForceMode.Impulse); Debug.Log("HAH"); }
    }

    Vector3 GetInput() {
        return (Vector3.ProjectOnPlane(viewer.forward, Vector3.down).normalized*Input.GetAxisRaw("Vertical") + viewer.right*Input.GetAxisRaw("Horizontal")).normalized;
    }

    void Upright() {
        Vector3 goal = Vector3.up;
        Vector3 current = transform.up;
        Vector3 axis = Vector3.Cross(goal, current);

        rb.AddTorque(axis * uprightPower, ForceMode.Force);
    }
}
