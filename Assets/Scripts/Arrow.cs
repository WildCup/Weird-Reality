using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 20;
    public int damage = 20;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null) enemy.TakeDamage(damage);
        Destroy(gameObject);
    }
}
