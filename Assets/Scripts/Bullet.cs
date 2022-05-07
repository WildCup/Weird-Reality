using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    public GameObject effect;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Enemy e = collision.GetComponent<Enemy>();
            if (e != null) e.TakeDamage(damage);
        }
        Vector3 dir = transform.position - collision.transform.position;
        GameObject o = Instantiate(effect, transform.position,transform.rotation);
        Destroy(o, 0.5f);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy e = collision.gameObject.GetComponent<Enemy>();
            if (e != null) e.TakeDamage(damage);
        }
        GameObject o = Instantiate(effect, transform);
        Destroy(o, 0.5f);
        Destroy(gameObject);
    }
}
