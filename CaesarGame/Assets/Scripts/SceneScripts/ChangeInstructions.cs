using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeInstructions : MonoBehaviour
{
    Instructions instructor;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        instructor = FindObjectOfType<Instructions>();
        instructor.LoadInstructions();
        Destroy(gameObject);
    }
}
