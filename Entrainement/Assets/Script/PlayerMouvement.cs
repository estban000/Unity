using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public float moveDirectionX = 0;
    public float moveSpeed = 10;
    public float jumpForce = 8;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public bool isGrounded = false;
    public LayerMask listGroundLayers;
    public int maxAllowedJumps = 2;
    public int currentNumberJumps = 0;
    public bool isFacingRight = false;
    public VoidEventchannel onPlayerDeath;
    private void OEnable()
    {
        onPlayerDeath.OnEventRaised += Die;
    }
    private void Oisable()
    {
        onPlayerDeath.OnEventRaised -= Die;      
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    void Die(){
        bc.enabled = false;
        rb.bodyType = RigidbodyType2D.Static; 
        enabled = false;
    }
    void Flip(){
        if((moveDirectionX > 0 && !isFacingRight) || (moveDirectionX < 0 && isFacingRight)){
            transform.Rotate(0, 180, 0);
            isFacingRight = !isFacingRight;
        }
    }
    private void Jump()
    {
        rb.linearVelocity = new Vector2(
            rb.linearVelocity.x,
            jumpForce
        );
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(
            moveDirectionX * moveSpeed,
            rb.linearVelocity.y
        );
        isGrounded = IsGrounded();
    }
    public bool IsGrounded(){
        return Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            listGroundLayers
        );
    }
    private void OnDrawGizmos(){
        if (groundCheck != null){
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(
                groundCheck.position,
                groundCheckRadius
            );
        }
    }
    // Update is called once per frame
    void Update()
    {
        //éléments pour les mouvements horizontale
        moveDirectionX = Input.GetAxis("Horizontal");
        Flip();

        if (Input.GetButtonDown("Jump") && currentNumberJumps < maxAllowedJumps ){
            Jump();
            currentNumberJumps++;
        }
        if(isGrounded && !Input.GetButtonDown("Jump")){
            currentNumberJumps =0;
        }
    }
}
