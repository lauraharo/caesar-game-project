using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeLoop : MonoBehaviour
{

    public static ThemeLoop instance = null;
    void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
 
    void Update()
    {

    }
}
