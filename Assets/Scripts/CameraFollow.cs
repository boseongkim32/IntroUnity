using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPosition;
    private float minX, maxX;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        minX = -20;
        maxX = 60;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        tempPosition = transform.position;
        tempPosition.x = player.position.x;
        if (tempPosition.x < minX)
            tempPosition.x = minX;
        if (tempPosition.x > maxX)
            tempPosition.x = maxX;
        transform.position = tempPosition;
    }
}
