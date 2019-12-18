using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    Transform healthBar;

    private void Start()
    {
        healthBar = transform.Find("Health");
    }

    public void SetSize(float sizeNormalized)
    {
        Debug.Log(sizeNormalized);
        healthBar.localScale = new Vector3(sizeNormalized, 1f);
    }

   


}
