using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPractice : MonoBehaviour
{
    private void OnDestroy()
    {
        EnableLevelExit();
        GetComponent<ChangeInstructions>().Change();
    }

    private void EnableLevelExit()
    {
        LevelExit le = FindObjectOfType<LevelExit>();
        le.GetComponent<SpriteRenderer>().enabled = true;
        le.GetComponent<BoxCollider2D>().enabled = true;

    }
}
