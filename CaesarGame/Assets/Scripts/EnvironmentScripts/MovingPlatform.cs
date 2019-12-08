using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject platform;
    public Transform[] points;
    public int pointSelection;
    public float moveSpeed;

    Transform currPoint;
    GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        currPoint = points[pointSelection];
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void FixedUpdate()
    {

        platform.transform.position = Vector3.MoveTowards(platform.transform.position, currPoint.position, Time.deltaTime * moveSpeed);

        if (platform.transform.position == currPoint.position) {
            pointSelection++;

            if (pointSelection == points.Length) {
                pointSelection = 0;
            }

            currPoint = points[pointSelection];
        }
    }

}
