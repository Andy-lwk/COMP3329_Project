using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerStats stats;
    private Rigidbody2D rb;
    private Vector2 v;
    private Animator anim;
    private float lastHorizontal = 1f; 

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

         if (Mathf.Abs(horizontal) > 0.05f)
            lastHorizontal = horizontal;

        bool isMoving = Mathf.Abs(horizontal) > 0.05f || Mathf.Abs(vertical) > 0.05f;

        if (anim != null)
        {
            anim.SetFloat("FacingX", lastHorizontal);
            anim.SetBool("isMoving", isMoving);
        }
    }
}
