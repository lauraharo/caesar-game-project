using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] HealthBar healthBar;
    private float size;

    private void Start()
    {
        size = healthBar.transform.localScale.x * 10;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        size -= 1;
        healthBar.SetSize(size);
    }
}
