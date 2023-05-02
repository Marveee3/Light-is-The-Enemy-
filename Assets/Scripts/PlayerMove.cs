using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float raycastDistance = 0.1f;
    private Rigidbody2D rb;
    private Animator anim;
    private float moveInput;
    private bool isGrounded;
    public bool isFacingRight = true;
    public Slider Dark;
    public bool InDark;
    [SerializeField]private bool lockLunge = false;




    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb.sleepMode = 0f;
    }

    private void Update()
    {
        Lunge();
    }

    private void FixedUpdate()
    {
        isGroundeds();
        Move();
        Jump();
        if (InDark == false && Dark.value > 0)
        {
            Dark.value--;
            print("BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB");
        }
        anim.SetFloat("vSpeed", rb.velocity.y);
        anim.SetFloat("yVelocity", rb.velocity.y);
    }

    private void Move()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        anim.SetFloat(("Run"), Mathf.Abs(moveInput));

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (moveInput > 0 && !isFacingRight) Flip();
        else if (moveInput < 0 && isFacingRight) Flip();
    }

    private void Jump()
    {   
        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Physics2D.IgnoreLayerCollision(6, 7, true);
            Invoke("IgnoreLayerOff", 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {   
            rb.velocity = new Vector2(rb.velocity.y, 0);
            rb.AddForce(Vector2.up * jumpForce);
            //rb.velocity = Vector2.up * jumpForce;
            isGrounded = false;
            anim.SetBool("Jump", !isGrounded);
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void isGroundeds()
    {
        Vector2 raycastOrigin = transform.position - transform.up * GetComponent<BoxCollider2D>().bounds.extents.y;
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, -transform.up, raycastDistance, groundLayer);

        if (hit.collider != null)
        {
            isGrounded = true;
            anim.SetBool("Jump", !isGrounded);
        }
        else
        {
            isGrounded = false;
        }
    }

    private void IgnoreLayerOff()
    {
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }

    [SerializeField]private int lungeImpulse = 4000;
    void Lunge()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && !lockLunge)
        {
            lockLunge = true;
            Invoke("LungeLock", 2f);
            
            rb.velocity = new Vector2(0, 0);
            if(!isFacingRight)
            {
                rb.AddForce(Vector2.left * lungeImpulse);
            }
            else
            {
                rb.AddForce(Vector2.right * lungeImpulse);
            }
        }   
    }

    
    private void LungeLock()
    {
        lockLunge = false;
    }

    private void OnTriggerEntry2D(Collision2D other)
    {
        if (other.collider.CompareTag("Box"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        InDark = false;
    }


}
