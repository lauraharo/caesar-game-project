using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderTrail : MonoBehaviour
{
    public Transform startPosition;
    public Vector3 startPositionOffset;
    public Transform endPosition;
    public Vector3 endPositionOffset;
    public float width = 3f;

    LineRenderer line;

    private void Awake()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.SetPosition(0, startPosition.transform.position + startPositionOffset);
        line.startWidth = width / 100;
        line.endWidth = width / 100;
    }

    private void Update()
    {
        line.SetPosition(1, endPosition.transform.position + endPositionOffset);
    }
}
