﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTile1 : MonoBehaviour
{

    [SerializeField] float leftTurnPoint = -6.0f;
    [SerializeField] float rightTurnPoint = -4.0f;
    private bool dirRight = true;
    public float speed = 1.0f;
    private int y1 = 0;
    private int y2 = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        moveTile();
        changeDirection();
    }

    private void moveTile()
    {
        if (dirRight)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

    }

    private void changeDirection()
    {
        if (transform.position.x >= rightTurnPoint)
        {
            dirRight = true;
        }

        if (transform.position.x <= leftTurnPoint)
        {
            dirRight = false;
        }

    }

}
