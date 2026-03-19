using UnityEngine;

public class Froggy : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Bullets ball;
    private bool isRight;
    private bool isGrounded;
    private bool isDoubleJump;

    private void Update()
    {
        CheckAttack();
        CheckGround();
        Move();
        Jump();
    }

    private void CheckAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var b = Instantiate(ball, transform.position, Quaternion.identity);
            b.SetDirection(isRight);
        }
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,
            groundCheckRadius, groundLayer);
        if (isGrounded)
        {
            animator.SetBool("Jump", false);
            isDoubleJump = false;
        }
        else
        {
            animator.SetBool("Jump", true);
        }
    }

    private void Move()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        animator.SetBool("Run", moveInput != 0);
        if (moveInput != 0)
        {
            spriteRenderer.flipX = moveInput < 0;
        }
        if (spriteRenderer.flipX == true) { isRight = false; } else { isRight = true; }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                animator.SetBool("Jump", true);
            }
            else if (!isDoubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                animator.SetTrigger("DoubleJump");
                isDoubleJump = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
