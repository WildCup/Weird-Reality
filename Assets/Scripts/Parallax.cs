using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    float length, startPos;
    public Camera cam;
    public float parallexEffect;
    float whenToMove;
    private void Awake()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        whenToMove = (length + cam.orthographicSize) / 2;
    }
    void Update()
    {
        float temp = cam.transform.position.x * (1 - parallexEffect);
        float disc = cam.transform.position.x * parallexEffect;
        transform.position = new Vector3(startPos + disc, transform.position.y, transform.position.z);
        if (temp > startPos + whenToMove) startPos += length;
        else if (temp < startPos - whenToMove) startPos -= length;

    }
}
