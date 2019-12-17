﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
   // Rigidbody2D spiderRigidBody;
    [SerializeField] float spiderSpeed = 1f;
    [SerializeField] float turnPointUp;
    [SerializeField] float turnPointDown;
    [SerializeField] float spiderMovementLength = 4f;
    EnemyHealth eh;

    bool isMovingDown = true;
    void Start()
    {
        //spiderRigidBody = GetComponent<Rigidbody2D>();
        turnPointUp = transform.position.y;
        turnPointDown = turnPointUp - spiderMovementLength;
        eh = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!eh.isDead) {
            MoveSpider();
            ChangeDirection();
        }
        
    }


    private void MoveSpider()
    {
        if (isMovingDown)
        {
            transform.Translate(Vector2.down * spiderSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(-Vector2.down * spiderSpeed * Time.deltaTime);
        }
    }
  

    private void ChangeDirection()
    {
        if (transform.position.y <= turnPointDown)
        {
            isMovingDown = false;
        }

        if (transform.position.y >= turnPointUp)
        {
            isMovingDown = true;
        }

    }

    public float getSpiderSpeed()
    {
        return spiderSpeed;
    }

    public bool getIsMovingDown()
    {
        return isMovingDown;
    }

}
