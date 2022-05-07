using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMenu : MonoBehaviour
{
    float length;
    float startX;
    public float speed;
    void Start()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        startX = transform.position.x;
    }
    void Update()
    {
        float newX = transform.position.x + Time.deltaTime * speed;
        if (newX > length) newX = startX;
        transform.position = new Vector3(newX, transform.position.y,transform.position.z);
    }
}
