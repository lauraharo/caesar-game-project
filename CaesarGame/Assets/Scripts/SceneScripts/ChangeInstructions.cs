using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeInstructions : MonoBehaviour
{
    Instructions instructor = null;
    bool entered = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Change();
    }

    public void Change() {
        if (!entered) {
            instructor = FindObjectOfType<Instructions>();
            instructor.LoadInstructions();
            Destroy(gameObject);
            entered = true;
        }
    }
}
