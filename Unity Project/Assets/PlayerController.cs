using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float runSpeed = 10f;
    [SerializeField]
    private float normalSpeed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;
    public Rigidbody rb;
    private PlayerMotor motor;
    public bool playerIsOnTheGround = true;

    void Start ()
    {
        motor = GetComponent<PlayerMotor>();
        rb = GetComponent<Rigidbody>();
    }


    void Update ()
    {
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMove = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _zMove;

        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        motor.Move(_velocity);

        float _yRot = Input.GetAxisRaw("Mouse X");


        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

        motor.Rotate(_rotation);

        float _xRot = Input.GetAxisRaw("Mouse Y");


        float _cameraRotationX = _xRot * lookSensitivity;

        motor.RotateCamera(_cameraRotationX);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = normalSpeed;
            }
        }
        


        if (Input.GetButtonDown("Jump") && playerIsOnTheGround == true)
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            playerIsOnTheGround = false;
            

        }
        
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            playerIsOnTheGround = true;
        }
    }
}
