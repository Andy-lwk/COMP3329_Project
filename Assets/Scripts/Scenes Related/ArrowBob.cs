using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBob : MonoBehaviour
{
    public float bobDistance = 1f;
    public float bobSpeed = 0.1f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * bobSpeed) * bobDistance;
        transform.localPosition = startPos + new Vector3(offset, 0, 0);
    }
}
