using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderSpiderTrail : MonoBehaviour
{
    [SerializeField] SpiderMovement spider;
    float spiderTrailLength;
    void Start()
    {
        spiderTrailLength = spider.transform.localScale.y;
        spider = FindObjectOfType<SpiderMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        changeSpiderTrailLength();

    }


    void changeSpiderTrailLength()
    {
        transform.localScale = new Vector2(0.03f, -spider.transform.position.y);
        if (spider.getIsMovingDown())
        {
            transform.Translate(Vector2.down * spider.getSpiderSpeed()/2 * Time.deltaTime);
        }
        else
        {
            transform.Translate(-Vector2.down * spider.getSpiderSpeed()/2 * Time.deltaTime);
        }

    }
}
