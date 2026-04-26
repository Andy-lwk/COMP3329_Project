using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerStats stats;
    private Rigidbody2D rb;
    private Vector2 v;
    private Animator anim;
    private float lastMoveX = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<PlayerStats>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (stats == null) return;
        float speed = stats.TotalSpeed;
        v = rb.velocity;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        v.x = horizontal * speed;
        v.y = vertical * speed;
        rb.velocity = v;

        if (Mathf.Abs(horizontal) > 0.1f)
            lastMoveX = horizontal;

        float animMoveX = (Mathf.Abs(horizontal) > 0.1f) ? horizontal : lastMoveX;
        anim.SetFloat("MoveX", animMoveX);

        if (anim != null)
        {
            anim.SetFloat("MoveX", horizontal);
            bool moving = Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f;
            anim.SetBool("isMoving", moving);
        }
    }
}
