using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTile1 : MonoBehaviour
{

    [SerializeField] float upTurnPoint;
    [SerializeField] float downTurnPoint;
    private bool dirUp = false;
    [SerializeField] float speed = 1.0f;

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
        if (dirUp)
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
        if (transform.position.y <= upTurnPoint)
        {
            dirUp = true;
        }

        if (transform.position.y >= downTurnPoint)
        {
            dirUp = false;
        }
    }

}
