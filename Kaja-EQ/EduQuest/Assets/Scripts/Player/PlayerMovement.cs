using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls controls;

    float direction = 0;
    public float speed = 400;
    public bool isFacingRight = true;

    public float jumpForce = 5;
    bool isGrounded;
    int numberOfJumps = 0;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public Rigidbody2D playerRB;
    public Animator animator;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        controls.Land.Move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
            if (direction != 0)
            {
                AudioManager.instance.Play("Run");
            }
        };

        controls.Land.Move.canceled += ctx =>
        {
            direction = 0;
            AudioManager.instance.Stop("Run");  // Stop run sound when movement is canceled
        };

        controls.Land.Jump.performed += ctx => Jump();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);

        playerRB.linearVelocity = new Vector2(direction * speed * Time.fixedDeltaTime, playerRB.linearVelocity.y);
        animator.SetFloat("speed", Mathf.Abs(direction));

        if (isFacingRight && direction < 0 || !isFacingRight && direction > 0)
            Flip();

        if (direction == 0)
        {
            AudioManager.instance.Stop("Run");  // Stop run sound when not moving
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    void Jump()
    {
        if (isGrounded)
        {
            numberOfJumps = 0;
            playerRB.linearVelocity = new Vector2(playerRB.linearVelocity.x, jumpForce);
            numberOfJumps++;
            AudioManager.instance.Play("Jump");
            AudioManager.instance.Stop("Run");  // Stop run sound when jumping
        }
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
