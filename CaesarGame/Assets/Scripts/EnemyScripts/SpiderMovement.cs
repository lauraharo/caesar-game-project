using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
   // Rigidbody2D spiderRigidBody;
    [SerializeField] float spiderSpeed = 1f;
    [SerializeField] float turnPointUp;
    [SerializeField] float turnPointDown;
    [SerializeField] float spiderMovementLength = 4f;

    bool isMovingDown = true;
    void Start()
    {
        //spiderRigidBody = GetComponent<Rigidbody2D>();
        turnPointUp = transform.position.y;
        turnPointDown = turnPointUp - spiderMovementLength;
        Debug.Log("turn point up: " + turnPointUp + " turn point down: " + turnPointDown);
    }

    // Update is called once per frame
    void Update()
    {
        MoveSpider();
        ChangeDirection();
        
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
