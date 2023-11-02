using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _speed;

    [Header("Camera Rotation")]
    [SerializeField] private float _sensitivity;
    private float _xRotation;
    private float _yRotation;

    // References
    private Rigidbody _rb;
    private Transform _camera;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _camera = Camera.main.transform;
    }

    void Update()
    {
        Move();
        MoveCamera();
    }

    private void Move()
    {
        
    }

    private void MoveCamera()
    {
        _xRotation += Input.GetAxisRaw("Mouse X") * _sensitivity;
        _yRotation -= Input.GetAxisRaw("Mouse Y") * _sensitivity;

        transform.rotation = Quaternion.Euler(0f, _xRotation, 0f);
        _camera.localRotation = Quaternion.Euler(_yRotation, 0f, 0f);
    }
}
