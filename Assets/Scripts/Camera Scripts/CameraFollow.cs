using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 0, -10);
    public bool useBounds = true;
    public Vector2 minBounds;
    public Vector2 maxBounds;
    public BoxCollider2D levelBoundsCollider;

    void Start()
    {
        if (levelBoundsCollider != null)
        {
            Bounds bounds = levelBoundsCollider.bounds;
            minBounds = bounds.min;
            maxBounds = bounds.max;
            useBounds = true;
        }
    }

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 desiredPosition = player.position + offset;

        if (useBounds)
        {
            Camera cam = GetComponent<Camera>();
            float halfHeight = cam.orthographicSize;
            float halfWidth = halfHeight * cam.aspect;

            float clampedX = Mathf.Clamp(desiredPosition.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
            float clampedY = Mathf.Clamp(desiredPosition.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);

            desiredPosition = new Vector3(clampedX, clampedY, desiredPosition.z);
        }

        transform.position = desiredPosition;
    }
}
