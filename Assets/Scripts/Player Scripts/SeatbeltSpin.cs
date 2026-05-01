using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatbeltSpin : MonoBehaviour
{
    public float radius = 1.5f;      // Distance from player
    public float duration = 0.3f;    // Time for full 360° spin

    private Transform target;         // Player transform
    private float startAngle;
    private float elapsed = 0f;

    public void Initialize(Transform player)
    {
        target = player;
        startAngle = 0f;
        Vector3 startPos = player.position + new Vector3(radius, 0, 0);
        transform.position = startPos;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        elapsed += Time.deltaTime;
        float t = Mathf.Clamp01(elapsed / duration);
        float angle = t * 360f;

        Vector3 offset = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0) * radius;
        transform.position = target.position + offset;

        if (t >= 1f)
            Destroy(gameObject);
    }
}
