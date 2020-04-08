using UnityEngine;

   [RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private float cameraRotationX = 0f;
    private float curruntCameraRotationX = 0f;

    [SerializeField]
    private float cameraRotationLimit = 85f;
    

    private Rigidbody rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move (Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void RotateCamera(float _cameraRotationX)
    {
        cameraRotationX = _cameraRotationX;
    }

    void FixedUpdate ()
    {
        PerformMovement();
        PerformRotation();
    }

    void PerformMovement ()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    void PerformRotation ()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler (rotation));
        if (cam != null)
        {
            curruntCameraRotationX -= cameraRotationX;
            curruntCameraRotationX = Mathf.Clamp(curruntCameraRotationX, -cameraRotationLimit, cameraRotationLimit);
            cam.transform.localEulerAngles = new Vector3(curruntCameraRotationX, 0f, 0f);
        }
    }
}
