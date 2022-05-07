using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPref;
    public Transform firePoint;

    public float colldownMax;
    float colldown = 0;

    public float offSet = 3f;
    //public float recoilMax = 4f;
    //float recoil = 0f;

    void Update()
    {
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        if (Input.GetButton("Fire1") && colldown <= 0)
        {
            Quaternion spread = Quaternion.Euler(firePoint.rotation.eulerAngles + new Vector3(0f,0f,Random.Range(-offSet,offSet)));
            Instantiate(bulletPref, firePoint.position, spread);
            colldown = colldownMax;
            AudioManager.instance.Play("Shoot");
        }
        colldown -= Time.deltaTime;
        //recoil = Mathf.Max(0f, recoil - Time.deltaTime);
    }
}
