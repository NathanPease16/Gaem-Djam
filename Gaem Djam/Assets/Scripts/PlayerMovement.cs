using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 60f;

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
        Vector3 goal = (Vector3.down).normalized;
        Vector3 current = transform.up;
        Vector3 axis = Vector3.Cross(goal, current);

        Debug.Log(axis);
        rb.AddTorque(axis*50, ForceMode.Force);
    }
}
