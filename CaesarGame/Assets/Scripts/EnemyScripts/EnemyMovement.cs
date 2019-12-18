using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] Transform pointA = null, pointB = null;
    [SerializeField] float resetTime = 1.0f, smooth = 1;

    Vector3 newPos;
    EnemyHealth eh;
    States state;

    enum States { movingTowardsA, movingTowardsB }

    private void Awake()
    {
        eh = GetComponent<EnemyHealth>();
        transform.position = pointA.position;
        state = States.movingTowardsB;
    }

    private void Start()
    {
        ChangeTarget();
    }

    void FixedUpdate()
    {
        transform.position = Vector2.LerpUnclamped(transform.position, newPos, smooth * Time.deltaTime);
    }

    void ChangeTarget() {
        if (state == States.movingTowardsB) {
            state = States.movingTowardsA;
            newPos = pointB.position;
        }
        else if (state == States.movingTowardsA) {
            state = States.movingTowardsB;
            newPos = pointA.position;
        }

        Invoke("ChangeTarget", resetTime);
    }
}

