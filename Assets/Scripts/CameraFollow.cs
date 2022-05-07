using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform follow;
    public float minX;
    public float maxX;
    public float minY;
    public float speed = 0.1f;
    private void Awake()
    {
        follow = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        Vector3 newPosition = new Vector3(Mathf.Clamp(follow.position.x,minX,maxX), Mathf.Max(follow.position.y,minY), transform.position.z);
        //transform.position = newPosition;
        transform.position = Vector3.Lerp(transform.position, newPosition, speed);
    }
}
