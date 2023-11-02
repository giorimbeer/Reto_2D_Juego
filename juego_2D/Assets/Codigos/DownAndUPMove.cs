using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownAndUPMove : MonoBehaviour
{
    public float speed = 7;
    public float time = 1;
    private float addTime;

    void Start()
    {   
        addTime = time;
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);

        if (Time.timeSinceLevelLoad >= time) 
        {
            speed *= -1;
            time += addTime;
        }
    }
}
