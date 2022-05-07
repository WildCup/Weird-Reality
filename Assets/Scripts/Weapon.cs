using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public Transform attackPoint;
    public GameObject arrowPref;
    public GameObject magicPref;
    Animator animator;
    public LayerMask enemyLayer;

    public float attackRange = 0.5f;
    public int attackDamage = 30;
    public float meleeRate = 2f;
    float nextMeleeTime = 0f;

    public float fireRate = 1f;
    float nextFireTime = 0f;

    public float magicRate = 1f;
    float nextMagicTime = 0f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if(Time.time >= nextFireTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
        if (Time.time >= nextMeleeTime)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                Attack();
                nextMeleeTime = Time.time + 1f / meleeRate;
            }
        }
        if (Time.time >= nextMagicTime)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Magic();
                nextMagicTime = Time.time + 1f / magicRate;
            }
        }
    }
    void Shoot()
    {
        Instantiate(arrowPref,firePoint.position, firePoint.rotation);
        AudioManager.instance.Play("Fire");
        animator.SetTrigger("Attack");
    }
    void Attack()
    {
        animator.SetTrigger("Mele");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPoint.position,attackRange, enemyLayer);
        foreach(Collider2D enemy in colliders)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }
    void Magic()
    {
        Instantiate(magicPref, firePoint.position, firePoint.rotation);
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
