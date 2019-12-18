using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterColliderScript : MonoBehaviour
{
    Color oldColor;
    float oldMaxFallSpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPlatformerController ppc = collision.GetComponent<PlayerPlatformerController>();
        oldMaxFallSpeed = ppc.maxFallSpeed;
        if (ppc != null) ppc.maxFallSpeed *= 0.5f;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        SpriteRenderer sr = collision.GetComponent<SpriteRenderer>();
        oldColor = sr.color;
        if (sr != null) sr.color = new Color(1f, 1f, 1f, 0.5f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SpriteRenderer sr = collision.GetComponent<SpriteRenderer>();
        PlayerPlatformerController ppc = collision.GetComponent<PlayerPlatformerController>();

        if (sr != null) sr.color = oldColor;
        if (ppc != null) ppc.maxFallSpeed = oldMaxFallSpeed;
    }
}
