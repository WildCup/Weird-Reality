using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] float jumpForse = 400f;
    [SerializeField] float jumpingForse = 10f;
    [SerializeField] int jumpBoostMax = 10;
    int jumpBoost;
    [Range(0f,.3f)][SerializeField] float movementSmoothing = 1f;
    [SerializeField] bool hasControl = true;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] Transform groundCheck;

    const float groundedRadious = .1f;
    bool grounded;
    bool justJumped;
    Rigidbody2D rigidbody2;
    bool facingRight = true;
    Vector3 velocity = Vector3.zero;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    private void Awake()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        jumpForse *= PlayerStats.instance.jump * 0.05f + 1f;
    }
    private void FixedUpdate()
    {
        //bool wasGrounded = grounded;
        //grounded = false;
        //the player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        //collider2d[] colliders = physics2d.overlapcircleall(groundcheck.position, groundedradious, whatisground);
        //for (int i = 0; i < colliders.length; i++)
        //{
        //    if (colliders[i].gameobject != gameobject)
        //    {
        //        grounded = true;
        //        if (!wasgrounded)
        //        {
        //            onlandevent.invoke();
        //        }
        //    }
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Wall")
        {
            grounded = true;
            OnLandEvent.Invoke();
            jumpBoost = jumpBoostMax; 
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            grounded = false;
        }
    }
    public void Move(float move, bool jumping, bool startJump)
    {
        if (hasControl)
        {
            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, rigidbody2.velocity.y);
            // And then smoothing it out and applying it to the character
            rigidbody2.velocity = Vector3.SmoothDamp(rigidbody2.velocity, targetVelocity, ref velocity, movementSmoothing);

            // If the input is moving the player right and the player is facing left...
            if(move > 0 && !facingRight)
            {
                //flip the player
                Flip();
            } 
            else if (move < 0 && facingRight)
            {
                //flip the player
                Flip();
            }
            if (grounded && startJump) 
                rigidbody2.AddForce(new Vector2(0f, jumpForse));
            if (jumping && jumpBoost > 0)
            {
                rigidbody2.AddForce(new Vector2(0f, jumpingForse));
                jumpBoost--;
            }
        }
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;
        //Rotate
        transform.Rotate(0f, 180f, 0f);
    }
}
