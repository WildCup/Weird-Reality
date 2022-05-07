using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    //public int lvl = 1;
    //public int points = 0;
    //public float totalExp;
    //public int killed = 0;
    public GameObject deadBody;
    public float force = 100f;
    //stats
    //public int precision = 0;
    //public int speed = 0;
    //public int jump = 0;
    //public int health = 0;
    public int currentHealth = 1;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        currentHealth = PlayerStats.instance.health + 1;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Vector2 direction = new Vector2(transform.position.x - collision.transform.position.x, 1f);
            TakeDamage(direction);
        }
    }
    void TakeDamage(Vector2 direction)
    {
        currentHealth--;
        animator.SetTrigger("Hit");
        if (currentHealth <= 0)
        {
            Die(direction);
        }
    }
    void Die(Vector2 direction)
    {
        GameObject temp = Instantiate(deadBody, transform.position, transform.rotation);
        temp.GetComponent<Rigidbody2D>().AddForce(direction * force);
        gameObject.SetActive(false);
    }
    public void EarnExp(float exp)
    {
        bool leveledUp = PlayerStats.instance.EarnExp(exp);
        if(leveledUp)
            animator.SetTrigger("LvlUp");
    }
}
