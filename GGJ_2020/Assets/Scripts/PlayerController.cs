using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Player Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float jumpHeight;
    private float currentMoveSpeed;
    public static CharacterController playerController;

    [Header("Camera Settings")]
    [SerializeField] private float cameraSensitivity;
    [SerializeField] private Transform camera;
    private float yCameraDirection;

    [Header("General")]
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float circleRadius;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, circleRadius, groundLayer);

        CameraRotation();
        PlayerMovement();
        Gravity();
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;

        yCameraDirection -= mouseY;
        yCameraDirection = Mathf.Clamp(yCameraDirection, -70f, 70f);

        camera.transform.localRotation = Quaternion.Euler(yCameraDirection, 0f, 0f);
        this.transform.Rotate(Vector3.up * mouseX);
    }

    private void PlayerMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentMoveSpeed = sprintSpeed;
        }
        else
        {
            currentMoveSpeed = moveSpeed;
        }

        Vector3 move = transform.right * x + transform.forward * z;

        playerController.Move(move * currentMoveSpeed * Time.deltaTime);
    }

    private void Gravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, circleRadius, groundLayer);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        playerController.Move(velocity * Time.deltaTime);
    }
}
