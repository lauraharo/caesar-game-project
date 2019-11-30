﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] float leftTurnPoint = -6.0f;
    [SerializeField] float rightTurnPoint = -4.0f;
    private bool dirRight = true;
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        moveEnemy();
        changeDirection();
    }

    private void moveEnemy()
    {
        if (dirRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
        }

    }

    private void changeDirection()
    {
        if (transform.position.x >= rightTurnPoint)
        {
            dirRight = false;
        }

        if (transform.position.x <= leftTurnPoint)
        {
            dirRight = true;
        }

    }

}
