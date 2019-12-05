using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderSpiderTrail : MonoBehaviour
{
    [SerializeField] SpiderMovement spider;
    [SerializeField] float spiderTrailLength;
    void Start()
    {
        spiderTrailLength = transform.localScale.y;
        spider = FindObjectOfType<SpiderMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        changeSpiderTrailLength();
        Debug.Log(spiderTrailLength);
    }

    void changeSpiderTrailLength()
    {
        transform.localScale = new Vector2(0.1f, spider.transform.position.y);

    }
}
