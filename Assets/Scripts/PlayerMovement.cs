using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    [SerializeField] protected float speed = 12f;
    protected float gravity = -9.81f * 2;
    protected float jumpHeight = 3f;

    public float groundDistance = 0.4f;
    public Transform groundCheck;
    public LayerMask groundMask;
    public GameObject respawnPosition;

    Vector3 velocity;
    private Vector3 lastPosition = new Vector3(0, 0, 0);

    private bool canMove = true;
    bool isGrounded;
    bool isMoving;


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove) return;
        // Ground Check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //Reseting the default velocity
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Check if player is underground of death
        if (transform.position.y < -20)
        {
            controller.enabled = false;
            transform.position = respawnPosition.transform.position;
            controller.enabled = true;
        }

        //Creating the moving vector
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        if (lastPosition != transform.position && isGrounded)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        lastPosition = transform.position;

        //Check if the player can jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    
    public void ResetToDefault()
    {
        gravity = -9.81f * 2;
        jumpHeight = 3f;
        speed = 12f;
    }

    public void SetJumpHeight(float setHeight)
    {
        jumpHeight = setHeight;
    }

    public void SetSpeed(float setSpeed)
    {
        speed = setSpeed;
    }

    public void SetGravity(float setGravity)
    {
        gravity = setGravity;
    }

    public void SetCanmove(bool setCanmove)
    {
        canMove = setCanmove;
    }
    public bool GetCanMove()
    {
        return canMove;
    }
}