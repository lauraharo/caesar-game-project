using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPractice : MonoBehaviour
{
    [SerializeField] float delay = 0.5f;

    float lerpTime;
    bool isLastInstruction;
    EnemyHealth eh;
    SpriteRenderer sr;
    BoxCollider2D bc2d;
    Instructions instructions;


    private void Start()
    {
        eh = FindObjectOfType<EnemyHealth>();
        instructions = FindObjectOfType<Instructions>(); 
        sr = GetComponent<SpriteRenderer>();
        bc2d = GetComponent<BoxCollider2D>();
        lerpTime = 0f;
        isLastInstruction = false;
        sr.color = new Color(123f / 255f, 100f / 255f, 100f / 255f, lerpTime);
    }

    private void FixedUpdate()
    {
        if (eh == null || eh.isDead) {
            
            if (!isLastInstruction) instructions.LoadInstructions();
            isLastInstruction = true;
            StartCoroutine(EnableExit());
        }
    }

    IEnumerator EnableExit()
    {
        
        yield return new WaitForSeconds(delay);
        if (lerpTime < 1) lerpTime += 0.02f;
        sr.enabled = true;
        bc2d.enabled = true;
        sr.color = new Color(123f / 255f, 100f / 255f, 100f / 255f, lerpTime);
    }
}
