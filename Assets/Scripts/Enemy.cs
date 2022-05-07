using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 100;
    public float speed = 3f;
    public float exp = 10f;

    Animator animator;
    Rigidbody2D rigidbody2;
    bool facingRight = true;
    Vector3 velocity = Vector3.zero;
    SpriteRenderer image;

    public Transform wallDetector;
    public LayerMask layerMask;

    private void Awake()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        animator.SetFloat("Speed", speed);
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        animator.SetTrigger("Hit");
        if (hp <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        animator.SetBool("Dead", true);
        AudioManager.instance.Play("Death");
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = true;
        Move(0f);
        gameObject.tag = "Dead";
        GameObject.Find("Player").GetComponent<Player>().EarnExp(exp);
        this.enabled = false;
    }
    private void FixedUpdate()
    {
        Move(speed * Time.fixedDeltaTime);
        if (Physics2D.OverlapCircle(wallDetector.position, 0.1f, layerMask))
        {
            speed = -speed;
        }
    }
    public void Move(float move)
    {
        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(move * 10f, rigidbody2.velocity.y);
        rigidbody2.velocity = targetVelocity;

            // If the input is moving the player right and the player is facing left...
        if (move > 0 && !facingRight)
            {
                Flip();
            }
            else if (move < 0 && facingRight)
            {
                Flip();
            }
    }
    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Wall")
        {
        speed = -speed;
        }
    }
}
