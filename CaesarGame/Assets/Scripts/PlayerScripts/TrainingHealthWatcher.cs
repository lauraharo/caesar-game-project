using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingHealthWatcher : MonoBehaviour
{
    [SerializeField] float delay = 0.5f;
    PlayerHealth ph;
    // Start is called before the first frame update
    void Start()
    {
        ph = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ph.currentHealth < ph.startingHealth) StartCoroutine(HealthAdd());
    }


    IEnumerator HealthAdd()
    {
        yield return new WaitForSecondsRealtime(delay);
        ph.AddHealth(ph.startingHealth - ph.currentHealth);
    }
}
